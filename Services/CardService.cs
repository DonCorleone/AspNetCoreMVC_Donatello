using System;
using System.Linq;
using Donatello.Infrastructure;
using Donatello.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Donatello.Services
{
   public class CardService
   {
      private readonly DonatelloContext _dbContext;

      public CardService(DonatelloContext dbContext)
      {
         this._dbContext = dbContext;
      }

      public CardDetails GetDetails(int id){

         var dbCard = _dbContext.Cards
            .Include(c => c.Column)
            .SingleOrDefault(x => x.Id == id);

         if (dbCard == null)
            return new CardDetails();

         var dbBoard = _dbContext.Boards
            .Include(b => b.Columns)
            .SingleOrDefault(x => x.Id == dbCard.Column.BoardId);

         var availableColumns = dbBoard.Columns.Select(x => new SelectListItem(){
            Value = x.Id.ToString(),
            Text = x.Title});
         // else
         return new CardDetails(){
            Id = dbCard.Id,
            Contents = dbCard.Contents,
            Notes = dbCard.Notes,
            selectedColumnId = dbCard.ColumnId,
            Columns = availableColumns.ToList()
         };
      }

      internal void Update(CardDetails cardDetails)
      {
         var dbCard = _dbContext.Cards.FirstOrDefault(x => x.Id == cardDetails.Id);
         
         dbCard.Notes = cardDetails.Notes;
         dbCard.Contents = cardDetails.Contents;
         dbCard.ColumnId = cardDetails.selectedColumnId;

         _dbContext.SaveChanges();
      }
   }
}