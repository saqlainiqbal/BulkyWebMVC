using System.ComponentModel.DataAnnotations;

namespace BulkyWebMVC.Models
{
   public class Catagory
   {
      [Key]
      public int Id { get; set; }
      [Required]
      [Display(Name = "Category Name")]
      public string Name { get; set; } = string.Empty;
      [Display(Name = "Display Order")]
      public int DisplayOrder { get; set; }
   }
}
