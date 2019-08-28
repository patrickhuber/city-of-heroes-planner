using System;
using System.Collections.Generic;
using System.Text;

namespace CityOfInfo.Data.Mids
{
    internal static class ComparisonExtensions
    {
        internal static bool EqualTo<T>(this T[] first, T[] second)
        {
            if (first == null)
                if (second == null)
                    return true;
                else
                    return false;

            if (second == null)
                return false;

            if (first.Length != second.Length)
                return false;
            for (var i = 0; i < first.Length; i++)
                if (!first[i].Equals(second[i]))
                    return false;
            return true;            
        }

        internal static bool EqualTo<T>(this T[][] first, T[][] second)
        {
            if (first == null)
                if (second == null)
                    return true;
                else
                    return false;

            if (second == null)
                return false;

            if (first.Length != second.Length)
                return false;

            for (var i = 0; i < first.Length; i++)
                if (!first[i].EqualTo(second[i]))
                    return false;
            return true;
        }
    }
}
