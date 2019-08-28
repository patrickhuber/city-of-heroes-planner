using System;
using System.IO;

namespace CityOfInfo.Data.Mids
{
    public class EnhancementWriter
    {
        private BinaryWriter _writer;
        private EnhancementEffectWriter _enhancementEffectWriter;

        public EnhancementWriter(BinaryWriter writer)
        {
            _writer = writer;
            _enhancementEffectWriter = new EnhancementEffectWriter(writer);
        }

        public void Write(Enhancement enhancement)
        {
            _writer.Write(enhancement.Index);
            _writer.Write(enhancement.Name);
            _writer.Write(enhancement.ShortName);
            _writer.Write(enhancement.Description);
            _writer.Write(enhancement.TypeId);
            _writer.Write(enhancement.SubTypeId);
            _writer.Write(enhancement.ClassIds.Length - 1);
            for (int index = 0; index < enhancement.ClassIds.Length; ++index)
                _writer.Write(enhancement.ClassIds[index]);
            _writer.Write(enhancement.Image);
            _writer.Write(enhancement.EnhancementSetId);
            _writer.Write(enhancement.EnhancementSetName);
            _writer.Write(enhancement.EffectChance);
            _writer.Write(enhancement.LevelMin);
            _writer.Write(enhancement.LevelMax);
            _writer.Write(enhancement.Unique);
            _writer.Write(enhancement.MutuallyExclusiveId);
            _writer.Write(enhancement.BuffMode);
            _writer.Write(enhancement.Effects.Length - 1);
            for (int index = 0; index < enhancement.Effects.Length; ++index)
            {
                _enhancementEffectWriter.Write(enhancement.Effects[index]);
            }
            _writer.Write(enhancement.UniqueIdentifier);
            _writer.Write(enhancement.Recipe);
            _writer.Write(enhancement.Superior);
        }
    }
}
