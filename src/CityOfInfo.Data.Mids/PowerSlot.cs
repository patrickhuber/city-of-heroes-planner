using System;
using System.Collections.Generic;
using System.Text;

namespace CityOfInfo.Data.Mids
{
    // An enhanced power references a power and its enhancements
    public class PowerSlot
    {
        public Power Power { get; set; }
        public List<EnhancementSlot> EnhancementSlots { get; set; }
        public sbyte Level { get;  set; }
        public bool StatInclude { get;  set; }
        public int VariableValue { get;  set; }
        public List<SubPower> SubPowers { get;  set; }
    }
}
