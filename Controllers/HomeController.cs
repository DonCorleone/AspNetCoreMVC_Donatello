using Donatello.Services;
using Donatello.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Donatello.Controllers
{
	public class HomeController : Controller
	{
      private readonly BoardService boardService;

      public HomeController(BoardService boardService)
		{
         this.boardService = boardService;
      }

		[HttpGet]
		public IActionResult Index()
		{
			BoardList model = boardService.GetListBoards();
			return View(model);
		}

		[HttpGet]
		public IActionResult Create(){
			return View();
		}
		
		[HttpPost]
		public IActionResult Create(NewBoard viewModel){
			boardService.AddBoard(viewModel.Title);
			return RedirectToAction(nameof(Index));
		}
	}
}