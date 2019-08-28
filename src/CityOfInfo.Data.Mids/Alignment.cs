using System;
using System.Collections.Generic;
using System.Text;

namespace CityOfInfo.Data.Mids
{
    public class Alignment
    {
        public static readonly Alignment Hero = new Alignment { Name = "Hero", Value = 0 };
        public static readonly Alignment Rogue = new Alignment { Name = "Rogue", Value = 1 };
        public static readonly Alignment Vigilante = new Alignment { Name = "Vigilante", Value = 2 };
        public static readonly Alignment Loyalist = new Alignment { Name = "Loyalist", Value = 3 };
        public static readonly Alignment Resistance = new Alignment { Name = "Resistance", Value = 4 };
        public static readonly Alignment[] Alignments = new Alignment[]
        {
            Hero,
            Rogue,
            Vigilante,
            Loyalist,
            Resistance,
        };

        public string Name { get; set; }
        public int Value { get; set; }        
    }    
}
