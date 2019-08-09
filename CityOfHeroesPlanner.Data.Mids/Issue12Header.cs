using System;

namespace CityOfHeroesPlanner.Data.Mids
{
    public class Issue12Header
    {
        public static readonly string MarkTwoVersionHeader = "Mids' Hero Designer Database MK II";

        public string Description { get; set; }
        public float Version { get; set; }
        public DateTime Date { get; set; }
        public int Issue { get; set; }
    }
}