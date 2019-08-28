using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CityOfInfo.Data.Mids.Tests
{
    public class ReaderTest
    {
        public Action<BinaryWriter> Setup { get; set; }
        public Action<BinaryReader> Test { get; set; }

        public ReaderTest(Action<BinaryWriter> setup, Action<BinaryReader> test)
        {
            Setup = setup;
            Test = test;
        }

        public void Run()
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var binaryWriter = new BinaryWriter(memoryStream, Encoding.Default, true))
                {
                    Setup(binaryWriter);
                }

                memoryStream.Seek(0, SeekOrigin.Begin);

                using (var binaryReader = new BinaryReader(memoryStream))
                {
                    Test(binaryReader);
                }
            }
        }
    }
}
