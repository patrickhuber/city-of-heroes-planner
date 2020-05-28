using CityOfInfo.Data.Mids;
using CityOfInfo.Domain.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityOfInfo.Domain.Mids
{
    public class MidsDomainContextLoader : IDomainContextLoader
    {
        private readonly DatabaseReader _databaseReader;
        private readonly EnhancementDatabaseReader _enhancementDatabaseReader;

        public MidsDomainContextLoader(DatabaseReader databaseReader, EnhancementDatabaseReader enhancementDatabaseReader)
        {
            _databaseReader = databaseReader;
            _enhancementDatabaseReader = enhancementDatabaseReader;
        }

        public void Load(DomainContext context)
        {
            var mapper = new MidsDomainContextMapper(context);
            mapper.Register(_databaseReader);
            mapper.Register(_enhancementDatabaseReader);

            while (_databaseReader.Read()) ;
            context.SaveChanges();

            while (_enhancementDatabaseReader.Read()) ;
            context.SaveChanges();
        }
    }
}
