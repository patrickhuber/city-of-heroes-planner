using System;
using System.Collections.Generic;
using System.Text;

namespace CityOfInfo.Data.Mids
{
    public class VersionData
    {
        public int Revision { get; set; }
        public DateTime RevisionDate { get; set; }
        public string SourceFile { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            
            var versionData = obj as VersionData;
            if (versionData == null)
                return false;

            return versionData.Revision == Revision
                && versionData.RevisionDate == RevisionDate
                && versionData.SourceFile == SourceFile;
        }

        public override int GetHashCode()
        {
            var hashCode = -896985262;
            hashCode = hashCode * -1521134295 + Revision.GetHashCode();
            hashCode = hashCode * -1521134295 + RevisionDate.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(SourceFile);
            return hashCode;
        }
    }
}
