using CityOfInfo.Data.Mids;
using CityOfInfo.WebApp.Client.Features.Builds.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityOfInfo.WebApp.Client.Features.Builds.Services
{
    public class CharacterReadRequest
    { 
        public CompressionData CompressionData { get; set; }
    }

    public interface ICharacterService
    {
        public Character Read(CharacterReadRequest request);
    }
}
