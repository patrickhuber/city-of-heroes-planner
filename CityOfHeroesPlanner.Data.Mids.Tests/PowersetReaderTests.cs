using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace CityOfHeroesPlanner.Data.Mids.Tests
{
    public class PowersetReaderTests
    {
        [Fact]
        public void CanReadPowerset()
        {            
            using (var memoryStream = new MemoryStream())
            {
                var powerset = new PowerSet
                {
                    DisplayName = "test",
                    Archetype = 123,
                    SetType = 345,
                    ImageName = "image",
                    FullName = "test full name",
                    SetName = "test set name",
                    Description = "test description",
                    SubName = "test subname",
                    ClassType = "test class type",
                    TrunkSet = "trunkset",
                    LinkSecondary = "LinkSecondary",
                    MutuallyExclusiveGroups = new MutuallyExclusiveGroup[]{},
                };
                using (var binaryWriter = new BinaryWriter(memoryStream, Encoding.Default, true))
                {                    
                    binaryWriter.Write(powerset.DisplayName);
                    binaryWriter.Write(powerset.Archetype);
                    binaryWriter.Write(powerset.SetType);
                    binaryWriter.Write(powerset.ImageName);
                    binaryWriter.Write(powerset.FullName);
                    binaryWriter.Write(powerset.SetName);
                    binaryWriter.Write(powerset.Description);
                    binaryWriter.Write(powerset.SubName);
                    binaryWriter.Write(powerset.ClassType);
                    binaryWriter.Write(powerset.TrunkSet);
                    binaryWriter.Write(powerset.LinkSecondary);
                    binaryWriter.Write(powerset.MutuallyExclusiveGroups.Length - 1);
                    foreach(var group in powerset.MutuallyExclusiveGroups)
                    {                        
                        binaryWriter.Write(group.Name);
                        binaryWriter.Write(group.Id);
                    }
                }

                memoryStream.Seek(0, SeekOrigin.Begin);

                using (var binaryReader = new BinaryReader(memoryStream, Encoding.Default, true))
                {
                    var powersetReader = new PowerSetReader(binaryReader);
                    var record = powersetReader.Read();
                    Assert.Equal(powerset, record);
                }
            }
        }
    }
}
