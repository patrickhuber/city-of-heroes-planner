using CityOfInfo.Data.Mids.Saves;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CityOfInfo.Data.Mids.Forums
{
    public class PostReader
    {
        private StringReader _reader;

        public PostReader(StringReader reader)
        {
            _reader = reader;
        }

        public Post Read()
        {
            var save = ReadAsSave();
            return ConvertToPost(save);
        }

        private Save ReadAsSave()
        {
            var saveStream = CreateSaveStream();
            var save = new SaveReader(new StreamReader(saveStream)).Read();
            return save;
        }

        private Stream CreateSaveStream()
        {
            var memoryStream = new MemoryStream();
            var streamWriter = new StreamWriter(memoryStream);

            var state = 0;

            while (_reader.Peek() != -1)
            {
                var line = _reader.ReadLine();

                // skip buffer lines
                if (line.StartsWith("|-----"))
                    continue;
                if (line.StartsWith("| "))
                    continue;

                switch (state)
                {
                    case 0:
                        streamWriter.Write(line);
                        streamWriter.Write('|');
                        state = 1;
                        break;
                    case 1:
                        streamWriter.Write(line.Trim('|'));
                        break;
                }
            }
            streamWriter.Write('|');
            streamWriter.Flush();
            memoryStream.Seek(0, SeekOrigin.Begin);

            return memoryStream;

        }

        private Post ConvertToPost(Save save)
        {
            return new Post
            {
                CompressionData = save.CompressionData
            };
        }
    }
}
