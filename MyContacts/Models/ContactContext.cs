using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace MyContacts.Models
{
    public class ContactContext(DbContextOptions<ContactContext> options) : DbContext(options)
    {
        public DbSet<Contact> Contacts { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                               new User { Id = 1, UserName = "Admin", Password = "Admin" },
                               new User { Id = 2, UserName = "gerry", Password = "password" }
                                );


            modelBuilder.Entity<Category>().HasData(
              new Category { CategoryId = 1, Name = "Family" },
              new Category { CategoryId = 2, Name = "Friend" },
              new Category { CategoryId = 3, Name = "Work" }
            );

            modelBuilder.Entity<Contact>().HasData(
              new Contact
                  {
                     ContactId = 1,
                     FirstName = "Scott",
                     LastName = "Gudmestad",
                     PhoneNumber = "123-456-7890",
                     Email = "sgudmestad@gmail.com",
                     CategoryId = 1,
                     },
              new Contact
              {
                  ContactId = 2,
                  FirstName = "Gerry",
                  LastName = "Gudmestad",
                  PhoneNumber = "123-456-7890",
                  Email = "ggudmestad@gmail.com",
                  CategoryId = 1,
              },
              new Contact
              {
                  ContactId = 3,
                  FirstName = "Blake",
                  LastName = "Boyer",
                  PhoneNumber = "123-456-7890",
                  Email = "bboyer@gmail.com",
                  CategoryId = 2,
              }
         );
        }
    }   
   
}
