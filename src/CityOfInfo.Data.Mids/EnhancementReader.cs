using System.IO;

namespace CityOfInfo.Data.Mids
{
    public class EnhancementReader
    {
        private BinaryReader _reader;
        private EnhancementEffectReader _enhancementEffectReader;

        public EnhancementReader(BinaryReader reader)
        {
            _reader = reader;
            _enhancementEffectReader = new EnhancementEffectReader(_reader);
        }

        public Enhancement Read()
        {
            var enhancement = new Enhancement();
            enhancement.Index = _reader.ReadInt32();
            enhancement.Name = _reader.ReadString();
            enhancement.ShortName = _reader.ReadString();
            enhancement.Description = _reader.ReadString();
            enhancement.TypeId = _reader.ReadInt32();
            enhancement.SubTypeId = _reader.ReadInt32();
            enhancement.ClassIds = new int[_reader.ReadInt32() + 1];
            for (var index = 0; index < enhancement.ClassIds.Length; index++)
                enhancement.ClassIds[index] = _reader.ReadInt32();
            enhancement.Image = _reader.ReadString();
            enhancement.EnhancementSetId = _reader.ReadInt32();
            enhancement.EnhancementSetName = _reader.ReadString();
            enhancement.EffectChance = _reader.ReadSingle();
            enhancement.LevelMin = _reader.ReadInt32();
            enhancement.LevelMax = _reader.ReadInt32();
            enhancement.Unique = _reader.ReadBoolean();
            enhancement.MutuallyExclusiveId = _reader.ReadInt32();
            enhancement.BuffMode = _reader.ReadInt32();
            enhancement.Effects = new EnhancementEffect[_reader.ReadInt32() + 1];
            for (var index = 0; index < enhancement.Effects.Length; index++)
                enhancement.Effects[index] = _enhancementEffectReader.Read();
            enhancement.UniqueIdentifier = _reader.ReadString();
            enhancement.Recipe = _reader.ReadString();
            enhancement.Superior = _reader.ReadBoolean();
            return enhancement;
        }
    }
}
