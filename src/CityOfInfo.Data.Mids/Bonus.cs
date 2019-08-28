using System;
using System.Collections.Generic;
using System.Text;

namespace CityOfInfo.Data.Mids
{
    public class Bonus
    {
        public int Special { get; set; }
        public string AlternateString { get; set; }
        public int PlayerVersusMode { get; set; }
        public int Slotted { get; set; }
        
        public NamedEntity[] Entities { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Bonus bonus &&
                   Special == bonus.Special &&
                   AlternateString == bonus.AlternateString &&
                   PlayerVersusMode == bonus.PlayerVersusMode &&
                   Slotted == bonus.Slotted &&
                   Entities.EqualTo(bonus.Entities);
        }

        public override int GetHashCode()
        {
            var hashCode = 1896425553;
            hashCode = hashCode * -1521134295 + Special.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(AlternateString);
            hashCode = hashCode * -1521134295 + PlayerVersusMode.GetHashCode();
            hashCode = hashCode * -1521134295 + Slotted.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<NamedEntity[]>.Default.GetHashCode(Entities);
            return hashCode;
        }
    }
}
