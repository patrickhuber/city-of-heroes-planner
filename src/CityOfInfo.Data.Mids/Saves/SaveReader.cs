using System;
using System.IO;
using System.Text;

namespace CityOfInfo.Data.Mids.Saves
{
    public class SaveReader
    {
        private readonly TextReader _reader;

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
                switch (state)
                {
                    case 0:
                        if (ch == '|')
                            state = 1;
                        break;
                    case 1:
                        if (ch == 'M')
                            state = 2;
                        else
                            state = 0;
                        break;
                    case 2:
                        if (ch == 'x')
                            state = 3;
                        else
                            state = 0;
                        break;
                    case 3:
                        if (ch == 'D')
                            state = 4;
                        else
                            state = 0;
                        break;
                    case 4:
                        if (ch == 'z' || ch == 'u')
                        {
                            save.Format = $"MxD{ch}";
                            state = 5;
                        }
                        else
                            state = 0;
                        break;
                    case 5:
                        if (ch == ';')
                        {
                            state = 6;
                            save.CompressionData = new CompressionData();
                        }
                        break;
                    case 6:
                        if (ch == ';')
                        {
                            if (int.TryParse(builder.ToString(), out var uncompressedByteCount))
                                save.CompressionData.UncompressedByteCount = uncompressedByteCount;
                            state = 7;
                            builder.Clear();
                        }
                        else
                            builder.Append(ch);
                        break;
                    case 7:
                        if (ch == ';')
                        {
                            if (int.TryParse(builder.ToString(), out var compressedByteCount))
                                save.CompressionData.CompressedByteCount = compressedByteCount;
                            state = 8;
                            builder.Clear();
                        }
                        else
                            builder.Append(ch);                        
                        break;
                    case 8:
                        if (ch == ';')
                        {
                            if (int.TryParse(builder.ToString(), out var encodedByteCount))
                                save.CompressionData.EncodedByteCount = encodedByteCount;
                            state = 9;
                            builder.Clear();
                        }
                        else
                            builder.Append(ch);
                        break;
                    case 9:
                        if (ch == ';')
                        {
                            save.CompressionData.Encoding = builder.ToString();
                            state = 10;
                            builder.Clear();
                        }
                        else
                            builder.Append(ch);
                        break;
                    case 10:
                        if (('0' <= ch && ch <= '9') || ('A' <= ch && ch <= 'F'))                        
                            builder.Append(ch);                        
                        if ('a' <= ch && ch <= 'f')
                            builder.Append(char.ToUpper(ch));
                        if (ch == '-')                        
                            state = 11;
                        
                        break;

                    case 11:
                        break;
                }
            }

            if (state >= 10)
                save.CompressionData.EncodedString = builder.ToString();
            else if (state == 0)
                throw new Exception("The header is missing");
            else if (state < 10)
                throw new Exception("The header was truncated");

            // scan for magic offset
            return save;
        }
    }
}
