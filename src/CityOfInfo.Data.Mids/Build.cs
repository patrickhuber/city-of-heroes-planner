using System.Collections.Generic;

namespace CityOfInfo.Data.Mids
{
    public class Build
    {
        /// <summary>
        /// The build version number
        /// </summary>
        public float Version { get; set; }

        /// <summary>
        /// Use qualified names in the powers and power sets?
        /// </summary>
        public bool UseQualifiedNames { get; set; }

        /// <summary>
        /// Old format for loading subpowers
        /// </summary>
        public bool UseOldSubpowerFields { get; set; }

        // The archetype
        public Archetype Archetype { get; set; }

        // The list of powers
        public List<PowerSet> PowerSets { get; set; }

        // The last power index
        public int LastPower { get; set; }

        // The list of chosen powers with their enhancements
        public List<EnhancedPower> EnhancedPowers { get; set; }
        public string CharacterName { get; set; }
        public int Alignment { get;  set; }
    }
}