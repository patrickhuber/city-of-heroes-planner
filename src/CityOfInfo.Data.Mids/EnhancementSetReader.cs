using System.IO;

namespace CityOfInfo.Data.Mids
{
    public class EnhancementSetReader
    {
        private BinaryReader _reader;
        private BonusReader _bonusReader;
        private SpecialBonusReader _specialBonusReader;

        public EnhancementSetReader(BinaryReader reader)
        {
            _reader = reader;            
            _bonusReader = new BonusReader(reader);
            _specialBonusReader = new SpecialBonusReader(reader);
        }

        public EnhancementSet Read()
        {
            var enhancementSet = new EnhancementSet();
            enhancementSet.DisplayName = _reader.ReadString();
            enhancementSet.ShortName = _reader.ReadString();
            enhancementSet.StringId = _reader.ReadString();
            enhancementSet.Description = _reader.ReadString();
            enhancementSet.SetType = _reader.ReadInt32();
            enhancementSet.Image = _reader.ReadString();
            enhancementSet.MinLevel = _reader.ReadInt32();
            enhancementSet.MaxLevel = _reader.ReadInt32();

            enhancementSet.Enhancements = new int[_reader.ReadInt32() + 1];
            for (var i = 0; i < enhancementSet.Enhancements.Length; i++)
                enhancementSet.Enhancements[i] = _reader.ReadInt32();

            enhancementSet.Bonuses = new Bonus[_reader.ReadInt32() + 1];
            for (var i = 0; i < enhancementSet.Bonuses.Length; i++)
                enhancementSet.Bonuses[i] = _bonusReader.Read();

            enhancementSet.SpecialBonuses = new SpecialBonus[_reader.ReadInt32() + 1];
            for (var i = 0; i < enhancementSet.SpecialBonuses.Length; i++)
                enhancementSet.SpecialBonuses[i] = _specialBonusReader.Read();

            return enhancementSet;
        }
    }
}