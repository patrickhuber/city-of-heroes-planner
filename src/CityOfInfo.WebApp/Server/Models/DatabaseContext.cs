using CityOfInfo.WebApp.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityOfInfo.WebApp.Server.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base()
        { }

        public DatabaseContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Database> Databases { get; set; }
    }
}
