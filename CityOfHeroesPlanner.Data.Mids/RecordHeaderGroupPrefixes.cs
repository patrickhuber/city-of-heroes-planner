using System;
using System.Collections.Generic;
using System.Text;

namespace CityOfHeroesPlanner.Data.Mids
{
    public class RecordHeaderGroupPrefixes
    {
        private static readonly string _prefix = "BEGIN:";
        public static readonly string Archetypes = _prefix + "ARCHETYPES";
        public static readonly string Powersets = _prefix + "POWERSETS";
        public static readonly string Powers = _prefix + "POWERS";
    }
}
