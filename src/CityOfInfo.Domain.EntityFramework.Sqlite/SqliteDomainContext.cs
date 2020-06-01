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
        
    }
}
