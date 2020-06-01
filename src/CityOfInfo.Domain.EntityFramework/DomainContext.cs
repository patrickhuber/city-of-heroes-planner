using Microsoft.EntityFrameworkCore;
using System;

namespace CityOfInfo.Domain.EntityFramework
{
    public class DomainContext : DbContext
    {
        public DomainContext() { }

        public DomainContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Power> Powers { get; set; }

        public DbSet<Enhancement> Enhancements { get; set; }


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

            modelBuilder.Entity<Enhancement>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<Enhancement>()
                .Property(x => x.Id)
                .ValueGeneratedNever();
            modelBuilder.Entity<Enhancement>()
                .Property(e => e.Name);
        }
    }
}
