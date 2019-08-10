using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CityOfHeroesPlanner.Data.Mids
{
    public class PowerReader
    {
        private readonly BinaryReader _reader;

        public PowerReader(BinaryReader reader)
        {
            _reader = reader;
        }

        public Power Read()
        {
            var power = new Power();            
            power.Index = _reader.ReadInt32();
            power.FullName = _reader.ReadString();
            power.GroupName = _reader.ReadString();
            power.SetName = _reader.ReadString();
            power.Name = _reader.ReadString();
            power.Display = _reader.ReadString();
            power.Available = _reader.ReadInt32();
            power.Requirement = new RequirementReader(_reader).Read();
            power.ModesRequired = _reader.ReadInt32();
            power.ModesDisallowed = _reader.ReadInt32();
            power.PowerType = _reader.ReadInt32();
            power.Accuracy = _reader.ReadSingle();
            power.AttackTypes = _reader.ReadInt32();
            power.GroupMemberships = new string[_reader.ReadInt32() + 1];
            for (int index = 0; index < power.GroupMemberships.Length; ++index)
                power.GroupMemberships[index] = _reader.ReadString();
            power.EntitiesAffected =_reader.ReadInt32();
            power.EntitiesAutoHit = _reader.ReadInt32();
            power.Target = _reader.ReadInt32();
            power.TargetLineOfSight = _reader.ReadBoolean();
            power.Range = _reader.ReadSingle();
            power.TargetSecondary = _reader.ReadInt32();
            power.RangeSecondary = _reader.ReadSingle();
            power.EnduranceCost = _reader.ReadSingle();
            power.InterruptTime = _reader.ReadSingle();
            power.CastTime = _reader.ReadSingle();
            power.RechargeTime = _reader.ReadSingle();
            power.ActivatePeriod = _reader.ReadSingle();
            power.EffectArea =_reader.ReadInt32();
            power.Radius = _reader.ReadSingle();
            power.Arc = _reader.ReadInt32();
            power.MaxTargets = _reader.ReadInt32();
            power.MaxBoosts = _reader.ReadString();
            power.CastFlags = _reader.ReadInt32();
            power.ArtificalIntelligenceReport = _reader.ReadInt32();
            power.NumberOfCharges = _reader.ReadInt32();
            power.UsageTime = _reader.ReadInt32();
            power.LifeTime = _reader.ReadInt32();
            power.LifeTimeInGame = _reader.ReadInt32();
            power.NumberAllowed = _reader.ReadInt32();
            power.DoNotSave = _reader.ReadBoolean();
            power.BoostsAllowed = new string[_reader.ReadInt32() + 1];
            for (int index = 0; index < power.BoostsAllowed.Length; ++index)
                power.BoostsAllowed[index] = _reader.ReadString();
            power.CastThroughHold = _reader.ReadBoolean();
            power.IgnoreStrength = _reader.ReadBoolean();
            power.DescriptionShort = _reader.ReadString();
            power.DescriptionLong = _reader.ReadString();
            power.SetTypes = new int[_reader.ReadInt32() + 1];
            for (int index = 0; index < power.SetTypes.Length; ++index)
                power.SetTypes[index] = _reader.ReadInt32();
            power.ClickBuff = _reader.ReadBoolean();
            power.AlwaysToggle = _reader.ReadBoolean();
            power.Level = _reader.ReadInt32();
            power.AllowFrontLoading = _reader.ReadBoolean();
            power.VariableEnabled = _reader.ReadBoolean();
            power.VariableName = _reader.ReadString();
            power.VariableMin = _reader.ReadInt32();
            power.VariableMax = _reader.ReadInt32();
            power.SubPowers = new string[_reader.ReadInt32() + 1];
            for (int index = 0; index < power.SubPowers.Length; ++index)
                power.SubPowers[index] = _reader.ReadString();
            power.IgnoreEnhancements = new int[_reader.ReadInt32() + 1];
            for (int index = 0; index < power.IgnoreEnhancements.Length; ++index)
                power.IgnoreEnhancements[index] = _reader.ReadInt32();
            power.IgnoreBuffs = new int[_reader.ReadInt32() + 1];
            for (int index = 0; index < power.IgnoreBuffs.Length; ++index)
                power.IgnoreBuffs[index] = _reader.ReadInt32();
            power.SkipMax = _reader.ReadBoolean();
            power.DisplayLocation = _reader.ReadInt32();
            power.MutuallyExclusiveAuto = _reader.ReadBoolean();
            power.MutuallyExclusiveIgnore = _reader.ReadBoolean();
            power.AbsorbSummonEffects = _reader.ReadBoolean();
            power.AbsorbSummonAttributes = _reader.ReadBoolean();
            power.ShowSummonAnyway = _reader.ReadBoolean();
            power.NeverAutoUpdate = _reader.ReadBoolean();
            power.NeverAutoUpdateRequirements = _reader.ReadBoolean();
            power.IncludeFlag = _reader.ReadBoolean();
            power.ForcedClass = _reader.ReadString();
            power.SortOverride = _reader.ReadBoolean();
            power.BoostBoostable = _reader.ReadBoolean();
            power.BoostUsePlayerLevel = _reader.ReadBoolean();
            power.Effects = new Effect[_reader.ReadInt32() + 1];
            var effectReader = new EffectReader(_reader);
            for (int index = 0; index < power.Effects.Length ; ++index)
            {
                power.Effects[index] = effectReader.Read();
            }
            power.HiddenPower = _reader.ReadBoolean();
            return power;
        }
    }
}
