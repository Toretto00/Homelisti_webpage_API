using homelisti_API.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using HomelistiAPI.Db;
using AutoMapper;

namespace WebApplication3.Controllers
{

    public class ListingTypesController : ApiController
    {
        // GET api/values
        public List<ListingTypeDTO> Get()
        {
            var _dbContext = new HomelistiDbEntities();
            List<ListingTypeDTO> list = WebApiApplication._mapper.Map<List<ListingTypeDTO>>(_dbContext.ListingTypes.ToList());
            return list;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
