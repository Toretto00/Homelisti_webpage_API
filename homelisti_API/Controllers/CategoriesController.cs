using homelisti_API.Data;
using homelisti_API.Models.Domain;
using homelisti_API.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace homelisti_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly HomelistiDbContext dbContext;

        public CategoriesController(HomelistiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var categories = dbContext.Categories.ToList();

 
            return Ok(categories);
        }

        [HttpPost]
        public IActionResult Create([FromBody] AddCategoriesRequestDTO addCategoriesRequestDTO)
        {
            var categoriesDomainModel = new Categories
            {
                term_id = addCategoriesRequestDTO.term_id,
                name = addCategoriesRequestDTO.name,
                slug = addCategoriesRequestDTO.slug,
                count = addCategoriesRequestDTO.count
            };

            dbContext.Categories.Add(categoriesDomainModel);
            dbContext.SaveChanges();

            return CreatedAtAction(categoriesDomainModel.name, categoriesDomainModel);

    }
}
}
