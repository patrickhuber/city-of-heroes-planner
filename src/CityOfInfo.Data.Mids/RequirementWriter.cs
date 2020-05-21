using System;
using System.IO;

namespace CityOfInfo.Data.Mids.Tests
{
    public class RequirementWriter
    {
        private BinaryWriter _writer;

        public RequirementWriter(BinaryWriter writer)
        {
            _writer = writer;
        }

        public void Write(Requirement requirement)
        {
            _writer.Write(requirement.ClassNames.Length - 1);
            for (int index = 0; index < requirement.ClassNames.Length; ++index)
                _writer.Write(requirement.ClassNames[index]);
            _writer.Write(requirement.ClassNamesNot.Length - 1);
            for (int index = 0; index < requirement.ClassNamesNot.Length; ++index)
                _writer.Write(requirement.ClassNamesNot[index]);
            _writer.Write(requirement.PowerIds.Length - 1);
            for (int index = 0; index < requirement.PowerIds.Length; ++index)
            {
                _writer.Write(requirement.PowerIds[index][0]);
                _writer.Write(requirement.PowerIds[index][1]);
            }
            _writer.Write(requirement.PowerIdsNot.Length - 1);
            for (int index = 0; index < requirement.PowerIdsNot.Length; ++index)
            {
                _writer.Write(requirement.PowerIdsNot[index][0]);
                _writer.Write(requirement.PowerIdsNot[index][1]);
            }
        }
    }
}