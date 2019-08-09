using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace CityOfHeroesPlanner.Data.Mids.Tests
{
    public class ArchetypeReaderTests
    {
        [Fact]
        public void CanReadArchetype()
        {

            var archetype = new Archetype
            {
                DisplayName = "test",
                HitPoints = 100,
                HitPointsMax = 1000f,
                DescriptionLong = "hello world",
                ResistenceMax = 90f,
                Origins = new string[] { "mutation", "science" },
                ClassType = 1,
                Column = 1234,
                ClassName = "test",
                DescriptionShort = "test",
                PrimaryGroup = "test",
                SecondaryGroup = "test2",
                Playable = true,
                RechargeMax = 2000f,
                DamageMax = 600f,
                RecoveryMax = 1000f,
                RegenerationMax = 1000f,
                RecoveryBase = 100f,
                RegenerationBase = 100f,
                ThreatBase = 100f,
                PerceptionBase = 100f
            };

            new ReaderTest(
                setup: (writer) => 
                {
                    writer.Write(archetype.DisplayName);
                    writer.Write(archetype.HitPoints);
                    writer.Write(archetype.HitPointsMax);
                    writer.Write(archetype.DescriptionLong);
                    writer.Write(archetype.ResistenceMax);
                    writer.Write(archetype.Origins.Length - 1);
                    foreach (var origin in archetype.Origins)
                    {
                        writer.Write(origin);
                    }
                    writer.Write(archetype.ClassName);
                    writer.Write(archetype.ClassType);
                    writer.Write(archetype.Column);
                    writer.Write(archetype.DescriptionShort);
                    writer.Write(archetype.PrimaryGroup);
                    writer.Write(archetype.SecondaryGroup);
                    writer.Write(archetype.Playable);
                    writer.Write(archetype.RechargeMax);
                    writer.Write(archetype.DamageMax);
                    writer.Write(archetype.RecoveryMax);
                    writer.Write(archetype.RegenerationMax);
                    writer.Write(archetype.RecoveryBase);
                    writer.Write(archetype.RegenerationBase);
                    writer.Write(archetype.ThreatBase);
                    writer.Write(archetype.PerceptionBase);
                }, 
                test: (reader) => 
                {
                    var archetypeReader = new ArchetypeReader(reader);
                    var record = archetypeReader.Read();
                    Assert.Equal(archetype, record);
                }
            ).Run();
        }
    }
}
