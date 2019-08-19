using System;
using System.Collections.Generic;
using System.Text;

namespace CityOfHeroesPlanner.Data.Mids
{
    public class EnhancementHeader
    {
        public string Prefix { get; set; }
        public float Version { get; set; }
        public int Count { get; set; }

        public override bool Equals(object obj)
        {
            return obj is EnhancementHeader header &&
                   Prefix == header.Prefix &&
                   Version == header.Version &&
                   Count == header.Count;
        }

        public override int GetHashCode()
        {
            var hashCode = -827011492;
            hashCode = hashCode * -1521134295 + Prefix.GetHashCode();
            hashCode = hashCode * -1521134295 + Version.GetHashCode();
            hashCode = hashCode * -1521134295 + Count.GetHashCode();
            return hashCode;
        }
    }
}
