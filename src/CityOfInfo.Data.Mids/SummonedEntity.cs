using System;
using System.Collections.Generic;
using System.Text;

namespace CityOfInfo.Data.Mids
{
    public class SummonedEntity
    {
        public string ID { get; set; }
        public string DisplayName { get; set; }
        public int EntityType { get; set; }
        public string ClassName { get; set; }
        public string[] PowerSetFullNames { get; set; }
        public string[] UpgradePowerFullNames { get; set; }

        public override bool Equals(object obj)
        {
            return obj is SummonedEntity entity &&
                   ID == entity.ID &&
                   DisplayName == entity.DisplayName &&
                   EntityType == entity.EntityType &&
                   ClassName == entity.ClassName &&
                   PowerSetFullNames.EqualTo(entity.PowerSetFullNames) &&
                   UpgradePowerFullNames.EqualTo(entity.UpgradePowerFullNames);
        }

        public override int GetHashCode()
        {
            var hashCode = 1022390368;
            hashCode = hashCode * -1521134295 + ID.GetHashCode();
            hashCode = hashCode * -1521134295 + DisplayName.GetHashCode();
            hashCode = hashCode * -1521134295 + EntityType.GetHashCode();
            hashCode = hashCode * -1521134295 + ClassName.GetHashCode();
            return hashCode;
        }
    }
}
