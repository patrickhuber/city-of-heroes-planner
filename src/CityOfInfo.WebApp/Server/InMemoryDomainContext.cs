using CityOfInfo.Domain;
using CityOfInfo.Domain.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityOfInfo.WebApp.Server
{
    public class InMemoryDomainContext : DomainContext
    {
        public InMemoryDomainContext()
        { }

        public InMemoryDomainContext(DbContextOptions options) : base(options) 
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Power>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Power>()
                .Property(x => x.Id)
                .ValueGeneratedNever();
            modelBuilder.Entity<Power>()
                .Property(x => x.Name);
            modelBuilder.Entity<Power>()
                .Property(x => x.Display);
            modelBuilder.Entity<Power>()
                .Property(x => x.Description);
            modelBuilder.Entity<Power>()
                .Property(x => x.LongDescription);
        }
    }
}
