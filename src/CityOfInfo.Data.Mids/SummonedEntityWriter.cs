using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CityOfInfo.Data.Mids
{
    public class SummonedEntityWriter
    {
        private BinaryWriter _writer;

        public SummonedEntityWriter(BinaryWriter writer)
        {
            _writer = writer;
        }

        public void Write(SummonedEntity summonedEntity)
        {
            _writer.Write(summonedEntity.ID);
            _writer.Write(summonedEntity.DisplayName);
            _writer.Write(summonedEntity.EntityType);
            _writer.Write(summonedEntity.ClassName);
            _writer.Write(summonedEntity.PowerSetFullNames.Length);
            for (var i = 0; i < summonedEntity.PowerSetFullNames.Length; i++)
            {
                _writer.Write(summonedEntity.PowerSetFullNames[i]);
            }
            _writer.Write(summonedEntity.UpgradePowerFullNames.Length);
            for (var i = 0; i < summonedEntity.UpgradePowerFullNames.Length; i++)
            {
                _writer.Write(summonedEntity.UpgradePowerFullNames[i]);
            }
        }
    }
}
