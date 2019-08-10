using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace CityOfHeroesPlanner.Data.Mids.Tests
{
    public class PowerReaderTests
    {
        [Fact]
        public void CanReadPower()
        {
            using (var memoryStream = new MemoryStream())
            {
                var index = 0;
                var power = new Power
                {
                    Index = 0,
                    FullName = "FullName",
                    GroupName = "GroupName",
                    SetName = "SetName",
                    Name = "Name",
                    Display = "Display",
                    Available = index++,
                    ModesRequired = index++,
                    ModesDisallowed = index++,
                    PowerType = index++,
                    Accuracy = .75f,
                    AttackTypes = index++,
                    GroupMemberships = new string[]{ },
                    EntitiesAffected = index++,
                    EntitiesAutoHit = index++,
                    Target = index ++,
                    TargetLineOfSight = true,
                    Range = .20f,
                    TargetSecondary = index++,
                    RangeSecondary = .1f,
                    EnduranceCost = .3f,
                    InterruptTime = .2f,
                    CastTime = .2f,
                    RechargeTime = 120f,
                    ActivatePeriod = 10f,
                    EffectArea = index++,
                    Radius = 15f,
                    Arc = 30,
                    MaxTargets = 10,
                    MaxBoosts = "MaxBoosts",
                    CastFlags =index++,
                    ArtificalIntelligenceReport = index++,
                    NumberOfCharges = index++,
                    UsageTime = index++,
                    LifeTime = index++,
                    LifeTimeInGame = index++,
                    NumberAllowed = index++,
                    DoNotSave = true,
                    BoostsAllowed = new string[] { },
                    CastThroughHold = false,
                    IgnoreStrength = false,                    
                    DescriptionLong = "DescriptionLong",
                    DescriptionShort = "DescriptionShort",
                    SetTypes = new int[] { },
                    ClickBuff = true,
                    AlwaysToggle = false,
                    Level = 20,
                    AllowFrontLoading = true,
                    VariableEnabled = false,
                    VariableName = "VariableName",
                    VariableMin = 10,
                    VariableMax = 20,
                    SubPowers = new string[] { },
                    IgnoreEnhancements = new int[] { },
                    IgnoreBuffs = new int[] { },
                    SkipMax = false,
                    DisplayLocation = index++,
                    MutuallyExclusiveAuto = true,
                    MutuallyExclusiveIgnore = false,
                    AbsorbSummonEffects = true,
                    AbsorbSummonAttributes = false,
                    Requirement = new Requirement
                    {
                        ClassNames = new string[] { },
                        ClassNamesNot = new string[] { },
                        PowerIDs = new string[][] { },
                        PowerIDsNot = new string[][] { },
                    },
                    Effects = new Effect[] { },
                    ForcedClass = "ForcedClass",
                };
                new ReaderTest(
                    setup: (writer) => 
                    {
                        var powerWriter = new PowerWriter(writer);
                        powerWriter.Write(power);
                    }, 
                    test: (reader) => 
                    {
                        var powerReader = new PowerReader(reader);
                        var record = powerReader.Read();
                        Assert.Equal(power, record);
                    }).Run();
            }
        }
    }
}
