using System;
using System.Collections.Generic;
using System.Text;

namespace CityOfHeroesPlanner.Data.Mids
{
    public class HexUtil
    {
        public static byte[] Decode(byte[] encoded)
        {
            var decoded = new byte[encoded.Length / 2];
            for (var i = 0; i < decoded.Length; i++)
            {
                decoded[i] = (byte)(GetHexVal(encoded[i << 1]) << 4);
                decoded[i] |= (byte)(GetHexVal(encoded[(i << 1) + 1]));
            }
            return decoded;
        }


        private static int GetHexVal(byte hex)
        {
            int val = (int)hex;
            //For uppercase A-F letters:
            return val - (val < 58 ? 48 : 55);
            //For lowercase a-f letters:
            //return val - (val < 58 ? 48 : 87);
            //Or the two combined, but a bit slower:
            //return val - (val < 58 ? 48 : (val < 97 ? 55 : 87));
        }
    }
}
