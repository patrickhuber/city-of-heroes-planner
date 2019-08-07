using System;
using System.Collections.Generic;
using System.Text;

namespace CityOfHeroesPlanner.Domain
{
    public class CharacterPower
    {
        public Power Power { get; set; }
        public Enhancement[] Slots { get; set; }
    }
}
