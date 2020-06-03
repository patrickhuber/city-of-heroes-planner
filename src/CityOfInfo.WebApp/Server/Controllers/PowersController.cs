using CityOfInfo.Domain;
using CityOfInfo.Domain.EntityFramework;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CityOfInfo.WebApp.Server.Controllers
{

    [ApiController]
    [Route("odata/[controller]")]
    public class PowersController : ODataController
    {
        private readonly DomainContext domainContext;

        public PowersController(DomainContext domainContext)
        {
            this.domainContext = domainContext;
        }

        [EnableQuery(PageSize = 100)]
        public IQueryable<Power> Get()
        {
            return domainContext.Powers;
        }
    }
}
