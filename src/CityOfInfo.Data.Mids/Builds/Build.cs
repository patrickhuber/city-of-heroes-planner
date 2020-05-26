using System.Collections.Generic;

namespace CityOfInfo.Data.Mids.Builds
{
    public class Build
    {   // The list of powers
        public List<PowerSet> PowerSets { get; set; }

        // The last power index
        public int LastPower { get; set; }

        // The list of chosen powers with their enhancements
        public List<PowerSlot> PowerSlots { get; set; }        
    }
}