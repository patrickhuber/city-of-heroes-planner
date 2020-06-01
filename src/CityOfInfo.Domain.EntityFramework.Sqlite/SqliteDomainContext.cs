using Microsoft.EntityFrameworkCore;

namespace CityOfInfo.Domain.EntityFramework.Sqlite
{
    public class SqliteDomainContext : DomainContext
    {
        public SqliteDomainContext()
        { 
        }

        public SqliteDomainContext(DbContextOptions options) 
            : base(options)
        { }

        public SqliteDomainContext(string path)
        {
            Path = path;
        }

        public string Path { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (string.IsNullOrWhiteSpace(Path))
                optionsBuilder.UseSqlite($":memory:");
            else
                optionsBuilder.UseSqlite($"Data Source={Path}");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Power>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Power>()
                .Property(x => x.Id)
                .ValueGeneratedNever();
            modelBuilder.Entity<Power>()
                .Property(x=>x.Name);
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
