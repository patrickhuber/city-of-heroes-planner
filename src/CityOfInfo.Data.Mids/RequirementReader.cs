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
            requirement.PowerIds = new string[_reader.ReadInt32() + 1][];
            for (int index = 0; index < requirement.PowerIds.Length; ++index)
            {
                requirement.PowerIds[index] = new string[2];
                requirement.PowerIds[index][0] = _reader.ReadString();
                requirement.PowerIds[index][1] = _reader.ReadString();
            }
            requirement.PowerIdsNot = new string[_reader.ReadInt32() + 1][];
            for (int index = 0; index < requirement.PowerIdsNot.Length; ++index)
            {
                requirement.PowerIdsNot[index] = new string[2];
                requirement.PowerIdsNot[index][0] = _reader.ReadString();
                requirement.PowerIdsNot[index][1] = _reader.ReadString();
            }
            return requirement;
        }
    }
}