using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CityOfInfo.Data.Mids
{
    public class BuildReader
    {
        private readonly BinaryReader _reader;
        
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

        public BuildReader(BinaryReader reader)
        {
            _reader = reader;
        }

        public Build Read()
        {
            var build = new Build();

            var magicNumber = ReadMagicNumber();
            ValidateMagicNumber(magicNumber);

            build.Version = _reader.ReadSingle();
            build.UseQualifiedNames = _reader.ReadBoolean();
            build.UseOldSubpowerFields = _reader.ReadBoolean();

            // archetype
            build.Archetype = new Archetype();
            build.Archetype.ClassName = _reader.ReadString();
            build.Archetype.Origins = new string[]
            {
                _reader.ReadString()
            };

            // alignment
            if (build.Version > 1.0f)
                build.Alignment = _reader.ReadInt32();

            // character name
            build.CharacterName = _reader.ReadString();

            // powersets
            build.PowerSets = ReadPowerSets();

            // powers
            build.LastPower = _reader.ReadInt32() - 1;            
            build.EnhancedPowers = ReadEnhancedPowers(build);
            
            return build;
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

        private List<PowerSet> ReadPowerSets()
        {
            var powerSetCount = _reader.ReadInt32() + 1;
            var powerSets = new List<PowerSet>();
            for (var i = 0; i < powerSetCount; i++)
            {
                var powerSetName = _reader.ReadString();
                var powerSet = new PowerSet();
                powerSet.FullName = powerSetName;
                powerSets.Add(powerSet);
            }

            return powerSets;
        }

        private List<EnhancedPower> ReadEnhancedPowers(Build build)
        {
            var enhancedPowers = new List<EnhancedPower>();
            var powerCount = _reader.ReadInt32() + 1;
            for (var i = 0; i < powerCount; i++)
            {
                var enhancedPower = ReadEnhancedPower(build);
                enhancedPowers.Add(enhancedPower);
            }

            return enhancedPowers;
        }

        private EnhancedPower ReadEnhancedPower(Build build)
        {
            var power = new Power();
            if (build.UseQualifiedNames)
                power.FullName = _reader.ReadString();
            else
                power.Index = _reader.ReadInt32();
            
            // enhanced power, references power and has enhancements in it
            var enhancedPower = new EnhancedPower();
            enhancedPower.Power = power;
            enhancedPower.Level = _reader.ReadSByte();
            enhancedPower.StatInclude = _reader.ReadBoolean();
            enhancedPower.VariableValue = _reader.ReadInt32();
            enhancedPower.SubPowers = ReadSubPowers(build);
            
            // enhancement slots
            enhancedPower.EnhancementSlots = ReadEnhancementSlots(build);

            return enhancedPower;
        }

        private List<SubPower> ReadSubPowers(Build build)
        {
            var subPowers = new List<SubPower>();
            if (!build.UseOldSubpowerFields)            
                return subPowers;            

            var subPowerCount = _reader.ReadSByte() + 1;
            for (var i = 0; i < subPowerCount; i++)
            {
                var subPower = ReadSubPower(build);
                subPowers.Add(subPower);
            }            

            return subPowers;
        }

        private SubPower ReadSubPower(Build build)
        {
            var subPower = new SubPower();
            if (build.UseOldSubpowerFields)
                subPower.Name = _reader.ReadString();
            else
                subPower.Index = _reader.ReadInt32();
            subPower.StatInclude = _reader.ReadBoolean();
            return subPower;
        }

        private List<EnhancementSlot> ReadEnhancementSlots(Build build)
        {
            var enhancementSlots = new List<EnhancementSlot>();
            var slotCount = _reader.ReadSByte() + 1;
            for (var slotIndex = 0; slotIndex < slotCount; slotIndex++)
            {
                var enhancementSlot = ReadEnhancementSlot(build);
                enhancementSlots.Add(enhancementSlot);
            }

            return enhancementSlots;
        }
        
        private EnhancementSlot ReadEnhancementSlot(Build build)
        {
            var enhancementSlot = new EnhancementSlot();
            enhancementSlot.Level = _reader.ReadSByte();
            enhancementSlot.Enhancement = ReadEnhancementSlotEntry(build);

            var readFlippedEntry = _reader.ReadBoolean();
            if (readFlippedEntry)
                enhancementSlot.Flipped = ReadEnhancementSlotEntry(build);
            return enhancementSlot;
        }

        private EnhancementSlotEntry ReadEnhancementSlotEntry(Build build)
        {
            var enhancement = new Enhancement();
            if (build.UseQualifiedNames)
                enhancement.Name = _reader.ReadString();
            else            
                enhancement.Index = _reader.ReadInt32();

            var enhancementSlotEntry = new EnhancementSlotEntry();
            enhancementSlotEntry.Enhancement = enhancement;

            List<sbyte> slotData;
            if (enhancement.Index == -1 && string.IsNullOrWhiteSpace(enhancement.Name))
                slotData = new List<sbyte>();
            else
                slotData = ReadSlotData(build);

            enhancementSlotEntry.SlotData = slotData;

            return enhancementSlotEntry;
        }

        private List<sbyte> ReadSlotData(Build build)
        {
            var slotData = new List<sbyte>();
            slotData.Add(_reader.ReadSByte());
            if (build.Version > 1.0)
                slotData.Add(_reader.ReadSByte());
            return slotData;
        }
    }
}
