using Donatello.Services;
using Donatello.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Donatello.Controllers
{
	public class HomeController : Controller
	{
      private readonly BoardService _boardService;

      public HomeController(BoardService boardService){
         this._boardService = boardService;
      }

		[HttpGet]
		public IActionResult Index(){

			BoardList model = _boardService.GetListBoards();

			return base.View(model);
		}

		[HttpGet]
		public IActionResult Create(){
			return base.View();
		}
		
		[HttpPost]
		public IActionResult Create(NewBoard newBoardViewModel){

			_boardService.AddBoard(newBoardViewModel.Title);

			return base.RedirectToAction(nameof(Index));
		}
	}
}