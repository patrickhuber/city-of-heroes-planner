using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CityOfInfo.Data.Mids.Builds
{
    public class CharacterReader
    {
        private BinaryReader _reader;
        private static readonly byte[] MagicNumber = new byte[4]
        {
            // M (ascii)
            0x4d,
            // x (ascii)
            0x78,
            // D (ascii)
            0x44,
            // 12 (decimal)
            0x0C,
        };

        public CharacterReader(BinaryReader reader)
        {
            _reader = reader;
        }

        public Character Read()
        {
            var character = new Character();
            var magicNumber = ReadMagicNumber();
            ValidateMagicNumber(magicNumber);

            var schemaVersion = _reader.ReadSingle();
            character.Version = SchemaVersion.Find(schemaVersion);

            character.UseQualifiedNames = _reader.ReadBoolean();
            character.UseSubpowerFields = _reader.ReadBoolean();

            // archetype
            character.Archetype = new ArchetypeReader(_reader).Read();

            // alignment is a lookup value
            // ideally this would be data driven
            if (character.Version > SchemaVersion.v1_0_0)
                character.Alignment = Alignment.Find(_reader.ReadInt32(), string.Empty);

            character.Name = _reader.ReadString();

            // read the first build with a build reader
            // if multiple builds are supported in the future, I assume it will be a version bump
            character.Builds = new List<Build>();
            var build = new BuildReader(character, _reader).Read();
            character.Builds.Add(build);

            return character;
        }

        private byte[] ReadMagicNumber()
        {
            return _reader.ReadBytes(4);
        }

        private void ValidateMagicNumber(byte[] bytes)
        {
            if (bytes == null)
                throw new Exception("empty magic number");
            if (bytes.Length != 4)
                throw new Exception($"invalid magic number size. Expected 4, found {bytes.Length}");

            for (var i = 0; i < bytes.Length; i++)
                if (bytes[i] != MagicNumber[i])
                    throw new Exception($"invalid magic number. Error at index {i}. Expected '{MagicNumber[i]} found '{bytes[i]}'");
        }
    }
}
