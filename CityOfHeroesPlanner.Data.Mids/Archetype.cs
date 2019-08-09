using System;
using System.Collections.Generic;
using System.Text;

namespace CityOfHeroesPlanner.Data.Mids
{
    public class Archetype
    {
        public string DisplayName { get; set; }
        public int HitPoints { get; set; }
        public float HitPointsMax { get; set; }
        public string DescriptionLong { get; set; }
        public float ResistenceMax { get; set; }
        public string[] Origins { get; set; }
        public int ClassType { get; set; }
        public int Column { get; set; }
        public string ClassName { get; set; }
        public string DescriptionShort { get; set; }
        public string PrimaryGroup { get; set; }
        public string SecondaryGroup { get; set; }
        public bool Playable { get; set; }
        public float RechargeMax { get; set; }
        public float DamageMax { get; set; }
        public float RecoveryMax { get; set; }
        public float RegenerationMax { get; set; }
        public float RecoveryBase { get; set; }
        public float RegenerationBase { get; set; }
        public float ThreatBase { get; set; }
        public float PerceptionBase { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is Archetype archetype))
                return false;

            var fieldsEqual = 
                   DisplayName == archetype.DisplayName &&
                   HitPoints == archetype.HitPoints &&
                   HitPointsMax == archetype.HitPointsMax &&
                   DescriptionLong == archetype.DescriptionLong &&
                   ResistenceMax == archetype.ResistenceMax &&            
                   ClassType == archetype.ClassType &&
                   Column == archetype.Column &&
                   ClassName == archetype.ClassName &&
                   DescriptionShort == archetype.DescriptionShort &&
                   PrimaryGroup == archetype.PrimaryGroup &&
                   SecondaryGroup == archetype.SecondaryGroup &&
                   Playable == archetype.Playable &&
                   RechargeMax == archetype.RechargeMax &&
                   DamageMax == archetype.DamageMax &&
                   RecoveryMax == archetype.RecoveryMax &&
                   RegenerationMax == archetype.RegenerationMax &&
                   RecoveryBase == archetype.RecoveryBase &&
                   RegenerationBase == archetype.RegenerationBase &&
                   ThreatBase == archetype.ThreatBase &&
                   PerceptionBase == archetype.PerceptionBase;

            if (!fieldsEqual)
                return fieldsEqual;

            if (archetype.Origins == null)
                if (Origins == null)
                    return true;
                else
                    return false;

            if (archetype.Origins.Length != Origins.Length)
                return false;

            for (var i = 0; i < Origins.Length; i++)
                if (Origins[i] != archetype.Origins[i])
                    return false;

            return true;
        }

        public override int GetHashCode()
        {
            var hashCode = -595725116;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DisplayName);
            hashCode = hashCode * -1521134295 + HitPoints.GetHashCode();
            hashCode = hashCode * -1521134295 + HitPointsMax.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DescriptionLong);
            hashCode = hashCode * -1521134295 + ResistenceMax.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string[]>.Default.GetHashCode(Origins);
            hashCode = hashCode * -1521134295 + ClassType.GetHashCode();
            hashCode = hashCode * -1521134295 + Column.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ClassName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DescriptionShort);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PrimaryGroup);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(SecondaryGroup);
            hashCode = hashCode * -1521134295 + Playable.GetHashCode();
            hashCode = hashCode * -1521134295 + RechargeMax.GetHashCode();
            hashCode = hashCode * -1521134295 + DamageMax.GetHashCode();
            hashCode = hashCode * -1521134295 + RecoveryMax.GetHashCode();
            hashCode = hashCode * -1521134295 + RegenerationMax.GetHashCode();
            hashCode = hashCode * -1521134295 + RecoveryBase.GetHashCode();
            hashCode = hashCode * -1521134295 + RegenerationBase.GetHashCode();
            hashCode = hashCode * -1521134295 + ThreatBase.GetHashCode();
            hashCode = hashCode * -1521134295 + PerceptionBase.GetHashCode();
            return hashCode;
        }
    }
}
