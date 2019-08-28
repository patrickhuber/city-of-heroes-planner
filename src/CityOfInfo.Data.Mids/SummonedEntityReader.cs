using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CityOfInfo.Data.Mids
{
    public class SummonedEntityReader
    {
        private BinaryReader _reader;

        public SummonedEntityReader(BinaryReader reader)
        {
            _reader = reader;
        }

        public SummonedEntity Read()
        {
            var summonedEntity = new SummonedEntity();
            summonedEntity.ID = _reader.ReadString();
            summonedEntity.DisplayName = _reader.ReadString();
            summonedEntity.EntityType = _reader.ReadInt32();
            summonedEntity.ClassName = _reader.ReadString();
            summonedEntity.PowerSetFullNames = new string[_reader.ReadInt32()];
            for (var i = 0; i < summonedEntity.PowerSetFullNames.Length; i++)
                summonedEntity.PowerSetFullNames[i] = _reader.ReadString();
            summonedEntity.UpgradePowerFullNames = new string[_reader.ReadInt32()];
            for (var i = 0; i < summonedEntity.UpgradePowerFullNames.Length; i++)
                summonedEntity.UpgradePowerFullNames[i] = _reader.ReadString();
            return summonedEntity;
        }
    }
}
