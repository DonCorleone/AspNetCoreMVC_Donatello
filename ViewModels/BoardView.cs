using System.Collections.Generic;

namespace Donatello.ViewModels
{
   public class BoardView
   {
      public List<Column> Columns {get;set;} = new List<Column>();
      public class Column
      { 
         public string Title { get; set; }
      }
   }
}