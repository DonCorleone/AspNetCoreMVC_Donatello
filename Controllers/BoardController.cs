using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Donatello.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Donatello.Controllers
{
    public class BoardController : Controller
    {
        public IActionResult Index()
      {
         BoardView model = GetBoardView();

         return View(model);
      }

      private static BoardView GetBoardView()
      {
         var boardView = new BoardView();
         var columnOne = new BoardView.Column()
         {
            Title = "ToDo"
         };

         columnOne.Cards.AddRange(
             new BoardView.Card[]{
                    new BoardView.Card(){
                        Content = "CardOne"
                    },new BoardView.Card(){
                        Content = "CardTwo"
                    }, new BoardView.Card(){
                        Content = "CardTree"
                    }
             }
         );

         var columnTwo = new BoardView.Column()
         {
            Title = "Drah"
         };

         columnTwo.Cards.AddRange(
             new BoardView.Card[]{
                new BoardView.Card(){
                    Content = "CardUno"
                },new BoardView.Card(){
                    Content = "CardDue"
                    }, new BoardView.Card(){
                    Content = "CardTre"
                }
             }
         );

         boardView.Columns.AddRange(
             new BoardView.Column[] { columnOne, columnTwo });
         return boardView;
      }
   }
}