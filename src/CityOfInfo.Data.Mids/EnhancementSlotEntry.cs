using System;
using System.Collections.Generic;
using System.Text;

namespace CityOfInfo.Data.Mids
{
    public class EnhancementSlotEntry
    {
        public Enhancement Enhancement { get; set; }
        public sbyte Level { get; internal set; }
        public List<sbyte> SlotData { get; internal set; }
    }
}
