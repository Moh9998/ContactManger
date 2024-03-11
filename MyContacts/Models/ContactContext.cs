﻿using Microsoft.EntityFrameworkCore;

namespace MyContacts.Models
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
