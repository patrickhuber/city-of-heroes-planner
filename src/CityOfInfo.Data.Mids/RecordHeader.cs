using System;
using System.Collections.Generic;
using System.Text;

namespace CityOfInfo.Data.Mids
{
    public class RecordHeader
    {
        public string Prefix { get; set; }
        public VersionData VersionData { get; set; }
        public int Count { get; set; }

        public override bool Equals(object obj)
        {
            return obj is RecordHeader header &&
                   Prefix == header.Prefix &&
                   VersionData.Equals(header.VersionData) &&
                   Count == header.Count;
        }

        public override int GetHashCode()
        {
            var hashCode = -672071676;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Prefix);
            hashCode = hashCode * -1521134295 + EqualityComparer<VersionData>.Default.GetHashCode(VersionData);
            hashCode = hashCode * -1521134295 + Count.GetHashCode();
            return hashCode;
        }
    }
}
