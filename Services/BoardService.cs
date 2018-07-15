using System;
using Donatello.Infrastructure;
using Donatello.Models;
using Donatello.ViewModels;

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
		public BoardView GetBoardView()
		{
			var boardView = new BoardView();
			var columnOne = new BoardView.Column()
			{
				Title = "ToDo"
			};

			columnOne.Cards.AddRange(
				new BoardView.Card[]
				{
					new BoardView.Card()
					{
						Content = "CardOne"
					}, new BoardView.Card()
					{
						Content = "CardTwo"
					}, new BoardView.Card()
					{
						Content = "CardTree"
					}
				}
			);

			var columnTwo = new BoardView.Column()
			{
				Title = "Drah"
			};

			columnTwo.Cards.AddRange(
				new BoardView.Card[]
				{
					new BoardView.Card()
					{
						Content = "CardUno"
					}, new BoardView.Card()
					{
						Content = "CardDue"
					}, new BoardView.Card()
					{
						Content = "CardTre"
					}
				}
			);

			boardView.Columns.AddRange(
				new BoardView.Column[] { columnOne, columnTwo });
			return boardView;
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