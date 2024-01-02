using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Macs.WebApi.DataAccess.Entities
{
    public class MacsContext : DbContext
    {
        //private readonly IConfiguration config;

        public MacsContext(DbContextOptions<MacsContext> options) : base(options)
        { }

        public DbSet<Address> Addresses => Set<Address>();
        public DbSet<Contact> Contacts => Set<Contact>();
        public DbSet<Person> Person => Set<Person>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var guid1 = Guid.NewGuid();

            modelBuilder.Entity<Address>()
                .HasData(
                        new Address()
                        {
                            Id = Guid.NewGuid(),
                            PersonId = guid1,
                            AddressLine1 = "Address Line 1",
                            AddressLine2 = "Address Line 2",
                            AddressLine3 = "Address Line 3",
                            PostCode = "1ED",
                            City = "Edinburgh",
                            Country = "Scotland",
                            IsActive = true,
                            Preferred = true,
                            Type = AddressType.Home
                        }
                );

            modelBuilder.Entity<Contact>()
                .HasData(
                new Contact()
                {
                    Id = Guid.NewGuid(),
                    PersonId = guid1,
                    IsActive = true,
                    Preferred = true,
                    Type = ContactType.Email,
                    Value = "mirela@home.com"
                }
                );

            modelBuilder.Entity<Person>()
                .HasData(new Person()
                {
                    Id = guid1,
                    Title = "Ms",
                    FirstName = "Mirela",
                    MiddleName = "Lucia",
                    LastName = "Sauca",
                    DateOfBirth = new DateTime(2000, 1,1)
                });
        }
    }

}
