using System;
using System.Collections.Generic;
using System.Text;

namespace CityOfInfo.Data.Mids
{
    public class SpecialBonus
    {
        public int Special { get; set; }
        public string AlternateString { get; set; }

        public NamedEntity[] Entities { get; set; }

        public override bool Equals(object obj)
        {
            return obj is SpecialBonus bonus &&
                   Special == bonus.Special &&
                   AlternateString == bonus.AlternateString &&
                   Entities.EqualTo(bonus.Entities);
        }

        public override int GetHashCode()
        {
            var hashCode = 652262346;
            hashCode = hashCode * -1521134295 + Special.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(AlternateString);
            hashCode = hashCode * -1521134295 + EqualityComparer<NamedEntity[]>.Default.GetHashCode(Entities);
            return hashCode;
        }
    }
}
