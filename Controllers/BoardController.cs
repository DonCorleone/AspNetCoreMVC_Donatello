using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Donatello.Services;
using Donatello.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Donatello.Controllers
{
	public class BoardController : Controller
	{
      private readonly BoardService boardService;

      public BoardController(BoardService boardService)
		{
         this.boardService = boardService;
      }
		public IActionResult Index(int id)
		{
			BoardView model = boardService.GetBoardView(id);

			return View(model);
		}
	}
}