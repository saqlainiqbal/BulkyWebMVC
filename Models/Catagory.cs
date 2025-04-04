using System.ComponentModel.DataAnnotations;

namespace BulkyWebMVC.Models
{
   public class Catagory
   {
      [Key]
      public int Id { get; set; }
      [Required]
      public string Name { get; set; } = string.Empty;
      public int DisplayOrder { get; set; }
   }
}
