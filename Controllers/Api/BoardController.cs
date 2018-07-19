using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Donatello.ViewModels;
using Donatello.Services;
using Microsoft.EntityFrameworkCore;
using Donatello.Infrastructure;

namespace Donatello.Api.Controllers
{

	[Route("api/[controller]")]
	[ApiController]
	public class BoardController : ControllerBase
	{
      private readonly BoardService _boardService;

      public BoardController(BoardService BoardService)
		{
         this._boardService = BoardService;
      }

		[HttpPost("movecard")]
		public IActionResult MoveCard([FromBody] MoveCardCommand command)
		{
			this._boardService.Move(command);

			return base.Ok(new {Moved = true});
		}
	}
}