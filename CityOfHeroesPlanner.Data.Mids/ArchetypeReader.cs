using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CityOfHeroesPlanner.Data.Mids
{
    public class ArchetypeReader
    {
        BinaryReader _reader;

        public ArchetypeReader(BinaryReader reader)
        {
            _reader = reader;
        }

        public Archetype Read()
        {
            var archetype = new Archetype();
            archetype.DisplayName = _reader.ReadString();
            archetype.HitPoints = _reader.ReadInt32();
            archetype.HitPointsMax = _reader.ReadSingle();
            archetype.DescriptionLong = _reader.ReadString();
            archetype.ResistenceMax = _reader.ReadSingle();
            var originLength = _reader.ReadInt32();
            archetype.Origins = new string[originLength + 1];
            for (var i = 0; i < archetype.Origins.Length; i++)
                archetype.Origins[i] = _reader.ReadString();
            archetype.ClassName = _reader.ReadString();
            archetype.ClassType = _reader.ReadInt32();
            archetype.Column = _reader.ReadInt32();
            archetype.DescriptionShort = _reader.ReadString();
            archetype.PrimaryGroup = _reader.ReadString();
            archetype.SecondaryGroup = _reader.ReadString();
            archetype.Playable = _reader.ReadBoolean();
            archetype.RechargeMax = _reader.ReadSingle();
            archetype.DamageMax = _reader.ReadSingle();
            archetype.RecoveryMax = _reader.ReadSingle();
            archetype.RegenerationMax = _reader.ReadSingle();
            archetype.RecoveryBase = _reader.ReadSingle();
            archetype.RegenerationBase = _reader.ReadSingle();
            archetype.ThreatBase = _reader.ReadSingle();
            archetype.PerceptionBase = _reader.ReadSingle();
            return archetype;
        }
    }
}
