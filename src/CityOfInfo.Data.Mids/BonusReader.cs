using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CityOfInfo.Data.Mids
{
    public class BonusReader
    {
        private BinaryReader _reader;
        private NamedEntityReader _entityReader;

        public BonusReader(BinaryReader reader)
        {
            _reader = reader;
            _entityReader = new NamedEntityReader(reader);
        }

        public Bonus Read()
        {
            var bonus = new Bonus();
            bonus.Special = _reader.ReadInt32();
            bonus.AlternateString = _reader.ReadString();
            bonus.PlayerVersusMode = _reader.ReadInt32();
            bonus.Slotted = _reader.ReadInt32();
            bonus.Entities = new NamedEntity[_reader.ReadInt32() + 1];
            for (var i = 0; i < bonus.Entities.Length; i++)
                bonus.Entities[i] = _entityReader.Read();
            return bonus;
        }
    }
}
