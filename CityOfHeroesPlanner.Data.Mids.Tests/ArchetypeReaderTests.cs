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
            using (var memoryStream = new MemoryStream())
            {
                var archetype = new Archetype {
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
                                
                using (var binaryWriter = new BinaryWriter(memoryStream, Encoding.Default, true))
                {
                    binaryWriter.Write(archetype.DisplayName);
                    binaryWriter.Write(archetype.HitPoints);
                    binaryWriter.Write(archetype.HitPointsMax);
                    binaryWriter.Write(archetype.DescriptionLong);
                    binaryWriter.Write(archetype.ResistenceMax);
                    binaryWriter.Write(archetype.Origins.Length - 1);
                    foreach(var origin in archetype.Origins)
                    {
                        binaryWriter.Write(origin);
                    }
                    binaryWriter.Write(archetype.ClassName);
                    binaryWriter.Write(archetype.ClassType);
                    binaryWriter.Write(archetype.Column);
                    binaryWriter.Write(archetype.DescriptionShort);
                    binaryWriter.Write(archetype.PrimaryGroup);
                    binaryWriter.Write(archetype.SecondaryGroup);
                    binaryWriter.Write(archetype.Playable);
                    binaryWriter.Write(archetype.RechargeMax);
                    binaryWriter.Write(archetype.DamageMax);
                    binaryWriter.Write(archetype.RecoveryMax);
                    binaryWriter.Write(archetype.RegenerationMax);
                    binaryWriter.Write(archetype.RecoveryBase);
                    binaryWriter.Write(archetype.RegenerationBase);
                    binaryWriter.Write(archetype.ThreatBase);
                    binaryWriter.Write(archetype.PerceptionBase);
                }

                memoryStream.Seek(0, SeekOrigin.Begin);

                using (var binaryReader = new BinaryReader(memoryStream, Encoding.Default, true))
                {
                    var archetypeReader = new ArchetypeReader(binaryReader);
                    var record = archetypeReader.Read();
                    Assert.Equal(archetype, record);
                }
            }
        }
    }
}
