using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CityOfInfo.Data.Mids
{
    public class EnhancementEffectWriter
    {
        private BinaryWriter _writer;
        private EffectWriter _effectWriter;

        public EnhancementEffectWriter(BinaryWriter writer)
        {
            _writer = writer;
            _effectWriter = new EffectWriter(_writer);
        }

        public void Write(EnhancementEffect enhancementEffect)
        {
            _writer.Write(enhancementEffect.Mode);
            _writer.Write(enhancementEffect.BuffMode);
            _writer.Write(enhancementEffect.Id);
            _writer.Write(enhancementEffect.SubId);
            _writer.Write(enhancementEffect.Schedule);
            _writer.Write(enhancementEffect.Multiplier);

            var hasEffect = enhancementEffect.Effect != null;
            _writer.Write(hasEffect);
            if (hasEffect)
                _effectWriter.Write(enhancementEffect.Effect);
        }
    }
}
