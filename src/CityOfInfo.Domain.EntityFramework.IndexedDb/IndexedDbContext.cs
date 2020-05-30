using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityOfInfo.Domain.EntityFramework.IndexedDb
{
    public class IndexedDbContext : DomainContext
    {
        public IndexedDbContext()
            : base()
        { 
        }

        public IndexedDbContext(DbContextOptions<IndexedDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

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
