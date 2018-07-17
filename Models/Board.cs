using System.Collections.Generic;

namespace Donatello.Models
{
   public class Board{
      public int Id { get; set; }
      public string Title { get; set; }
      public List<Column> Columns {get;set;} = new List<Column>();
   }

   public class Column
   {
       public int Id {get;set;}
       public string Title {get;set;}
       public List<Card> Cards {get;set;} = new List<Card>();
   }

   public class Card
   {
       public int Id {get;set;}
       public string Contents {get;set;}
   }
}