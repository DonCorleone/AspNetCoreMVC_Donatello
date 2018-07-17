using System.ComponentModel.DataAnnotations;

namespace Donatello.ViewModels
{
   public class AddCard
   {
      public int Id { get; set; } // board Id
      [Required]
      public string Contents { get; set; } // card contents
   }
}