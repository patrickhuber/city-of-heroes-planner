using System.Collections.Generic;

namespace CityOfInfo.Data.Mids
{
    public class Requirement
    {
        public string[] ClassNames { get; set; }
        public string[] ClassNamesNot { get; set; }
        public string[][] PowerIDs { get; set; }
        public string[][] PowerIDsNot { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Requirement requirement &&
                ClassNames.EqualTo(requirement.ClassNames) &&
                ClassNamesNot.EqualTo(requirement.ClassNamesNot) &&
                PowerIDs.EqualTo(requirement.PowerIDs) &&
                PowerIDsNot.EqualTo(requirement.PowerIDsNot);
        }

        public override int GetHashCode()
        {
            var hashCode = -1790108712;
            hashCode = hashCode * -1521134295 + EqualityComparer<string[]>.Default.GetHashCode(ClassNames);
            hashCode = hashCode * -1521134295 + EqualityComparer<string[]>.Default.GetHashCode(ClassNamesNot);
            hashCode = hashCode * -1521134295 + EqualityComparer<string[][]>.Default.GetHashCode(PowerIDs);
            hashCode = hashCode * -1521134295 + EqualityComparer<string[][]>.Default.GetHashCode(PowerIDsNot);
            return hashCode;
        }
    }
}