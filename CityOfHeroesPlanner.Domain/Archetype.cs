using System.Collections.Generic;

namespace CityOfHeroesPlanner.Domain
{
    public class Archetype
    {
        public string Key { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ShortDescription { get; set; }

        public List<PowerSet> PowerSets { get; set; }
    }
}
