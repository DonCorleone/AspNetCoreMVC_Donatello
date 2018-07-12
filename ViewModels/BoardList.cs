using System.Collections.Generic;

namespace Donatello.ViewModels{
   public class BoardList{

      public List<Board> Boards{ get; set; } = new List<Board>();
      public class Board{
         public string Title { get; set; }
      }
   }
}