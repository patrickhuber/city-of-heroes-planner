using System;
using System.Collections.Generic;
using System.Text;

namespace CityOfInfo.WebApp.Shared
{
    public static class Globals
    {
        public static readonly Uri DatabaseBlobBaseAddress = new Uri("https://cityofheroes.blob.core.windows.net/databases/");
        public static readonly string DatabaseBlobClient = "DatabaseBlobs";
    }
}
