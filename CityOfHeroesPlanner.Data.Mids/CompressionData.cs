using System;
using System.Collections.Generic;
using System.Text;

namespace CityOfHeroesPlanner.Data.Mids
{
    public class CompressionData
    {
        public int UncompressedByteCount { get; set; }
        public int CompressedByteCount { get; set; }
        public int EncodedByteCount { get; set; }
        public string EncodedString { get; set; }
        public string Encoding { get; set; }
    }
}
