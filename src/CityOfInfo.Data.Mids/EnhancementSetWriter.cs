using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CityOfInfo.Data.Mids
{
    public class EnhancementSetWriter
    {
        private BinaryWriter _writer;
        private SpecialBonusWriter _specialBonusWriter;
        private BonusWriter _bonusWriter;
        
        public EnhancementSetWriter(BinaryWriter writer)
        {
            _writer = writer;
            _specialBonusWriter = new SpecialBonusWriter(writer);
            _bonusWriter = new BonusWriter(writer);
        }

        public void Write(EnhancementSet enhancementSet)
        {
            _writer.Write(enhancementSet.DisplayName);
            _writer.Write(enhancementSet.ShortName);
            _writer.Write(enhancementSet.StringId);
            _writer.Write(enhancementSet.Description);
            _writer.Write(enhancementSet.SetType);
            _writer.Write(enhancementSet.Image);
            _writer.Write(enhancementSet.MinLevel);
            _writer.Write(enhancementSet.MaxLevel);

            _writer.Write(enhancementSet.Enhancements.Length - 1);
            for (var i = 0; i < enhancementSet.Enhancements.Length; i++)
                _writer.Write(enhancementSet.Enhancements[i]);

            _writer.Write(enhancementSet.Bonuses.Length - 1);
            for (var i = 0; i < enhancementSet.Bonuses.Length; i++)
                _bonusWriter.Write(enhancementSet.Bonuses[i]);

            _writer.Write(enhancementSet.SpecialBonuses.Length - 1);
            for (var i = 0; i < enhancementSet.SpecialBonuses.Length; i++)
                _specialBonusWriter.Write(enhancementSet.SpecialBonuses[i]);
        }
    }
}
