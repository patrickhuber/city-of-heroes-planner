using System;
using System.Collections.Generic;
using System.Text;

namespace CityOfInfo.Data.Mids
{
    /// <summary>
    /// Version attempts to match the database schema version to a sematic version
    /// </summary>
    public class DatabaseVersion : SemanticVersion
    {
        public static readonly DatabaseVersion v1_0_0 = new DatabaseVersion { Major = 1, Minor = 0, Patch = 0, DbVersion = 1.0f };        

        public static readonly DatabaseVersion[] Versions = new DatabaseVersion[]
        {
            v1_0_0
        };
        internal DatabaseVersion()
        { 
        }
                
        public float DbVersion { get; internal set; }
    }
}
