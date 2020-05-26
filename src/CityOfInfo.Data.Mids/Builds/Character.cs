using System;
using System.Collections.Generic;
using System.Text;

namespace CityOfInfo.Data.Mids.Builds
{
    /// <summary>
    /// Character represents a collection of builds and the archetype and alignment
    /// </summary>
    public class Character
    {
        public string Name { get; set; }


        /// <summary>
        /// Use qualified names in the powers and power sets?
        /// </summary>
        public bool UseQualifiedNames { get; set; }

        /// <summary>
        /// Old format for loading subpowers
        /// </summary>
        public bool UseSubpowerFields { get; set; }

        /// <summary>
        /// The character file format version
        /// </summary>
        public SchemaVersion Version { get; set; }

        /// <summary>
        /// The list of builds for this character
        /// </summary>
        public List<Build> Builds { get; set; }

        /// <summary>
        /// the archetype of the character
        /// </summary>
        public Archetype Archetype { get; set; }

        /// <summary>
        /// The character alignment
        /// </summary>
        public Alignment Alignment { get; set; }

    }
}
