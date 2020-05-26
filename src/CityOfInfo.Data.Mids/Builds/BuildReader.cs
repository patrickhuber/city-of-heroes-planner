using System;
using System.Collections.Generic;
using System.IO;

namespace CityOfInfo.Data.Mids.Builds
{
    public class BuildReader
    {
        private readonly BinaryReader _reader;
        private Character _character;

        public BuildReader(Character character, BinaryReader reader)
        {
            _reader = reader;
            _character = character;
        }

        public Build Read()
        {
            var build = new Build();

            // powersets
            build.PowerSets = ReadPowerSets();

            // powers
            build.LastPower = _reader.ReadInt32() - 1;
            build.PowerSlots = ReadPowerSlots(build);

            return build;
        }

        private List<PowerSet> ReadPowerSets()
        {
            var powerSetCount = _reader.ReadInt32() + 1;
            var powerSets = new List<PowerSet>();
            for (var i = 0; i < powerSetCount; i++)
            {
                var powerSet = ReadPowerSet();
                powerSets.Add(powerSet);
            }

            return powerSets;
        }

        private PowerSet ReadPowerSet()
        {
            var powerSet = new PowerSet();
            powerSet.FullName = _reader.ReadString();
            return powerSet;
        }

        private List<PowerSlot> ReadPowerSlots(Build build)
        {
            var powerSlots = new List<PowerSlot>();
            var powerCount = _reader.ReadInt32() + 1;
            for (var i = 0; i < powerCount; i++)
            {
                var powerSlot = ReadPowerSlot(build);

                if (powerSlot == null)
                    continue;

                powerSlots.Add(powerSlot);
            }

            return powerSlots;
        }

        private PowerSlot ReadPowerSlot(Build build)
        {            
            string fullName = "";
            int index = -1;

            if (_character.UseQualifiedNames)
                fullName = _reader.ReadString();
            else
                index = _reader.ReadInt32();

            if (index == -1 && string.IsNullOrEmpty(fullName))
                return null;

            var power = new Power();

            // enhanced power, references power and has enhancements in it
            var powerSlot = new PowerSlot();
            powerSlot.Power = power;
            powerSlot.Level = _reader.ReadSByte();
            powerSlot.StatInclude = _reader.ReadBoolean();
            powerSlot.VariableValue = _reader.ReadInt32();

            // sub powers
            powerSlot.SubPowers = ReadSubPowers(build);

            // enhancement slots
            powerSlot.EnhancementSlots = ReadEnhancementSlots(build);

            return powerSlot;
        }

        private List<SubPower> ReadSubPowers(Build build)
        {
            var subPowers = new List<SubPower>();
            if (!_character.UseSubpowerFields)
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
            if (_character.UseSubpowerFields)
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
            if (_character.UseQualifiedNames)
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
            if (_character.Version > SchemaVersion.v1_0_0)
                slotData.Add(_reader.ReadSByte());
            return slotData;
        }
    }
}
