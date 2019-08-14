using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityOfHeroesPlanner.Data.AzureTables
{
    public class AzureTableDataContext
    {
        private readonly CloudTableClient _tableClient;
    }
}
