using System;
using System.Collections.Generic;
using System.Text;

namespace CityOfInfo.Data.Mids
{
    public class EnhancementSlot
    {
        public int Level { get; set; }

        /// <summary>
        /// The primary enhancement slot entry
        /// </summary>
        public EnhancementSlotEntry Enhancement { get; set; }

        /// <summary>
        /// I believe this is where the alternate slot for this enhancement is stored        
        /// </summary>
        public EnhancementSlotEntry Flipped { get; set; }
    }
}
