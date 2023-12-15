using homelisti_API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace homelisti_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly HomelistiDbContext dbContext;

        public LocationsController(HomelistiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var locations = dbContext.Locations.ToList();

            return Ok(locations);
        }
    }
}
