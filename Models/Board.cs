using System.Collections.Generic;

namespace Donatello.Models
{
	public class Board
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public List<Column> Columns { get; set; } = new List<Column>();
	}

	public class Column
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public List<Card> Cards { get; set; } = new List<Card>();

		// Reverse Navigation Property
		public int BoardId { get; set; }
	}

	public class Card
	{
		public int Id { get; set; }
		public string Contents { get; set; }
		public string Notes { get; set; }

		// Reverse Navigation Property
    	public int ColumnId { get; set; }
    	public Column Column { get; set; }
	}
}