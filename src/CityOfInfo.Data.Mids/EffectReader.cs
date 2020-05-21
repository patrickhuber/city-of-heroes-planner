using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CityOfInfo.Data.Mids
{
    public class EffectReader
    {
        private readonly BinaryReader _reader;

        public EffectReader(BinaryReader reader)
        {
            _reader = reader;
        }

        public Effect Read()
        {
            Effect effect = new Effect();
            effect.PowerFullName = _reader.ReadString();
            effect.UniqueId = _reader.ReadInt32();
            effect.EffectClass = _reader.ReadInt32();
            effect.EffectType = _reader.ReadInt32();
            effect.DamageType = _reader.ReadInt32();
            effect.MezmorizeType = _reader.ReadInt32();
            effect.EffectModifiers = _reader.ReadInt32();
            effect.Summon = _reader.ReadString();
            effect.DelayedTime = _reader.ReadSingle();
            effect.Ticks = _reader.ReadInt32();
            effect.Stacking = _reader.ReadInt32();
            effect.BaseProbability = _reader.ReadSingle();
            effect.Suppression = _reader.ReadInt32();
            effect.Buffable = _reader.ReadBoolean();
            effect.Resistible = _reader.ReadBoolean();
            effect.SpecialCase = _reader.ReadInt32();
            effect.VariableModifiedOverride = _reader.ReadBoolean();
            effect.PlayerVersusMode = _reader.ReadInt32();
            effect.ToWho = _reader.ReadInt32();
            effect.DisplayPercentageOverride = _reader.ReadInt32();
            effect.Scale = _reader.ReadSingle();
            effect.Magnitude = _reader.ReadSingle();
            effect.Duration = _reader.ReadSingle();
            effect.AttribType = _reader.ReadInt32();
            effect.Aspect = _reader.ReadInt32();
            effect.ModifierTable = _reader.ReadString();            
            effect.NearGround = _reader.ReadBoolean();
            effect.CancelOnMiss = _reader.ReadBoolean();
            effect.RequiresToHitCheck = _reader.ReadBoolean();
            effect.UidClassName = _reader.ReadString();
            effect.IdClassName = _reader.ReadInt32();
            effect.MagnitudeExpression = _reader.ReadString();
            effect.Reward = _reader.ReadString();
            effect.EffectId = _reader.ReadString();
            effect.IgnoreEnhancementDiversification = _reader.ReadBoolean();
            effect.Override = _reader.ReadString();
            effect.ProcsPerMinute = _reader.ReadSingle();
            return effect;
        }
    }
}
