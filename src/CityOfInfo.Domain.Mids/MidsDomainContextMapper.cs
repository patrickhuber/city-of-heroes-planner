using CityOfInfo.Data.Mids;
using CityOfInfo.Domain.EntityFramework;

namespace CityOfInfo.Domain.Mids
{
    public class MidsDomainContextMapper
    {
        private readonly DomainContext _domainContext;
        private int _powerReadCount = 0;
        private int _enhancementReadCount = 0;
        private static readonly int  BatchSize = 100;

        public MidsDomainContextMapper(DomainContext domainContext)
        {
            _domainContext = domainContext;
        }

        public void Register(DatabaseReader databaseReader)
        {
            databaseReader.OnPowerRead += (power) => 
            {
                _domainContext.Add(Map(power));
                _powerReadCount++;
                if (_powerReadCount < BatchSize)
                    return;
                _domainContext.SaveChanges();
                _powerReadCount = 0;
            };
            databaseReader.OnPowersCompleted += () =>
            {
                _domainContext.SaveChanges();
            };
        }

        public void Register(EnhancementDatabaseReader enhancementDatabaseReader)
        {
            enhancementDatabaseReader.OnEnhancementRead += (enhancement) =>
            {
                _domainContext.Add(Map(enhancement));
                _enhancementReadCount++;
                if (_enhancementReadCount < BatchSize)
                    return;
                _domainContext.SaveChanges();
                _enhancementReadCount = 0;
            };
            enhancementDatabaseReader.OnEnhancementsCompleted += () =>
            {
                _domainContext.SaveChanges();
            };
        }

        /// <summary>
        /// Maps a mids power into a domain power
        /// </summary>
        /// <param name="power"></param>
        /// <returns></returns>
        private Power Map(Data.Mids.Power power)
        {
            return new Power
            {
                Id = power.Index,
                Name = power.Name,
                Description = power.DescriptionShort,
                LongDescription = power.DescriptionLong,
                Display = power.Display,
            };
        }

        /// <summary>
        /// Maps a mids enhancement into a domain enhancement
        /// </summary>
        /// <param name="enhancement"></param>
        /// <returns></returns>
        private Enhancement Map(Data.Mids.Enhancement enhancement)
        {
            return new Enhancement
            {
                Id = enhancement.Index,
                Name = enhancement.Name
            };
        }
    }
}
