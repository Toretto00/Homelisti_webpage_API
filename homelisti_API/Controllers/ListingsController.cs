using homelisti_API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace homelisti_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingsController : ControllerBase
    {
        private readonly HomelistiDbContext dbContext;

        public ListingsController(HomelistiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var listings = dbContext.Listings.ToList();

            return Ok(listings);
        }
    }
}
