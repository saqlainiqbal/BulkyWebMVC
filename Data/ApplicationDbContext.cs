using BulkyWebMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWebMVC.Data
{
   public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
   {
      public DbSet<Catagory> Catagories { get; set; }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.Entity<Catagory>().HasData(
            new Catagory { Id = 1, Name = "Web Development", DisplayOrder = 1 },
            new Catagory { Id = 2, Name = "I Love React.", DisplayOrder = 2 },
            new Catagory { Id = 3, Name = "I Love Angular.", DisplayOrder = 3 }
            );
      }
   }
}
