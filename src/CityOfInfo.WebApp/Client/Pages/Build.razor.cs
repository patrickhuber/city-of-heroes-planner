using CityOfInfo.Data.Mids;
using CityOfInfo.WebApp.Shared;
using Microsoft.AspNetCore.Components;
using System.IO;

namespace CityOfInfo.WebApp.Client.Pages
{
    public partial class Build : ComponentBase
    {
        protected CompressionData CompressionData { get; set; }
        protected CityOfInfo.Data.Mids.Build BuildData { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        protected override void OnInitialized()
        {
            if (TryBindMidsCompressionData(out var compressionData))
            {
                CompressionData = compressionData;
            }
            else if (TryBindBase64CompressionData(out compressionData))
            {
                CompressionData = compressionData;
            }
            else { return; }

            var compressionDataStream = new CompressionDataStream(CompressionData);
            var buildReader = new BuildReader(
                new BinaryReader(compressionDataStream));
            BuildData = buildReader.Read();
        }

        private bool TryBindMidsCompressionData(out CompressionData compressionData)
        {
            compressionData = null;
            if (!NavigationManager.TryGetQueryString<int>("uc", out var uncompressedByteCount))
                return false;

            if (!NavigationManager.TryGetQueryString<int>("c", out var compressedByteCount))
                return false;

            if (!NavigationManager.TryGetQueryString<int>("a", out var encodedByteCount))
                return false;

            if (!NavigationManager.TryGetQueryString<string>("f", out var format))
                return false;

            if (!NavigationManager.TryGetQueryString<string>("dc", out var encodedData))
                return false;

            compressionData = new CompressionData
            {
                UncompressedByteCount = uncompressedByteCount,
                CompressedByteCount = compressedByteCount,
                EncodedByteCount = encodedByteCount,
                EncodedString = encodedData,
                Encoding = format,
            };
            return true;
        }

        private bool TryBindBase64CompressionData(out CompressionData compressionData)
        {
            compressionData = null;
            return false;
        }
    }
}
