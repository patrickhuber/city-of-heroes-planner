using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CityOfInfo.Data.Mids
{
    public class ArchetypeWriter
    {
        private BinaryWriter _writer;

        public ArchetypeWriter(BinaryWriter writer)
        {
            _writer = writer;
        }

        public void Write(Archetype archetype)
        {

            _writer.Write(archetype.DisplayName);
            _writer.Write(archetype.HitPoints);
            _writer.Write(archetype.HitPointsMax);
            _writer.Write(archetype.DescriptionLong);
            _writer.Write(archetype.ResistenceMax);
            _writer.Write(archetype.Origins.Length - 1);
            foreach (var origin in archetype.Origins)
            {
                _writer.Write(origin);
            }
            _writer.Write(archetype.ClassName);
            _writer.Write(archetype.ClassType);
            _writer.Write(archetype.Column);
            _writer.Write(archetype.DescriptionShort);
            _writer.Write(archetype.PrimaryGroup);
            _writer.Write(archetype.SecondaryGroup);
            _writer.Write(archetype.Playable);
            _writer.Write(archetype.RechargeMax);
            _writer.Write(archetype.DamageMax);
            _writer.Write(archetype.RecoveryMax);
            _writer.Write(archetype.RegenerationMax);
            _writer.Write(archetype.RecoveryBase);
            _writer.Write(archetype.RegenerationBase);
            _writer.Write(archetype.ThreatBase);
            _writer.Write(archetype.PerceptionBase);
        }
    }
}
