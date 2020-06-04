using CityOfInfo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityOfInfo.WebApp.Shared
{ 
    public class Database
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SemanticVersion SemanticVersion { get; set; }
    }
}
