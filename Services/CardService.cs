using System;
using System.Linq;
using Donatello.Infrastructure;
using Donatello.Models;
using Microsoft.EntityFrameworkCore;

namespace Donatello.Services
{
   public class CardService
   {
      private readonly DonatelloContext dbContext;

      public CardService(DonatelloContext dbContext)
      {
         this.dbContext = dbContext;
      }

      public CardDetails GetDetails(int id){

         var dbCard = dbContext.Cards.SingleOrDefault(x => x.Id == id);

         if (dbCard == null)
            return new CardDetails();

         // else
         return new CardDetails(){
            Id = dbCard.Id,
            Contents = dbCard.Contents,
            Notes = dbCard.Notes
         };
      }

      internal void Update(CardDetails cardDetails)
      {
         var dbCard = dbContext.Cards.FirstOrDefault(x => x.Id == cardDetails.Id);
         
         dbCard.Notes = cardDetails.Notes;
         dbCard.Contents = cardDetails.Contents;

         dbContext.SaveChanges();
      }
   }
}