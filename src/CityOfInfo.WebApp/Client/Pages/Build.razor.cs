using CityOfInfo.Data.Mids;
using CityOfInfo.Data.Mids.Builds;
using CityOfInfo.WebApp.Shared;
using Microsoft.AspNetCore.Components;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace CityOfInfo.WebApp.Client.Pages
{
    public partial class Build : ComponentBase
    {
        protected CompressionData CompressionData { get; set; }
        protected Data.Mids.Builds.Character CharacterData { get; set; }
        protected string CharacterYaml { get; set; }

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
            var characterReader = new CharacterReader(
                new BinaryReader(compressionDataStream));
            CharacterData = characterReader.Read();
            var serializer = new SerializerBuilder()
                .WithNamingConvention(UnderscoredNamingConvention.Instance)                
                .Build();
            CharacterYaml = serializer.Serialize(CharacterData);
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


        private PowerSlot GetPowerAtIndex(int powerIndex)
        {
            if (this.CharacterData.Builds.Count < 1)
                return null;
            var build = this.CharacterData.Builds[0];
            if (build.PowerSlots.Count < powerIndex)
                return null;
            return build.PowerSlots[powerIndex];
        }


        private string GetPowerName(PowerSlot power)
        {
            if (power == null)
                return "( )";

            var name = new System.Text.StringBuilder();
            name.AppendFormat("({0}) ", power.Level + 1);

            if (power.Power is null)
                return name.ToString();

            if (string.IsNullOrWhiteSpace(power.Power.Display))
                name.Append(power.Power.Index);
            else
                name.Append(power.Power.Display);

            return name.ToString();
        }

        private EnhancementSlot GetEnhancementSlotAtIndex(PowerSlot power, int index)
        {
            if (power == null)
                return null;

            if (power.EnhancementSlots.Count < index)
                return null;

            return power.EnhancementSlots[index];
        }
    }
}
