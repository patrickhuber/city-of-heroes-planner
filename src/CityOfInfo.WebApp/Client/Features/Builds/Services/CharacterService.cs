using CityOfInfo.Data.Mids;
using CityOfInfo.Data.Mids.Builds;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CityOfInfo.WebApp.Client.Features.Builds.Services
{
    public class CharacterService : ICharacterService
    {
        public ViewModels.Character Read(CharacterReadRequest request)
        {
            using var reader = new BinaryReader(new CompressionDataStream(request.CompressionData));
            var characterReader = new CharacterReader(reader);
            return Map(characterReader.Read());
        }

        private static readonly int SelectedPowerCount = 24;

        private ViewModels.Character Map(Character character)
        {
            var result = new ViewModels.Character 
            {
                Name = character.Name,
                AlignmentName = character.Alignment.Name,
                ArchetypeName = character.Archetype.DisplayName,
                Origin = character.Archetype.Origins.FirstOrDefault() ?? "unknown",
            };

            var build = character.Builds.FirstOrDefault();
            if (build is null)
                return result;

            for (var p = 0; p < build.PowerSlots.Count; p++)
            {
                var powerSlotViewModel = Map(build.PowerSlots[p]);

                if (p <= SelectedPowerCount)
                    result.Build.SelectedPowers.Add(powerSlotViewModel);
                else
                    result.Build.InherentPowers.Add(powerSlotViewModel);
            }

            return result;
        }

        private ViewModels.PowerSlot Map(PowerSlot powerSlot)
        {
            var powerSlotViewModel = new ViewModels.PowerSlot();
            return powerSlotViewModel;
        }
    }
}
