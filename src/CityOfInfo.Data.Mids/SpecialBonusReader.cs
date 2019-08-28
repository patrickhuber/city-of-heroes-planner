using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CityOfInfo.Data.Mids
{
    public class SpecialBonusReader
    {
        private BinaryReader _reader;
        private NamedEntityReader _entityReader;

        public SpecialBonusReader(BinaryReader reader)
        {
            _reader = reader;
            _entityReader = new NamedEntityReader(reader);
        }

        public SpecialBonus Read()
        {
            var specialBonus = new SpecialBonus();
            specialBonus.Special = _reader.ReadInt32();
            specialBonus.AlternateString = _reader.ReadString();            
            specialBonus.Entities = new NamedEntity[_reader.ReadInt32() + 1];
            for (var i = 0; i < specialBonus.Entities.Length; i++)
                specialBonus.Entities[i] = _entityReader.Read();
            return specialBonus;
        }
    }
}
