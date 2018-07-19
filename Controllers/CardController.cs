using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Donatello.Services;
using Donatello.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Donatello.Controllers
{
	public class CardController : Controller
	{
		private readonly CardService _cardService;

		public CardController(CardService cardService)
		{
			this._cardService = cardService;
		}

		[HttpGet]
		public IActionResult Details(int id)
		{

			CardDetails cardDetailsViewModel = _cardService.GetDetails(id);

			return base.View(cardDetailsViewModel);
		}

		[HttpPost]
		public IActionResult Update(CardDetails cardDetails)
		{
			_cardService.Update(cardDetails);

			base.TempData["Message"] = "Saved Card Details";

			return base.RedirectToAction(
				nameof(Details),
				new
				{
					Id = cardDetails.Id
				}
			);
		}
	}
}