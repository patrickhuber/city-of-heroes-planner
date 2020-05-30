using CityOfInfo.Data.Mids;
using CityOfInfo.Data.Mids.Builds;
using CityOfInfo.WebApp.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.Data.Sqlite;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using TG.Blazor.IndexedDB;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace CityOfInfo.WebApp.Client.Pages
{
    public partial class Build : ComponentBase
    {
        protected CompressionData CompressionData { get; set; }
        protected Character CharacterData { get; set; }
        protected string CharacterYaml { get; set; }
        protected string DatabaseLoadStatus { get; set; }

        private static readonly int SelectedPowerColumnHeight = 8;
        private static readonly int SelectedPowerColumnCount = 3;
        private static readonly int InherentPowerStartIndex = SelectedPowerColumnCount * SelectedPowerColumnHeight;
        private static readonly int InherentPowerColumnCount = 3;

        [Inject]
        NavigationManager NavigationManager { get; set; }

        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }

        [Inject]
        public IndexedDBManager IndexedDBManager { get; set; }

        public class Power 
        {
            [System.ComponentModel.DataAnnotations.Key]
            public int Id { get; set; }

            public string Name { get; set; }
        }

        protected override async Task OnInitializedAsync()
        {
            await PopulateDatabaseAsync();

            if (TryBindMidsCompressionData(out var compressionData))
                CompressionData = compressionData;
            else { return; }

            CharacterData = CreateCharacterData(CompressionData);
            CharacterYaml = CreateCharacterYaml(CharacterData);
        }

        private async Task PopulateDatabaseAsync() 
        {
            // load database from blob uri
            var key = "homecoming-19-1021004.zip";
            var client = ClientFactory.CreateClient(Globals.DatabaseBlobClient);
            var response = await client.GetAsync($"{key}");

            DatabaseLoadStatus = response.IsSuccessStatusCode ? "Success" : "Failure";

            var powers = new Power[] 
            {
                new Power { Id = 0, Name = "Single_Shot" },
                new Power { Id = 1, Name = "Pummel" },
            };

            foreach (var power in powers)
            {
                var p = await IndexedDBManager.GetRecordById<int, Power>("Powers", power.Id);
                var record = new StoreRecord<Power>
                {
                    Storename = "Powers",
                    Data = power,
                };
                if (p == null)
                    await IndexedDBManager.AddRecord(record);                
                else 
                    await IndexedDBManager.UpdateRecord(record);
            }            
        }

        private string CreateCharacterYaml(Character characterData)
        {
            var serializer = new SerializerBuilder()
                            .WithNamingConvention(UnderscoredNamingConvention.Instance)
                            .Build();
            return serializer.Serialize(characterData);
        }

        private Character CreateCharacterData(CompressionData compressionData)
        {
            var compressionDataStream = new CompressionDataStream(compressionData);
            var characterReader = new CharacterReader(
                new BinaryReader(compressionDataStream));
            return characterReader.Read();
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
    }
}
