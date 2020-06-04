using CityOfInfo.WebApp.Server.Models;
using CityOfInfo.WebApp.Shared;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CityOfInfo.WebApp.Server.Controllers
{
    [ApiController]
    [Route("odata/[controller]")]
    public class DatabasesController : ODataController
    {
        private readonly DatabaseContext _databaseContext;

        public DatabasesController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [EnableQuery(PageSize = 100)]
        public IQueryable<Database> Get()
        {
            return _databaseContext.Databases;
        }
    }
}
