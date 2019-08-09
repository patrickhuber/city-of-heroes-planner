using System;
using System.Collections.Generic;
using System.Text;

namespace CityOfHeroesPlanner.Data.Mids
{
    public class RecordHeader
    {
        public string Prefix { get; set; }
        public VersionData VersionData { get; set; }
        public int Count { get; set; }
    }
}
