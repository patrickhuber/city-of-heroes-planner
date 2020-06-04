using System;

namespace CityOfInfo.Domain
{
    public class SemanticVersion : IComparable<SemanticVersion>, IEquatable<SemanticVersion>
    {
        public int Major { get; set; }
        public int Minor { get; set; }
        public int Patch { get; set; }

        public SemanticVersion() { }

        public SemanticVersion(int major, int minor, int patch)         
        {
            Major = major;
            Minor = minor;
            Patch = patch;
        }

        public int CompareTo(SemanticVersion other)
        {
            // https://docs.microsoft.com/en-us/dotnet/api/system.icomparable-1.compareto#notes-to-implementers
            // an instance is greater than 1
            if (other is null)
                return 1;

            var majorResult = Major.CompareTo(other.Major);
            if (majorResult != 0)
                return majorResult;

            var minorResult = Minor.CompareTo(other.Minor);
            if (minorResult != 0)
                return minorResult;

            var patchResult = Patch.CompareTo(other.Patch);
            if (patchResult != 0)
                return patchResult;

            return 0;
        }

        public override bool Equals(object obj)
        {
            // null case handled in CompareTo
            return Equals(obj as SemanticVersion);
        }

        public bool Equals(SemanticVersion other)
        {
            // null case handled in CompareTo
            return CompareTo(other) == 0;
        }

        public override int GetHashCode()
        {
            int hashCode = -639545495;
            hashCode = hashCode * -1521134295 + Major.GetHashCode();
            hashCode = hashCode * -1521134295 + Minor.GetHashCode();
            hashCode = hashCode * -1521134295 + Patch.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"{Major}.{Minor}.{Patch}";
        }

        public static bool operator <=(SemanticVersion left, SemanticVersion right)
        {
            return left is null || left.CompareTo(right) <= 0;
        }

        public static bool operator >=(SemanticVersion left, SemanticVersion right)
        {
            return left is null ? right is null : left.CompareTo(right) >= 0;
        }

        public static bool operator <(SemanticVersion left, SemanticVersion right)
        {
            return left is null ? right is object : left.CompareTo(right) < 0;
        }

        public static bool operator >(SemanticVersion left, SemanticVersion right)
        {
            return left is object && left.CompareTo(right) > 0;
        }

        public static bool operator ==(SemanticVersion left, SemanticVersion right)
        {
            if (left is null)
            {
                return right is null;
            }

            return left.Equals(right);
        }

        public static bool operator !=(SemanticVersion left, SemanticVersion right)
        {
            return !(left == right);
        }
    }
}
