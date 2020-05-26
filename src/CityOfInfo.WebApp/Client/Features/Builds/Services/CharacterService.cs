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
            using (var reader = new BinaryReader(new CompressionDataStream(request.CompressionData)))
            {
                var characterReader = new CharacterReader(reader);
                return Map(characterReader.Read());
            }
        }

        private static readonly int SelectedPowerColumnCount = 3;
        private static readonly int SelectedPowerColumnHeight = 8;
        private static readonly int SelectedPowerCount = SelectedPowerColumnCount * SelectedPowerColumnHeight;

        private ViewModels.Character Map(Data.Mids.Builds.Character character)
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
                var power = build.PowerSlots[p];
                var isInherant = p >= SelectedPowerCount;
                var columnIndex = p % SelectedPowerColumnCount;                                

                List<ViewModels.PowerSlot> currentColumn;
                if (!isInherant)                
                    currentColumn = AddOrGetCurrentColumn(result.Build.SelectedPowerColumns, columnIndex);
                else
                    currentColumn = AddOrGetCurrentColumn(result.Build.InherentPowerColumns, columnIndex);

                AddSelectedPower(currentColumn, power);
            }

            return result;
        }

        private void AddSelectedPower(List<ViewModels.PowerSlot> currentColumn, Data.Mids.PowerSlot power)
        {   
            var powerSlotPresent = !(power is null);
            var powerSelectionPresent = !(power?.Power is null);

            var powerSlot = new ViewModels.PowerSlot
            {
                Name = power?.Power?.Name,
                ShowPowerName = powerSelectionPresent,
                ShowPowerLevel = powerSlotPresent,
                PowerIsSelected = powerSelectionPresent,
            };

            currentColumn.Add(powerSlot);
        }

        private List<ViewModels.PowerSlot> AddOrGetCurrentColumn(List<List<ViewModels.PowerSlot>> powerColumns, int columnIndex)
        {            
            List<ViewModels.PowerSlot> currentColumn;
            if (powerColumns.Count <= columnIndex + 1)
            {
                currentColumn = new List<ViewModels.PowerSlot>();
                powerColumns.Insert(columnIndex, currentColumn);
            }
            else
            {
                currentColumn = powerColumns[columnIndex];
            }
            return currentColumn;
        }
    }
}
