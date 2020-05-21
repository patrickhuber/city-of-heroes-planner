using System;
using System.Collections.Generic;
using System.Text;

namespace CityOfInfo.Data.Mids
{
    public class EnhancementType
    {
        public static readonly EnhancementType None = new EnhancementType { Id = 0, Name = "None" };
        public static readonly EnhancementType Normal = new EnhancementType { Id = 1, Name = "Normal" };
        public static readonly EnhancementType InventionOrigin = new EnhancementType { Id = 2, Name = "InventionOrigin" };
        public static readonly EnhancementType SpecialOrigin = new EnhancementType { Id = 3, Name = "SpecialOrigin" };
        public static readonly EnhancementType SetOrigin = new EnhancementType { Id = 4, Name = "SetOrigin" };

        public static readonly EnhancementType[] EnhancementTypes =
        {
            None,
            Normal,
            InventionOrigin,
            SpecialOrigin,
            SetOrigin,
        };

        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        
    }
}
