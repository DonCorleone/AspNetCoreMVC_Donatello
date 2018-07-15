using Microsoft.EntityFrameworkCore;
using static Donatello.ViewModels.BoardList;

namespace Donatello.Infrastructure{
   public class DonatelloContext : DbContext{
      
      public DonatelloContext(DbContextOptions<DonatelloContext> options) 
         : base(options)
      {
          
      }

      public DbSet<Board> Boards{get;set;}
   }
}