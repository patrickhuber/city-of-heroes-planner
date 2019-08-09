using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CityOfHeroesPlanner.Data.Mids
{
    public class PowersHeaderReader 
    {
        private readonly BinaryReader _reader;

        public PowersHeaderReader(BinaryReader reader)
        {
            _reader = reader;
        }

        public  PowersHeader Read()
        {            
            var powersHeader = new PowersHeader();
            var versionDataReader = new VersionDataReader(_reader);
            powersHeader.Prefix = _reader.ReadString();
            powersHeader.VersionData = versionDataReader.Read();
            powersHeader.LevelVersion = versionDataReader.Read();
            powersHeader.EffectVersion = versionDataReader.Read();
            powersHeader.InventionOriginAssignmentVersion = versionDataReader.Read();
            powersHeader.Count = _reader.ReadInt32();
            return powersHeader;
        }
    }
}
