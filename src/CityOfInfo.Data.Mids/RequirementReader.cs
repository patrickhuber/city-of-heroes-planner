using System;
using System.IO;

namespace CityOfInfo.Data.Mids
{
    internal class RequirementReader
    {
        private BinaryReader _reader;

        public RequirementReader(BinaryReader reader)
        {
            _reader = reader;
        }

        public Requirement Read()
        {
            var requirement = new Requirement();
            requirement.ClassNames = new string[_reader.ReadInt32() + 1];
            for (int index = 0; index < requirement.ClassNames.Length; ++index)
                requirement.ClassNames[index] = _reader.ReadString();
            requirement.ClassNamesNot = new string[_reader.ReadInt32() + 1];
            for (int index = 0; index < requirement.ClassNamesNot.Length; ++index)
                requirement.ClassNamesNot[index] = _reader.ReadString();
            requirement.PowerIDs = new string[_reader.ReadInt32() + 1][];
            for (int index = 0; index < requirement.PowerIDs.Length; ++index)
            {
                requirement.PowerIDs[index] = new string[2];
                requirement.PowerIDs[index][0] = _reader.ReadString();
                requirement.PowerIDs[index][1] = _reader.ReadString();
            }
            requirement.PowerIDsNot = new string[_reader.ReadInt32() + 1][];
            for (int index = 0; index < requirement.PowerIDsNot.Length; ++index)
            {
                requirement.PowerIDsNot[index] = new string[2];
                requirement.PowerIDsNot[index][0] = _reader.ReadString();
                requirement.PowerIDsNot[index][1] = _reader.ReadString();
            }
            return requirement;
        }
    }
}