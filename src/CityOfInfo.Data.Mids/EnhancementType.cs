using System;
using System.Collections.Generic;
using System.Text;

namespace CityOfInfo.Data.Mids
{
    public class EnhancementType
    {
        public static readonly EnhancementType None = new EnhancementType { ID = 0, Name = "None" };
        public static readonly EnhancementType Normal = new EnhancementType { ID = 1, Name = "Normal" };
        public static readonly EnhancementType InventionOrigin = new EnhancementType { ID = 2, Name = "InventionOrigin" };
        public static readonly EnhancementType SpecialOrigin = new EnhancementType { ID = 3, Name = "SpecialOrigin" };
        public static readonly EnhancementType SetOrigin = new EnhancementType { ID = 4, Name = "SetOrigin" };

        public static readonly EnhancementType[] EnhancementTypes =
        {
            None,
            Normal,
            InventionOrigin,
            SpecialOrigin,
            SetOrigin,
        };

        public int ID { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        
    }
}
