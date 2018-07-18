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
		private readonly BoardService _boardService;

		public BoardController(BoardService boardService)
		{
			this._boardService = boardService;
		}
		public IActionResult Index(int id)
		{
			BoardView model = _boardService.GetBoardView(id);

			return base.View(model);
		}

		public IActionResult AddCard(int id)
		{
			return base.View();
		}

		[HttpPost]
		public IActionResult AddCard(AddCard addCardViewModel)
		{

			if (!ModelState.IsValid)
				return base.View(addCardViewModel);

			_boardService.AddCard(addCardViewModel);

			return base.RedirectToAction(
				nameof(Index), new AddCard
				{
					Id = addCardViewModel.Id
				}
			);
		}
	}
}