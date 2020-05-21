using System;
using System.IO;

namespace CityOfInfo.Data.Mids.Tests
{
    public class PowerWriter
    {
        private BinaryWriter _writer;

        public PowerWriter(BinaryWriter writer)
        {
            _writer = writer;
        }

        public void Write(Power power)
        {
            _writer.Write(power.Index);
            _writer.Write(power.FullName);
            _writer.Write(power.GroupName);
            _writer.Write(power.SetName);
            _writer.Write(power.Name);
            _writer.Write(power.Display);
            _writer.Write(power.Available);
            var requirementWriter = new RequirementWriter(_writer);
            requirementWriter.Write(power.Requirement);
            _writer.Write(power.ModesRequired);
            _writer.Write(power.ModesDisallowed);
            _writer.Write(power.PowerType);
            _writer.Write(power.Accuracy);
            _writer.Write(power.AttackTypes);
            _writer.Write(power.GroupMemberships.Length - 1);
            for (int index = 0; index < power.GroupMemberships.Length; ++index)
               _writer.Write(power.GroupMemberships[index]);
            _writer.Write(power.EntitiesAffected);
            _writer.Write(power.EntitiesAutoHit);
            _writer.Write(power.Target);
            _writer.Write(power.TargetLineOfSight);
            _writer.Write(power.Range);
            _writer.Write(power.TargetSecondary);
            _writer.Write(power.RangeSecondary);
            _writer.Write(power.EnduranceCost);
            _writer.Write(power.InterruptTime);
            _writer.Write(power.CastTime);
            _writer.Write(power.RechargeTime);
            _writer.Write(power.BaseRechargeTime);
            _writer.Write(power.ActivatePeriod);
            _writer.Write(power.EffectArea);
            _writer.Write(power.Radius);
            _writer.Write(power.Arc);
            _writer.Write(power.MaxTargets);
            _writer.Write(power.MaxBoosts);
            _writer.Write(power.CastFlags);
            _writer.Write(power.ArtificalIntelligenceReport);
            _writer.Write(power.NumberOfCharges);
            _writer.Write(power.UsageTime);
            _writer.Write(power.LifeTime);
            _writer.Write(power.LifeTimeInGame);
            _writer.Write(power.NumberAllowed);
            _writer.Write(power.DoNotSave);
            _writer.Write(power.BoostsAllowed.Length - 1);
            for (int index = 0; index < power.BoostsAllowed.Length; ++index)
                _writer.Write(power.BoostsAllowed[index]);
            _writer.Write(power.CastThroughHold);
            _writer.Write(power.IgnoreStrength);
            _writer.Write(power.DescriptionShort);
            _writer.Write(power.DescriptionLong);
            _writer.Write(power.SetTypes.Length - 1);
            for (int index = 0; index < power.SetTypes.Length; ++index)
                _writer.Write(power.SetTypes[index]);
            _writer.Write(power.ClickBuff);
            _writer.Write(power.AlwaysToggle);
            _writer.Write(power.Level);
            _writer.Write(power.AllowFrontLoading);
            _writer.Write(power.VariableEnabled);
            _writer.Write(power.VariableName);
            _writer.Write(power.VariableMin);
            _writer.Write(power.VariableMax);
            _writer.Write(power.SubPowers.Length - 1);
            for (int index = 0; index < power.SubPowers.Length; ++index)
                _writer.Write(power.SubPowers[index]);
            _writer.Write(power.IgnoreEnhancements.Length - 1);
            for (int index = 0; index < power.IgnoreEnhancements.Length; ++index)
                _writer.Write((int)power.IgnoreEnhancements[index]);
            _writer.Write(power.IgnoreBuffs.Length - 1);
            for (int index = 0; index < power.IgnoreBuffs.Length; ++index)
                _writer.Write(power.IgnoreBuffs[index]);
            _writer.Write(power.SkipMax);
            _writer.Write(power.DisplayLocation);
            _writer.Write(power.MutuallyExclusiveAuto);
            _writer.Write(power.MutuallyExclusiveIgnore);
            _writer.Write(power.AbsorbSummonEffects);
            _writer.Write(power.AbsorbSummonAttributes);
            _writer.Write(power.ShowSummonAnyway);
            _writer.Write(power.NeverAutoUpdate);
            _writer.Write(power.NeverAutoUpdateRequirements);
            _writer.Write(power.IncludeFlag);
            _writer.Write(power.ForcedClass);
            _writer.Write(power.SortOverride);
            _writer.Write(power.BoostBoostable);
            _writer.Write(power.BoostUsePlayerLevel);
            _writer.Write(power.Effects.Length - 1);
            var effectWriter = new EffectWriter(_writer);
            for (int index = 0; index < power.Effects.Length; ++index)
                effectWriter.Write(power.Effects[index]);                
            _writer.Write(power.HiddenPower);
        }
    }
}