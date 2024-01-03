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

            var personId1 = Guid.NewGuid();
            var personId2 = Guid.NewGuid();
            var personId3 = Guid.NewGuid();
            var personId4 = Guid.NewGuid();

            modelBuilder.Entity<Address>()
                .HasData(
                        new ()
                        {
                            Id = Guid.NewGuid(),
                            PersonId = personId1,
                            AddressLine1 = "Heriot-Watt University",
                            AddressLine2 = "",
                            AddressLine3 = "",
                            PostCode = " EH14 4AS",
                            City = "Edinburgh",
                            Country = "Scotland",
                            IsActive = true,
                            Preferred = true,
                            Type = AddressType.Work
                        },
                        new ()
                        {
                            Id = Guid.NewGuid(),
                            PersonId = personId2,
                            AddressLine1 = "Heriot-Watt University",
                            AddressLine2 = "",
                            AddressLine3 = "",
                            PostCode = " EH14 4AS",
                            City = "Edinburgh",
                            Country = "Scotland",
                            IsActive = true,
                            Preferred = true,
                            Type = AddressType.Work
                        },
                        new ()
                        {
                            Id = Guid.NewGuid(),
                            PersonId = personId3,
                            AddressLine1 = "Heriot-Watt University",
                            AddressLine2 = "",
                            AddressLine3 = "",
                            PostCode = " EH14 4AS",
                            City = "Edinburgh",
                            Country = "Scotland",
                            IsActive = true,
                            Preferred = true,
                            Type = AddressType.Work
                        },
                        new ()
                        {
                            Id = Guid.NewGuid(),
                            PersonId = personId4,
                            AddressLine1 = "Heriot-Watt University",
                            AddressLine2 = "",
                            AddressLine3 = "",
                            PostCode = " EH14 4AS",
                            City = "Edinburgh",
                            Country = "Scotland",
                            IsActive = true,
                            Preferred = true,
                            Type = AddressType.Work
                        }
                );

            modelBuilder.Entity<Contact>()
                .HasData(
                new ()
                {
                    Id = Guid.NewGuid(),
                    PersonId = personId1,
                    IsActive = true,
                    Preferred = true,
                    Type = ContactType.Email,
                    Value = "mirela@hw.com"
                },
                new ()
                {
                    Id = Guid.NewGuid(),
                    PersonId = personId2,
                    IsActive = true,
                    Preferred = true,
                    Type = ContactType.Email,
                    Value = "nastia@hw.com"
                },
                new ()
                {
                    Id = Guid.NewGuid(),
                    PersonId = personId3,
                    IsActive = true,
                    Preferred = true,
                    Type = ContactType.Email,
                    Value = "paul@hw.com"
                },
                new ()
                {
                    Id = Guid.NewGuid(),
                    PersonId = personId4,
                    IsActive = true,
                    Preferred = true,
                    Type = ContactType.Email,
                    Value = "john@hw.com"
                }
                );

            modelBuilder.Entity<Person>()
                .HasData(
                    new ()
                    {
                        Id = personId1,
                        Title = "Ms",
                        FirstName = "Mirela",
                        MiddleName = "",
                        LastName = "Developer",
                        DateOfBirth = new DateTime(1990, 1,1)
                    },
                    new ()
                    {
                        Id = personId2,
                        Title = "Miss",
                        FirstName = "Nastia",
                        MiddleName = "",
                        LastName = "Developer",
                        DateOfBirth = new DateTime(2000, 1, 1)
                    },
                    new ()
                    {
                        Id = personId3,
                        Title = "Mr",
                        FirstName = "Paul",
                        MiddleName = "",
                        LastName = "Developer",
                        DateOfBirth = new DateTime(1990, 1, 1)
                    },
                    new ()
                    {
                        Id = personId4,
                        Title = "Mr",
                        FirstName = "John",
                        MiddleName = "",
                        LastName = "Developer",
                        DateOfBirth = new DateTime(1980, 1, 1)
                    });
        }
    }

}
