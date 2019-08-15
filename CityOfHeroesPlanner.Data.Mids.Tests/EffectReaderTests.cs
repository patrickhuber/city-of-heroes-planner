using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CityOfHeroesPlanner.Data.Mids.Tests
{
    public class EffectReaderTests
    {
        [Fact]
        public void CanReadEffect()
        {
            var effect = new Effect
            {
                PowerFullName = "PowerFullName",
                UniqueID = 1234,
                EffectClass = 10,
                EffectType = 30,
                DamageType = 40,
                MezmorizeType = 50,
                EffectModifiers = 60,
                Summon = "Summon",
                DelayedTime = 0.1234f,
                Ticks = 15,
                Stacking = 70,
                BaseProbability = 0.2345f,
                Suppression = 80,
                Buffable = true,
                Resistible = false,
                SpecialCase = 90,
                VariableModifiedOverride = true,
                PlayerVersusMode = 100,
                ToWho = 110,
                DisplayPercentageOverride = 120,
                Scale = 0.3456f,
                Magnitude = 0.4567f,
                Duration = 0.5678f,
                AttribType = 130,
                Aspect = 140,
                ModifierTable = "ModifierTable",
                NearGround = false,
                CancelOnMiss = true,
                RequiresToHitCheck = false,
                IDClassName = 150,
                UIDClassName = "UIDClassName",
                MagnitudeExpression = "MagnituedExpression",
                Reward = "Reward",
                EffectId = "EffectId",
                IgnoreEnhancementDiversification = true,
                Override = "Override",
                ProcsPerMinute = 0.6789f
            };
            new ReaderTest(setup: (writer) =>
            {
                new EffectWriter(writer).Write(effect);
            },
            test: (reader) =>
            {
                var record = new EffectReader(reader).Read();
                Assert.Equal(effect, record);
            }).Run();
        }
    }
}
