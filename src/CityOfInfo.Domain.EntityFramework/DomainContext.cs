using Microsoft.EntityFrameworkCore;
using System;

namespace CityOfInfo.Domain.EntityFramework
{
    public class DomainContext : DbContext
    {
        public DomainContext() { }

        public DomainContext(DbContextOptions<DomainContext> options)
            : base(options) { }

        public DbSet<Power> Powers { get; set; }

        public DbSet<Enhancement> Enhancements { get; set; }
    }
}
