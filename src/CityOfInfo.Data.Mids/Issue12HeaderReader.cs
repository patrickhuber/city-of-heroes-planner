using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CityOfInfo.Data.Mids
{
    public class Issue12HeaderReader
    {
        private BinaryReader _reader;

        public Issue12HeaderReader(BinaryReader reader)
        {
            _reader = reader;
        }

        public Issue12Header Read()
        {
            var header = new Issue12Header();
            header.Description = _reader.ReadString();
            header.Version = _reader.ReadSingle();

            var year = _reader.ReadInt32();
            var dateIsYearMonthDate = year > 0;
            if (dateIsYearMonthDate)
            {
                var month = _reader.ReadInt32();
                var day = _reader.ReadInt32();
                header.Date = new DateTime(year, month, day);
            }
            else
            {
                header.Date = DateTime.FromBinary(_reader.ReadInt64());
            }
            header.Issue = _reader.ReadInt32();
            return header;
        }
    }
}
