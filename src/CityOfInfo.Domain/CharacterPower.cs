using System;
using System.Collections.Generic;
using System.Text;

namespace CityOfInfo.Domain
{
    public class CharacterPower
    {
        public Power Power { get; set; }
        public Enhancement[] Slots { get; set; }
    }
}
