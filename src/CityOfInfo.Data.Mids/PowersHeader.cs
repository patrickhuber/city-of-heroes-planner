using System;
using System.Collections.Generic;
using System.Text;

namespace CityOfInfo.Data.Mids
{
    public class PowerHeader : RecordHeader
    {
        public VersionData LevelVersion { get; set; }
        public VersionData EffectVersion { get; set; }
        public VersionData InventionOriginAssignmentVersion { get; set; }

        public override bool Equals(object obj)
        {
            return obj is PowerHeader header &&
                Count == header.Count &&
                Prefix.Equals(header.Prefix) &&
                VersionData.Equals(header.VersionData) &&   
                LevelVersion.Equals(header.LevelVersion) &&
                EffectVersion.Equals(header.EffectVersion) &&
                InventionOriginAssignmentVersion.Equals(header.InventionOriginAssignmentVersion);
        }

        public override int GetHashCode()
        {
            var hashCode = 2112121633;
            hashCode = hashCode * -1521134295 + Count.GetHashCode();
            hashCode = hashCode * -1521134295 + Prefix.GetHashCode();
            hashCode = hashCode * -1521134295 + VersionData.GetHashCode();
            hashCode = hashCode * -1521134295 + LevelVersion.GetHashCode();
            hashCode = hashCode * -1521134295 + EffectVersion.GetHashCode();
            hashCode = hashCode * -1521134295 + InventionOriginAssignmentVersion.GetHashCode();
            return hashCode;
        }
    }
}
