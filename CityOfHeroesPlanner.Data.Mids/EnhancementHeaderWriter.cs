using System.IO;

namespace CityOfHeroesPlanner.Data.Mids
{
    public class EnhancementHeaderWriter
    {
        private BinaryWriter _writer;

        public EnhancementHeaderWriter(BinaryWriter writer)
        {
            _writer = writer;
        }

        public void Write(EnhancementHeader header)
        {
            _writer.Write(header.Prefix);
            _writer.Write(header.Version);
            _writer.Write(header.Count);
        }
    }
}
