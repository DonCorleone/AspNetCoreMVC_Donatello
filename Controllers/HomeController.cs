using Donatello.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Donatello.Controllers
{
   public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new BoardList();
            
            var board = new BoardList.Board();
            board.Title = "Linis Board";
            
            model.Boards.Add(board);
            model.Boards.Add(new BoardList.Board(){Title = "Yess"});
            return View(model);
        }
    }
}