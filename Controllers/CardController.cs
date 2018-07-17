using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Donatello.Services;
using Microsoft.AspNetCore.Mvc;

namespace Donatello.Controllers
{
	public class CardController : Controller
	{
      private readonly CardService cardService;

      public CardController(CardService cardService)
		{
         this.cardService = cardService;
      }

		[HttpGet]
		public IActionResult Details(int id)
		{

			CardDetails cardDetailsViewModel = cardService.GetDetails(id);

			return View(cardDetailsViewModel);
		}

		[HttpPost]
		public IActionResult Details(CardDetails cardDetails)
		{
			cardService.Update(cardDetails);

			return RedirectToAction(
				nameof(Details), 				
				new {
					Id = cardDetails.Id
				}
			);
		}
	}
}