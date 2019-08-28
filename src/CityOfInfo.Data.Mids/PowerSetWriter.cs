using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CityOfInfo.Data.Mids
{
    public class PowerSetWriter
    {
        private BinaryWriter _writer;

        public PowerSetWriter(BinaryWriter writer)
        {
            _writer = writer;
        }

        public void Write(PowerSet powerSet)
        {
            _writer.Write(powerSet.DisplayName);
            _writer.Write(powerSet.Archetype);
            _writer.Write(powerSet.SetType);
            _writer.Write(powerSet.ImageName);
            _writer.Write(powerSet.FullName);
            _writer.Write(powerSet.SetName);
            _writer.Write(powerSet.Description);
            _writer.Write(powerSet.SubName);
            _writer.Write(powerSet.ClassType);
            _writer.Write(powerSet.TrunkSet);
            _writer.Write(powerSet.LinkSecondary);
            _writer.Write(powerSet.MutuallyExclusiveGroups.Length - 1);
            foreach (var group in powerSet.MutuallyExclusiveGroups)
            {
                _writer.Write(group.Name);
                _writer.Write(group.Id);
            }
        }
    }
}
