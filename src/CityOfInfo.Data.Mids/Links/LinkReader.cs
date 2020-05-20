using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CityOfInfo.Data.Mids.Links
{
    public class LinkReader
    {
        private readonly TextReader _reader;

        public LinkReader(TextReader reader)
        {
            _reader = reader;
        }

        public Link Read()
        {
            var uri = new Uri(_reader.ReadToEnd());
            var query = QueryHelpers.ParseQuery(uri.Query);
            
            var compressionData = new CompressionData 
            {                 
                CompressedByteCount = int.Parse(query["c"]),
                EncodedByteCount = int.Parse(query["a"]),
                UncompressedByteCount = int.Parse(query["uc"]),
                EncodedString = query["dc"],
                Encoding = query["f"],
                
            };
            return new Link
            {
                CompressionData = compressionData,
            };
        }
    }
}
