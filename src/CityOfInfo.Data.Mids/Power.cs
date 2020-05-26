using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CityOfInfo.Data.Mids
{
    public class Power
    {
        public int Index { get; set; }
        public string FullName { get; set; }
        public string GroupName { get; set; }
        public string SetName { get; set; }
        public string Name { get; set; }
        public string Display { get; set; }
        public int Available { get; set; }
        public Requirement Requirement {get;set;}
        public int ModesRequired { get; set; }
        public int ModesDisallowed { get; set; }
        public int PowerType { get; set; }
        public float Accuracy { get; set; }
        public int AttackTypes { get; set; }
        public string[] GroupMemberships { get; set; }
        public int EntitiesAffected { get; set; }
        public int EntitiesAutoHit { get; set; }
        public int Target { get; set; }
        public bool TargetLineOfSight { get; set; }
        public float Range { get; set; }
        public int TargetSecondary { get; set; }
        public float RangeSecondary { get; set; }
        public float EnduranceCost { get; set; }
        public float InterruptTime { get; set; }
        public float CastTime { get; set; }
        public float RechargeTime { get; set; }
        public float BaseRechargeTime { get; set; }
        public float ActivatePeriod { get; set; }
        public int EffectArea { get; set; }
        public float Radius { get; set; }
        public int Arc { get; set; }
        public int MaxTargets { get; set; }
        public string MaxBoosts { get; set; }
        public int CastFlags { get; set; }
        public int ArtificalIntelligenceReport { get; set; }
        public int NumberOfCharges { get; set; }
        public int UsageTime { get; set; }
        public int LifeTime { get; set; }
        public int LifeTimeInGame { get; set; }
        public int NumberAllowed { get; set; }
        public bool DoNotSave { get; set; }
        public string[] BoostsAllowed { get; set; }
        public bool CastThroughHold { get; set; }
        public bool IgnoreStrength { get; set; }
        public string DescriptionShort { get; set; }
        public string DescriptionLong { get; set; }
        public int[] Enhancements { get; set; }
        public int[] SetTypes { get; set; }
        public bool ClickBuff { get; set; }
        public bool AlwaysToggle { get; set; }
        public int Level { get; set; }
        public bool AllowFrontLoading { get; set; }
        public bool VariableEnabled { get; set; }
        public string VariableName { get; set; }
        public int VariableMin { get; set; }
        public int VariableMax { get; set; }
        public string[] SubPowers { get; set; }
        public int[] IgnoreEnhancements { get; set; }
        public int[] IgnoreBuffs { get; set; }
        public bool SkipMax { get; set; }
        public int DisplayLocation { get; set; }
        public bool MutuallyExclusiveAuto { get; set; }
        public bool MutuallyExclusiveIgnore { get; set; }
        public bool AbsorbSummonEffects { get; set; }
        public bool AbsorbSummonAttributes { get; set; }
        public bool ShowSummonAnyway { get; set; }
        public bool NeverAutoUpdate { get; set; }
        public bool NeverAutoUpdateRequirements { get; set; }
        public bool IncludeFlag { get; set; }
        public string ForcedClass { get; set; }
        public bool SortOverride { get; set; }
        public bool BoostBoostable { get; set; }
        public bool BoostUsePlayerLevel { get; set; }
        public Effect[] Effects { get; set; }
        public bool HiddenPower { get; set; }
        
        public override bool Equals(object obj)
        {
            return obj is Power power &&
                   Index == power.Index &&
                   FullName == power.FullName &&
                   GroupName == power.GroupName &&
                   SetName == power.SetName &&
                   Name == power.Name &&
                   Display == power.Display &&
                   Available == power.Available &&
                   ModesRequired == power.ModesRequired &&
                   ModesDisallowed == power.ModesDisallowed &&
                   PowerType == power.PowerType &&
                   Accuracy == power.Accuracy &&
                   AttackTypes == power.AttackTypes &&
                   EntitiesAffected == power.EntitiesAffected &&
                   EntitiesAutoHit == power.EntitiesAutoHit &&
                   Target == power.Target &&
                   TargetLineOfSight == power.TargetLineOfSight &&
                   Range == power.Range &&
                   TargetSecondary == power.TargetSecondary &&
                   RangeSecondary == power.RangeSecondary &&
                   EnduranceCost == power.EnduranceCost &&
                   InterruptTime == power.InterruptTime &&
                   CastTime == power.CastTime &&
                   RechargeTime == power.RechargeTime &&
                   BaseRechargeTime == power.BaseRechargeTime &&
                   ActivatePeriod == power.ActivatePeriod &&
                   EffectArea == power.EffectArea &&
                   Radius == power.Radius &&
                   Arc == power.Arc &&
                   MaxTargets == power.MaxTargets &&
                   MaxBoosts == power.MaxBoosts &&
                   CastFlags == power.CastFlags &&
                   ArtificalIntelligenceReport == power.ArtificalIntelligenceReport &&
                   NumberOfCharges == power.NumberOfCharges &&
                   UsageTime == power.UsageTime &&
                   LifeTime == power.LifeTime &&
                   LifeTimeInGame == power.LifeTimeInGame &&
                   NumberAllowed == power.NumberAllowed &&
                   DoNotSave == power.DoNotSave &&
                   CastThroughHold == power.CastThroughHold &&
                   IgnoreStrength == power.IgnoreStrength &&
                   DescriptionShort == power.DescriptionShort &&
                   DescriptionLong == power.DescriptionLong &&
                   ClickBuff == power.ClickBuff &&
                   AlwaysToggle == power.AlwaysToggle &&
                   Level == power.Level &&
                   AllowFrontLoading == power.AllowFrontLoading &&
                   VariableEnabled == power.VariableEnabled &&
                   VariableName == power.VariableName &&
                   VariableMin == power.VariableMin &&
                   VariableMax == power.VariableMax &&
                   SkipMax == power.SkipMax &&
                   DisplayLocation == power.DisplayLocation &&
                   MutuallyExclusiveAuto == power.MutuallyExclusiveAuto &&
                   MutuallyExclusiveIgnore == power.MutuallyExclusiveIgnore &&
                   AbsorbSummonEffects == power.AbsorbSummonEffects &&
                   AbsorbSummonAttributes == power.AbsorbSummonAttributes &&
                   ShowSummonAnyway == power.ShowSummonAnyway &&
                   NeverAutoUpdate == power.NeverAutoUpdate &&
                   NeverAutoUpdateRequirements == power.NeverAutoUpdateRequirements &&
                   IncludeFlag == power.IncludeFlag &&
                   ForcedClass == power.ForcedClass &&
                   SortOverride == power.SortOverride &&
                   BoostBoostable == power.BoostBoostable &&
                   BoostUsePlayerLevel == power.BoostUsePlayerLevel &&
                   HiddenPower == power.HiddenPower &&
                   Equal(GroupMemberships, power.GroupMemberships) &&
                   Equal(BoostsAllowed, power.BoostsAllowed) &&
                   Equal(SetTypes, power.SetTypes) &&
                   Equal(SubPowers, power.SubPowers) &&
                   Equal(IgnoreEnhancements, power.IgnoreEnhancements) &&
                   Equal(IgnoreBuffs, power.IgnoreBuffs) &&
                   Equal(Effects, power.Effects) &&
                   Equal(Requirement, power.Requirement);
        }

        private static bool Equal<T>(T left, T right)
        {
            if (left == null && right == null)
                return true;
            if (left == null || right == null)
                return false;
            return left.Equals(right);
        }

        private static bool Equal<T>(T[] first, T[] second)
        {
            if (first == null)
                if (second == null)
                    return true;
                else
                    return false;

            if (second == null)
                return false;

            if (first.Length != second.Length)
                return false;
            for (var i = 0; i < first.Length; i++)
                if (!first[i].Equals(second[i]))
                    return false;
            return true;
        }

        public override int GetHashCode()
        {
            var hashCode = -1002157333;
            hashCode = hashCode * -1521134295 + Index.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FullName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(GroupName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(SetName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Display);
            hashCode = hashCode * -1521134295 + Available.GetHashCode();
            hashCode = hashCode * -1521134295 + ModesRequired.GetHashCode();
            hashCode = hashCode * -1521134295 + ModesDisallowed.GetHashCode();
            hashCode = hashCode * -1521134295 + PowerType.GetHashCode();
            hashCode = hashCode * -1521134295 + Accuracy.GetHashCode();
            hashCode = hashCode * -1521134295 + AttackTypes.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string[]>.Default.GetHashCode(GroupMemberships);
            hashCode = hashCode * -1521134295 + EntitiesAffected.GetHashCode();
            hashCode = hashCode * -1521134295 + EntitiesAutoHit.GetHashCode();
            hashCode = hashCode * -1521134295 + Target.GetHashCode();
            hashCode = hashCode * -1521134295 + TargetLineOfSight.GetHashCode();
            hashCode = hashCode * -1521134295 + Range.GetHashCode();
            hashCode = hashCode * -1521134295 + TargetSecondary.GetHashCode();
            hashCode = hashCode * -1521134295 + RangeSecondary.GetHashCode();
            hashCode = hashCode * -1521134295 + EnduranceCost.GetHashCode();
            hashCode = hashCode * -1521134295 + InterruptTime.GetHashCode();
            hashCode = hashCode * -1521134295 + CastTime.GetHashCode();
            hashCode = hashCode * -1521134295 + RechargeTime.GetHashCode();
            hashCode = hashCode * -1521134295 + BaseRechargeTime.GetHashCode();
            hashCode = hashCode * -1521134295 + ActivatePeriod.GetHashCode();
            hashCode = hashCode * -1521134295 + EffectArea.GetHashCode();
            hashCode = hashCode * -1521134295 + Radius.GetHashCode();
            hashCode = hashCode * -1521134295 + Arc.GetHashCode();
            hashCode = hashCode * -1521134295 + MaxTargets.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(MaxBoosts);
            hashCode = hashCode * -1521134295 + CastFlags.GetHashCode();
            hashCode = hashCode * -1521134295 + ArtificalIntelligenceReport.GetHashCode();
            hashCode = hashCode * -1521134295 + NumberOfCharges.GetHashCode();
            hashCode = hashCode * -1521134295 + UsageTime.GetHashCode();
            hashCode = hashCode * -1521134295 + LifeTime.GetHashCode();
            hashCode = hashCode * -1521134295 + LifeTimeInGame.GetHashCode();
            hashCode = hashCode * -1521134295 + NumberAllowed.GetHashCode();
            hashCode = hashCode * -1521134295 + DoNotSave.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string[]>.Default.GetHashCode(BoostsAllowed);
            hashCode = hashCode * -1521134295 + CastThroughHold.GetHashCode();
            hashCode = hashCode * -1521134295 + IgnoreStrength.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DescriptionShort);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DescriptionLong);
            hashCode = hashCode * -1521134295 + EqualityComparer<int[]>.Default.GetHashCode(SetTypes);
            hashCode = hashCode * -1521134295 + ClickBuff.GetHashCode();
            hashCode = hashCode * -1521134295 + AlwaysToggle.GetHashCode();
            hashCode = hashCode * -1521134295 + Level.GetHashCode();
            hashCode = hashCode * -1521134295 + AllowFrontLoading.GetHashCode();
            hashCode = hashCode * -1521134295 + VariableEnabled.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(VariableName);
            hashCode = hashCode * -1521134295 + VariableMin.GetHashCode();
            hashCode = hashCode * -1521134295 + VariableMax.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string[]>.Default.GetHashCode(SubPowers);
            hashCode = hashCode * -1521134295 + EqualityComparer<int[]>.Default.GetHashCode(IgnoreEnhancements);
            hashCode = hashCode * -1521134295 + EqualityComparer<int[]>.Default.GetHashCode(IgnoreBuffs);
            hashCode = hashCode * -1521134295 + SkipMax.GetHashCode();
            hashCode = hashCode * -1521134295 + DisplayLocation.GetHashCode();
            hashCode = hashCode * -1521134295 + MutuallyExclusiveAuto.GetHashCode();
            hashCode = hashCode * -1521134295 + MutuallyExclusiveIgnore.GetHashCode();
            hashCode = hashCode * -1521134295 + AbsorbSummonEffects.GetHashCode();
            hashCode = hashCode * -1521134295 + AbsorbSummonAttributes.GetHashCode();
            hashCode = hashCode * -1521134295 + ShowSummonAnyway.GetHashCode();
            hashCode = hashCode * -1521134295 + NeverAutoUpdate.GetHashCode();
            hashCode = hashCode * -1521134295 + NeverAutoUpdateRequirements.GetHashCode();
            hashCode = hashCode * -1521134295 + IncludeFlag.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ForcedClass);
            hashCode = hashCode * -1521134295 + SortOverride.GetHashCode();
            hashCode = hashCode * -1521134295 + BoostBoostable.GetHashCode();
            hashCode = hashCode * -1521134295 + BoostUsePlayerLevel.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Effect[]>.Default.GetHashCode(Effects);
            hashCode = hashCode * -1521134295 + HiddenPower.GetHashCode();
            return hashCode;
        }
    }
}
