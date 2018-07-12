using Donatello.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Donatello.Controllers
{
   public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var modelz = new BoardList();
            
            var board = new BoardList.Board();
            board.Title = "Linis Board";
            
            modelz.Boards.Add(board);
            modelz.Boards.Add(new BoardList.Board(){Title = "Yess"});
            return View(modelz);
        }
    }
}