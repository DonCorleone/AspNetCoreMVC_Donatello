using Donatello.ViewModels;

namespace Donatello.Services{
   public class BoardService{
      public BoardList GetListBoards()
      {
         var boardList = new BoardList();

         boardList.Boards.Add(new BoardList.Board() {
            Title = "Linis Board"
         });

         boardList.Boards.Add(new BoardList.Board() { 
            Title = "Yess" 
         });

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
             new BoardView.Card[]{
                    new BoardView.Card(){
                        Content = "CardOne"
                    },new BoardView.Card(){
                        Content = "CardTwo"
                    }, new BoardView.Card(){
                        Content = "CardTree"
                    }
             }
         );

         var columnTwo = new BoardView.Column()
         {
            Title = "Drah"
         };

         columnTwo.Cards.AddRange(
             new BoardView.Card[]{
                new BoardView.Card(){
                    Content = "CardUno"
                },new BoardView.Card(){
                    Content = "CardDue"
                    }, new BoardView.Card(){
                    Content = "CardTre"
                }
             }
         );

         boardView.Columns.AddRange(
             new BoardView.Column[] { columnOne, columnTwo });
         return boardView;
      }
   }
}