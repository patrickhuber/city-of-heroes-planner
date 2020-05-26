using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CityOfInfo.Data.Mids
{
    public class Alignment
    {
        public static readonly Alignment Hero = new Alignment { Name = "Hero", Id = 0 };
        public static readonly Alignment Rogue = new Alignment { Name = "Rogue", Id = 1 };
        public static readonly Alignment Vigilante = new Alignment { Name = "Vigilante", Id = 2 };
        public static readonly Alignment Loyalist = new Alignment { Name = "Loyalist", Id = 3 };
        public static readonly Alignment Resistance = new Alignment { Name = "Resistance", Id = 4 };
        
        public static readonly Alignment[] Alignments = new Alignment[]
        {
            Hero,
            Rogue,
            Vigilante,
            Loyalist,
            Resistance,
        };

        public string Name { get; set; }
        public int Id { get; set; }

        public static Alignment Unknown(int id, string name)
        {
            var alignment = new Alignment
            { 
                Id = id,
                Name = name,
            };

            if (id <= 0)            
                alignment.Id = 0;
            
            if (string.IsNullOrWhiteSpace(name))            
                alignment.Name = "Unknown";

            return alignment;
        }

        public static Alignment Find(int id, string name)
        {
            var alignment = Alignments.FirstOrDefault(
                x => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)
                || x.Id == id);
            if (alignment != null)
                return alignment;
            return Unknown(id, name);
        }
    }    
}
