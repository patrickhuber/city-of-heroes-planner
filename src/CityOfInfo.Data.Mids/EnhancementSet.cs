using System;
using System.Collections.Generic;
using System.Text;

namespace CityOfInfo.Data.Mids
{
    public class EnhancementSet
    {
        public string DisplayName { get; set; }
        public string ShortName { get; set; }
        public string StringId { get; set; }
        public string Description { get; set; }
        public int SetType { get; set; }
        public string Image { get; set; }
        public int MinLevel { get; set; }
        public int MaxLevel { get; set; }
        public int[] Enhancements { get; set; }
        public Bonus[] Bonuses { get; set; }
        public SpecialBonus[] SpecialBonuses { get; set; }

        public override bool Equals(object obj)
        {
            return obj is EnhancementSet set &&
                   DisplayName == set.DisplayName &&
                   ShortName == set.ShortName &&
                   StringId == set.StringId &&
                   Description == set.Description &&
                   SetType == set.SetType &&
                   Image == set.Image &&
                   MinLevel == set.MinLevel &&
                   MaxLevel == set.MaxLevel &&
                   Enhancements.EqualTo(set.Enhancements) &&
                   Bonuses.EqualTo(set.Bonuses) &&
                   SpecialBonuses.EqualTo(set.SpecialBonuses);
        }

        public override int GetHashCode()
        {
            var hashCode = -1823152004;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DisplayName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ShortName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(StringId);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            hashCode = hashCode * -1521134295 + SetType.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Image);
            hashCode = hashCode * -1521134295 + MinLevel.GetHashCode();
            hashCode = hashCode * -1521134295 + MaxLevel.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<int[]>.Default.GetHashCode(Enhancements);
            hashCode = hashCode * -1521134295 + EqualityComparer<Bonus[]>.Default.GetHashCode(Bonuses);
            hashCode = hashCode * -1521134295 + EqualityComparer<SpecialBonus[]>.Default.GetHashCode(SpecialBonuses);
            return hashCode;
        }
    }
}
