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

		public IActionResult Index()
		{
			BoardList model = boardService.GetListBoards();
			return View(model);
		}
	}
}