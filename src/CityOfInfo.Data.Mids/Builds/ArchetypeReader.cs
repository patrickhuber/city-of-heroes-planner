using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CityOfInfo.Data.Mids.Builds
{
    public class ArchetypeReader
    {
        private BinaryReader _reader;

        public ArchetypeReader(BinaryReader reader)
        {
            _reader = reader;
        }

        public Archetype Read()
        {            
            var archetype = new Archetype();
            archetype.ClassName = _reader.ReadString();
            var architectClassNameSplit = archetype.ClassName
                            .Substring("Class_".Length)
                            .Split('_');
            archetype.DisplayName = string.Join(" ", architectClassNameSplit);
            archetype.Origins = new string[]
            {
                _reader.ReadString()
            };
            return archetype;
        }
    }
}
