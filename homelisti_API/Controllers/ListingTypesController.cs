using homelisti_API.Data;
using homelisti_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace homelisti_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingTypesController : ControllerBase
    {
        private readonly HomelistiDbContext dbContext;

        public ListingTypesController(HomelistiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {

            var types = dbContext.ListingTypes.ToList();

            return Ok(types);
        }
    }
}
