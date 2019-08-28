using System.Collections.Generic;

namespace CityOfInfo.Data.Mids
{
    public class Enhancement
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public int TypeId { get; set; }
        public int SubTypeId { get; set; }
        public int[] ClassIds { get; set; }
        public int EnhancementSetId { get; set; }
        public string EnhancementSetName { get; set; }
        public string Image { get; set; }
        public float EffectChance { get; set; }
        public int LevelMin { get; set; }
        public int LevelMax { get; set; }
        public bool Unique { get; set; }
        public int MutuallyExclusiveId { get; set; }
        public int BuffMode { get; set; }
        public EnhancementEffect[] Effects { get; set; }
        public string UniqueIdentifier { get; set; }
        public string Recipe { get; set; }
        public bool Superior { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Enhancement enhancement &&
                   Index == enhancement.Index &&
                   Name == enhancement.Name &&
                   ShortName == enhancement.ShortName &&
                   Description == enhancement.Description &&
                   TypeId == enhancement.TypeId &&
                   SubTypeId == enhancement.SubTypeId &&
                   ClassIds.EqualTo(enhancement.ClassIds) &&
                   EnhancementSetId == enhancement.EnhancementSetId &&
                   EnhancementSetName == enhancement.EnhancementSetName &&
                   Image == enhancement.Image &&
                   EffectChance == enhancement.EffectChance &&
                   LevelMin == enhancement.LevelMin &&
                   LevelMax == enhancement.LevelMax &&
                   Unique == enhancement.Unique &&
                   MutuallyExclusiveId == enhancement.MutuallyExclusiveId &&
                   BuffMode == enhancement.BuffMode &&
                   Effects.EqualTo(enhancement.Effects) &&
                   UniqueIdentifier == enhancement.UniqueIdentifier &&
                   Recipe == enhancement.Recipe &&
                   Superior == enhancement.Superior;
        }

        public override int GetHashCode()
        {
            var hashCode = 1745360142;
            hashCode = hashCode * -1521134295 + Index.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ShortName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            hashCode = hashCode * -1521134295 + TypeId.GetHashCode();
            hashCode = hashCode * -1521134295 + SubTypeId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<int[]>.Default.GetHashCode(ClassIds);
            hashCode = hashCode * -1521134295 + EnhancementSetId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(EnhancementSetName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Image);
            hashCode = hashCode * -1521134295 + EffectChance.GetHashCode();
            hashCode = hashCode * -1521134295 + LevelMin.GetHashCode();
            hashCode = hashCode * -1521134295 + LevelMax.GetHashCode();
            hashCode = hashCode * -1521134295 + Unique.GetHashCode();
            hashCode = hashCode * -1521134295 + MutuallyExclusiveId.GetHashCode();
            hashCode = hashCode * -1521134295 + BuffMode.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<EnhancementEffect[]>.Default.GetHashCode(Effects);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UniqueIdentifier);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Recipe);
            hashCode = hashCode * -1521134295 + Superior.GetHashCode();
            return hashCode;
        }
    }
}