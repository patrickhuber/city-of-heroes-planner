using System.Collections.Generic;

namespace CityOfInfo.Data.Mids
{
    public class PowerSet
    {
        public string DisplayName { get; set; }
        public int Archetype { get; set; }
        public int SetType { get; set; }
        public string ImageName { get; set; }
        public string FullName { get; set; }
        public string SetName { get; set; }
        public string Description { get; set; }
        public string SubName { get; set; }
        public string ClassType { get; set; }
        public string TrunkSet { get; set; }
        public string LinkSecondary { get; set; }
        public MutuallyExclusiveGroup[] MutuallyExclusiveGroups { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is PowerSet powerset))            
                return false;

            var fieldsEqual = DisplayName == powerset.DisplayName &&
                   Archetype == powerset.Archetype &&
                   SetType == powerset.SetType &&
                   ImageName == powerset.ImageName &&
                   FullName == powerset.FullName &&
                   SetName == powerset.SetName &&
                   Description == powerset.Description &&
                   SubName == powerset.SubName &&
                   ClassType == powerset.ClassType &&
                   TrunkSet == powerset.TrunkSet &&
                   LinkSecondary == powerset.LinkSecondary;
            if (!fieldsEqual)
                return fieldsEqual;

            if (powerset.MutuallyExclusiveGroups == null)
                if (MutuallyExclusiveGroups == null)
                    return true;
                else
                    return false;
            if (MutuallyExclusiveGroups == null)
                return false;

            if (powerset.MutuallyExclusiveGroups.Length != MutuallyExclusiveGroups.Length)
                return false;

            for (var i = 0; i < powerset.MutuallyExclusiveGroups.Length; i++)
                if (!powerset.MutuallyExclusiveGroups[i].Equals(MutuallyExclusiveGroups[i]))
                    return false;

            return true;
        }

        public override int GetHashCode()
        {
            var hashCode = 1316660549;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DisplayName);
            hashCode = hashCode * -1521134295 + Archetype.GetHashCode();
            hashCode = hashCode * -1521134295 + SetType.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ImageName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FullName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(SetName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(SubName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ClassType);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TrunkSet);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LinkSecondary);
            hashCode = hashCode * -1521134295 + EqualityComparer<MutuallyExclusiveGroup[]>.Default.GetHashCode(MutuallyExclusiveGroups);
            return hashCode;
        }
    }
}