using Microsoft.EntityFrameworkCore;
using System;

namespace CityOfInfo.Domain.EntityFramework
{
    public class DomainContext : DbContext
    {
        public DomainContext() { }

        public DomainContext(DbContextOptions<DomainContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Archetype>()
                .HasKey(a => a.Key);
        }
        public DbSet<Archetype> Archetypes { get; set; }
    }
}
