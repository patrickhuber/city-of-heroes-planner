using System;
using System.IO;

namespace CityOfInfo.Data.Mids
{
    public class EffectWriter
    {
        private BinaryWriter _writer;

        public EffectWriter(BinaryWriter writer)
        {
            _writer = writer;
        }

        public void Write(Effect effect)
        {
            _writer.Write(effect.PowerFullName);
            _writer.Write(effect.UniqueId);
            _writer.Write(effect.EffectClass);
            _writer.Write(effect.EffectType);
            _writer.Write(effect.DamageType);
            _writer.Write(effect.MezmorizeType);
            _writer.Write(effect.EffectModifiers);
            _writer.Write(effect.Summon);
            _writer.Write(effect.DelayedTime);
            _writer.Write(effect.Ticks);
            _writer.Write(effect.Stacking);
            _writer.Write(effect.BaseProbability);
            _writer.Write(effect.Suppression);
            _writer.Write(effect.Buffable);
            _writer.Write(effect.Resistible);
            _writer.Write(effect.SpecialCase);
            _writer.Write(effect.VariableModifiedOverride);
            _writer.Write(effect.PlayerVersusMode   );
            _writer.Write(effect.ToWho);
            _writer.Write(effect.DisplayPercentageOverride);
            _writer.Write(effect.Scale);
            _writer.Write(effect.Magnitude);
            _writer.Write(effect.Duration);
            _writer.Write(effect.AttribType);
            _writer.Write(effect.Aspect);
            _writer.Write(effect.ModifierTable);
            _writer.Write(effect.NearGround);
            _writer.Write(effect.CancelOnMiss);
            _writer.Write(effect.RequiresToHitCheck);
            _writer.Write(effect.UidClassName);
            _writer.Write(effect.IdClassName);
            _writer.Write(effect.MagnitudeExpression);
            _writer.Write(effect.Reward);
            _writer.Write(effect.EffectId);
            _writer.Write(effect.IgnoreEnhancementDiversification);
            _writer.Write(effect.Override);
            _writer.Write(effect.ProcsPerMinute);
        }
    }
}