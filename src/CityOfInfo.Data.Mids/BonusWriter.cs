using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CityOfInfo.Data.Mids
{
    public class BonusWriter
    {
        private BinaryWriter _writer;
        private NamedEntityWriter _entityWriter;

        public BonusWriter(BinaryWriter writer)
        {
            _writer = writer;
            _entityWriter = new NamedEntityWriter(writer);
        }

        public void Write(Bonus bonus)
        {
            _writer.Write(bonus.Special);
            _writer.Write(bonus.AlternateString);
            _writer.Write(bonus.PlayerVersusMode);
            _writer.Write(bonus.Slotted);
            _writer.Write(bonus.Entities.Length - 1);
            for (var i = 0; i < bonus.Entities.Length; i++)
                _entityWriter.Write(bonus.Entities[i]);
        }
    }
}
