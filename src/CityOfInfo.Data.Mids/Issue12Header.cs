using System;
using System.Collections.Generic;

namespace CityOfInfo.Data.Mids
{
    public class Issue12Header
    {
        public static readonly string MarkTwoVersionHeader = "Mids' Hero Designer Database MK II";

        public string Description { get; set; }
        public float Version { get; set; }
        public DateTime Date { get; set; }
        public int Issue { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Issue12Header header &&
                   Description == header.Description &&
                   Version == header.Version &&
                   Date == header.Date &&
                   Issue == header.Issue;
        }

        public override int GetHashCode()
        {
            var hashCode = 1460751721;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            hashCode = hashCode * -1521134295 + Version.GetHashCode();
            hashCode = hashCode * -1521134295 + Date.GetHashCode();
            hashCode = hashCode * -1521134295 + Issue.GetHashCode();
            return hashCode;
        }
    }
}