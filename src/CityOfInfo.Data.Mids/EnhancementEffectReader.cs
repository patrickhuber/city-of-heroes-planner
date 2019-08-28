using System.IO;

namespace CityOfInfo.Data.Mids
{
    public class EnhancementEffectReader
    {
        private BinaryReader _reader;
        private EffectReader _effectReader;

        public EnhancementEffectReader(BinaryReader reader)
        {
            _reader = reader;
            _effectReader = new EffectReader(_reader);
        }

        public EnhancementEffect Read()
        {
            var enhancementEffect = new EnhancementEffect();
            enhancementEffect.Mode = _reader.ReadInt32();
            enhancementEffect.BuffMode = _reader.ReadInt32();
            enhancementEffect.ID = _reader.ReadInt32();
            enhancementEffect.SubID = _reader.ReadInt32();
            enhancementEffect.Schedule = _reader.ReadInt32();
            enhancementEffect.Multiplier = _reader.ReadSingle();

            var hasEffect = _reader.ReadBoolean();
            if (hasEffect)            
                enhancementEffect.Effect = _effectReader.Read();

            return enhancementEffect;
        }
    }
}