using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CityOfHeroesPlanner.Data.Mids
{
    public class PowerSetReader
    {
        private BinaryReader _reader;

        public PowerSetReader(BinaryReader reader)
        {
            _reader = reader;
        }

        public PowerSet Read()
        {
            var powerset = new PowerSet();
            powerset.DisplayName = _reader.ReadString();
            powerset.Archetype = _reader.ReadInt32();
            powerset.SetType = _reader.ReadInt32();
            powerset.ImageName = _reader.ReadString();
            powerset.FullName = _reader.ReadString();
            if (string.IsNullOrEmpty(powerset.FullName))
                powerset.FullName = "Orphan." + powerset.DisplayName.Replace(" ", "_");
            powerset.SetName = _reader.ReadString();
            powerset.Description = _reader.ReadString();
            powerset.SubName = _reader.ReadString();
            powerset.ClassType = _reader.ReadString();
            powerset.TrunkSet = _reader.ReadString();
            powerset.LinkSecondary = _reader.ReadString();
            int mutuallyExclusiveSetCount = _reader.ReadInt32();
            powerset.MutuallyExclusiveGroups = new MutuallyExclusiveGroup[mutuallyExclusiveSetCount + 1];
            for (int index = 0; index < powerset.MutuallyExclusiveGroups.Length; ++index)
            {
                powerset.MutuallyExclusiveGroups[index] = new MutuallyExclusiveGroup
                {
                    Name = _reader.ReadString(),
                    Id = _reader.ReadInt32()
                };
            }
            return powerset;
        }
    }
}
