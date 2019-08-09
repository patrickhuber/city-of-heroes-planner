using System.Collections.Generic;

namespace CityOfHeroesPlanner.Data.Mids
{
    public class MutuallyExclusiveGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            return obj is MutuallyExclusiveGroup group &&
                   Id == group.Id &&
                   Name == group.Name;
        }

        public override int GetHashCode()
        {
            var hashCode = -1919740922;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }
    }
}