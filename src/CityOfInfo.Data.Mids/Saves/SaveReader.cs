using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CityOfInfo.Data.Mids.Saves
{
    public class SaveReader
    {
        private TextReader _reader;

        public SaveReader(TextReader reader)
        {
            _reader = reader;
        }

        public Save Read()
        {
            var state = 0;
            var save = new Save();

            var builder = new StringBuilder();
            while (_reader.Peek() != -1)
            {
                var ch = (char)_reader.Read();
                if (1 <= state && state <= 5)
                    if (ch != ';')
                    {
                        builder.Append(ch);
                        continue;
                    }
                if (state == 8)
                    if (ch != '|')
                    {
                        builder.Append(ch);
                        continue;
                    }

                switch (state)
                {
                    case 0:
                        if (ch == '|')
                            state = 1;
                        else
                            throw new Exception($"Expected character '|', found '{ch}'");
                        continue;
                    case 1:
                        save.Format = builder.ToString();
                        break;
                    case 2:
                        save.CompressionData.UncompressedByteCount = int.Parse(builder.ToString());
                        break;
                    case 3:
                        save.CompressionData.CompressedByteCount = int.Parse(builder.ToString());
                        break;
                    case 4:
                        save.CompressionData.EncodedByteCount = int.Parse(builder.ToString());
                        break;
                    case 5:
                        save.CompressionData.Encoding = builder.ToString();
                        break;
                    case 6:
                    case 7:
                        if (ch == '|')
                            state++;
                        else
                            throw new Exception($"Expected character '|', found {ch}");
                        continue;
                    case 8:
                        save.CompressionData.EncodedString = builder.ToString();
                        break;
                }

                if (1 <= state && state <= 5 || state == 8)
                {
                    builder.Clear();
                    state++;
                }
            }
            if (state == 0)
                throw new Exception("The header is empty");

            if (state != 9)
                throw new Exception($"The header was truncated, expected 8 elements, found {state}");

            return save;
        }
    }
}
