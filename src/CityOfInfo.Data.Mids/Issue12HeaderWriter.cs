using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CityOfInfo.Data.Mids
{
    public class Issue12HeaderWriter
    {
        private BinaryWriter _writer;

        public Issue12HeaderWriter(BinaryWriter writer)
        {
            _writer = writer;
        }

        public void Write(Issue12Header issue12Header)
        {
            _writer.Write(issue12Header.Description);
            _writer.Write(issue12Header.Version);
            _writer.Write(0);
            _writer.Write(issue12Header.Date.ToBinary());
            _writer.Write(issue12Header.Issue);
        }
    }
}
