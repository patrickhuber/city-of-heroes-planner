using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CityOfInfo.Data.Mids.Builds
{
    /// <summary>
    /// Version attempts to map the schema version in the character format to a sematic version
    /// </summary>
    public class SchemaVersion : SemanticVersion
    {
        public float Version { get; set; }

        public static readonly SchemaVersion v1_0_0 = new SchemaVersion { Version = 1.0f, Major = 1, Minor = 0, Patch = 0 };
        public static readonly SchemaVersion v1_1_0 = new SchemaVersion { Version = 1.01f, Major = 1, Minor = 1, Patch = 0  };

        public static readonly SchemaVersion[] Versions = new SchemaVersion[]
        {
            v1_0_0
        };

        public static SchemaVersion Find(float schemaVersion)
        {
            SchemaVersion version = Versions.FirstOrDefault(x => x.Version == schemaVersion);
            if (version != null)
                return version;

            var decimalSchemaVersion = new decimal(schemaVersion);

            // attempt to generate a schema version
            var major = (int)decimalSchemaVersion;
            var minor = (int)((decimalSchemaVersion - major) * 100);
            var patch = 0;

            return new SchemaVersion 
            { 
                Major = major,
                Minor = minor,
                Patch = patch,
                Version = schemaVersion,
            };
        }
    }
}
