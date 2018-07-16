using System;
using System.Linq;
using Donatello.Infrastructure;
using Donatello.Models;
using Donatello.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Donatello.Services
{
	public class BoardService
	{
		private readonly DonatelloContext dbContext;

		public BoardService(DonatelloContext dbContext)
		{
			this.dbContext = dbContext;
		}
		public BoardList GetListBoards()
		{
			var boardList = new BoardList();

			foreach (var dbBoard in dbContext.Boards)
			{
				boardList.Boards.Add(new Board()
				{
					Title = dbBoard.Title
				});
			}

			return boardList;
		}
		public BoardView GetBoardView(int id)
		{
			var modelBoard = new BoardView();

			var dbBoard = dbContext.Boards
				.Include(b => b.Columns)
				.ThenInclude(c => c.Cards)
				.SingleOrDefault(x => x.Id == id);

			foreach (var dbColumn in dbBoard.Columns)
			{
				var modelColumn = new BoardView.Column()
				{
					Title = dbColumn.Title
				};

				foreach (var dbCard in dbColumn.Cards)
				{
					 var modelCard = new BoardView.Card(){
						 Content = dbCard.Contents
					 };

					 modelColumn.Cards.Add(modelCard);
				}
				
				modelBoard.Columns.Add(modelColumn);
			}
			return modelBoard;
		}

		public void AddBoard(string title)
		{
			dbContext.Boards.Add(new Models.Board()
			{
				Title = title
			});

			dbContext.SaveChanges();
		}
	}
}