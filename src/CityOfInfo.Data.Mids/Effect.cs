using System.Collections.Generic;

namespace CityOfInfo.Data.Mids
{
    public class Effect
    {
        public string PowerFullName { get; set; }
        public int UniqueID { get; set; }
        public int EffectClass { get; set; }
        public int EffectType { get; set; }
        public int DamageType { get; set; }
        public int MezmorizeType { get; set; }
        public int EffectModifiers { get; set; }
        public string Summon { get; set; }
        public float DelayedTime { get; set; }
        public int Ticks { get; set; }
        public int Stacking { get; set; }
        public float BaseProbability { get; set; }
        public int Suppression { get; set; }
        public bool Buffable { get; set; }
        public bool Resistible { get; set; }
        public int SpecialCase { get; set; }
        public bool VariableModifiedOverride { get; set; }
        public int PlayerVersusMode { get; set; }
        public int ToWho { get; set; }
        public int DisplayPercentageOverride { get; set; }
        public float Scale { get; set; }
        public float Magnitude { get; set; }
        public float Duration { get; set; }
        public int AttribType { get; set; }
        public int Aspect { get; set; }
        public string ModifierTable { get; set; }
        public bool NearGround { get; set; }
        public bool CancelOnMiss { get; set; }
        public bool RequiresToHitCheck { get; set; }
        public string UIDClassName { get; set; }
        public int IDClassName { get; set; }
        public string MagnitudeExpression { get; set; }
        public string Reward { get; set; }
        public string EffectId { get; set; }
        public bool IgnoreEnhancementDiversification { get; set; }
        public string Override { get; set; }
        public float ProcsPerMinute { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Effect effect &&
                   PowerFullName == effect.PowerFullName &&
                   UniqueID == effect.UniqueID &&
                   EffectClass == effect.EffectClass &&
                   EffectType == effect.EffectType &&
                   DamageType == effect.DamageType &&
                   MezmorizeType == effect.MezmorizeType &&
                   EffectModifiers == effect.EffectModifiers &&
                   Summon == effect.Summon &&
                   DelayedTime == effect.DelayedTime &&
                   Ticks == effect.Ticks &&
                   Stacking == effect.Stacking &&
                   BaseProbability == effect.BaseProbability &&
                   Suppression == effect.Suppression &&
                   Buffable == effect.Buffable &&
                   Resistible == effect.Resistible &&
                   SpecialCase == effect.SpecialCase &&
                   VariableModifiedOverride == effect.VariableModifiedOverride &&
                   PlayerVersusMode == effect.PlayerVersusMode &&
                   ToWho == effect.ToWho &&
                   DisplayPercentageOverride == effect.DisplayPercentageOverride &&
                   Scale == effect.Scale &&
                   Magnitude == effect.Magnitude &&
                   Duration == effect.Duration &&
                   AttribType == effect.AttribType &&
                   Aspect == effect.Aspect &&
                   ModifierTable == effect.ModifierTable &&
                   NearGround == effect.NearGround &&
                   CancelOnMiss == effect.CancelOnMiss &&
                   RequiresToHitCheck == effect.RequiresToHitCheck &&
                   UIDClassName == effect.UIDClassName &&
                   IDClassName == effect.IDClassName &&
                   MagnitudeExpression == effect.MagnitudeExpression &&
                   Reward == effect.Reward &&
                   EffectId == effect.EffectId &&
                   IgnoreEnhancementDiversification == effect.IgnoreEnhancementDiversification &&
                   Override == effect.Override &&
                   ProcsPerMinute == effect.ProcsPerMinute;
        }

        public override int GetHashCode()
        {
            var hashCode = -2145328967;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PowerFullName);
            hashCode = hashCode * -1521134295 + UniqueID.GetHashCode();
            hashCode = hashCode * -1521134295 + EffectClass.GetHashCode();
            hashCode = hashCode * -1521134295 + EffectType.GetHashCode();
            hashCode = hashCode * -1521134295 + DamageType.GetHashCode();
            hashCode = hashCode * -1521134295 + MezmorizeType.GetHashCode();
            hashCode = hashCode * -1521134295 + EffectModifiers.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Summon);
            hashCode = hashCode * -1521134295 + DelayedTime.GetHashCode();
            hashCode = hashCode * -1521134295 + Ticks.GetHashCode();
            hashCode = hashCode * -1521134295 + Stacking.GetHashCode();
            hashCode = hashCode * -1521134295 + BaseProbability.GetHashCode();
            hashCode = hashCode * -1521134295 + Suppression.GetHashCode();
            hashCode = hashCode * -1521134295 + Buffable.GetHashCode();
            hashCode = hashCode * -1521134295 + Resistible.GetHashCode();
            hashCode = hashCode * -1521134295 + SpecialCase.GetHashCode();
            hashCode = hashCode * -1521134295 + VariableModifiedOverride.GetHashCode();
            hashCode = hashCode * -1521134295 + PlayerVersusMode.GetHashCode();
            hashCode = hashCode * -1521134295 + ToWho.GetHashCode();
            hashCode = hashCode * -1521134295 + DisplayPercentageOverride.GetHashCode();
            hashCode = hashCode * -1521134295 + Scale.GetHashCode();
            hashCode = hashCode * -1521134295 + Magnitude.GetHashCode();
            hashCode = hashCode * -1521134295 + Duration.GetHashCode();
            hashCode = hashCode * -1521134295 + AttribType.GetHashCode();
            hashCode = hashCode * -1521134295 + Aspect.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ModifierTable);
            hashCode = hashCode * -1521134295 + NearGround.GetHashCode();
            hashCode = hashCode * -1521134295 + CancelOnMiss.GetHashCode();
            hashCode = hashCode * -1521134295 + RequiresToHitCheck.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UIDClassName);
            hashCode = hashCode * -1521134295 + IDClassName.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(MagnitudeExpression);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Reward);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(EffectId);
            hashCode = hashCode * -1521134295 + IgnoreEnhancementDiversification.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Override);
            hashCode = hashCode * -1521134295 + ProcsPerMinute.GetHashCode();
            return hashCode;
        }
    }
}