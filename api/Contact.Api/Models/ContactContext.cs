using Microsoft.EntityFrameworkCore;
using System;

namespace Contact.Api.Models
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
            });

            modelBuilder.Entity<Contact>().HasData(new Contact
            {
                ContactId = 1,
                FirstName = "Pradeep",
                LastName = "Dhawan",
                Email = "pradeep@gmail.com",
                DateOfBirth = new DateTime(1979, 10, 23)
            }, new Contact
            {
                ContactId = 2,
                FirstName = "Shilpi",
                LastName = "Vohra",
                Email = "shilpi@gmail.com",
                DateOfBirth = new DateTime(1981, 07, 06)
            });
        }
    }
}