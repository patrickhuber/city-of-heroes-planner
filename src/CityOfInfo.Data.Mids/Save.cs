using System;
using System.Collections.Generic;
using System.Text;

namespace CityOfInfo.Data.Mids
{
    public class Save
    {
        public CompressionData CompressionData { get; set; }
        public string Format { get; set; }

        public Save()
        {
            CompressionData = new CompressionData();
        }
    }
}
