using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CityOfInfo.Data.Mids
{
    public class PowerHeaderReader 
    {
        private readonly BinaryReader _reader;

        public PowerHeaderReader(BinaryReader reader)
        {
            _reader = reader;
        }

        public  PowerHeader Read()
        {            
            var powersHeader = new PowerHeader();
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
