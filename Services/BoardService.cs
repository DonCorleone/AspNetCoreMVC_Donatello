using System;
using System.Collections.Generic;
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
					Id = dbBoard.Id,
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

			modelBoard.Title = dbBoard.Title;
			modelBoard.Id = dbBoard.Id;

			foreach (var dbColumn in dbBoard.Columns)
			{
				var modelColumn = new BoardView.Column()
				{
					Title = dbColumn.Title
				};

				foreach (var dbCard in dbColumn.Cards)
				{
					var modelCard = new BoardView.Card()
					{
						Id = dbCard.Id,
						Content = dbCard.Contents
					};

					modelColumn.Cards.Add(modelCard);
				}

				modelBoard.Columns.Add(modelColumn);
			}
			return modelBoard;
		}

      internal void AddCard(AddCard addCardViewModel)
      {
         var board = dbContext.Boards
				.Include (b => b.Columns)
				.SingleOrDefault(x => x.Id == addCardViewModel.Id);

			if (!board.Columns.Any())
				board.Columns.Add(new Column(){
					Title = "ToDo"}
				);

			board.Columns[0].Cards.Add(new Card(){
				Contents = addCardViewModel.Contents
			});

			dbContext.SaveChanges();
      }

      public void AddBoard(string title)
		{

			dbContext.Boards.Add(new Models.Board()
			{
				Title = title,
				Columns = new List<Column>(new Column[]
				{
					new Column()
					{
						Title = "Column 1",
							Cards = new List<Card>(new Card[]
							{
								new Card()
								{
									Contents = "Card A"
								}
							})
					},
					new Column()
					{
						Title = "Column 2",
							Cards = new List<Card>(new Card[]
							{
								new Card()
								{
									Contents = "Card B"
								}
							})
					},
					new Column()
					{
						Title = "Column 3",
							Cards = new List<Card>(new Card[]
							{
								new Card()
								{
									Contents = "Card C"
								}
							})
					}
				})
			});

			dbContext.SaveChanges();
		}
	}
}