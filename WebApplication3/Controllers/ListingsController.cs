using homelisti_API.Models.Domain;
using HomelistiAPI.Db;
using Microsoft.IdentityModel.Tokens;
using Ninject.Activation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.UI.WebControls;
using WebApplication3;

namespace HomelistiAPI.Controllers
{
    public class ListingsController : ApiController
    {
        [HttpGet]
        public List<ListingDTO> Get()
        {
            var _dbContext = new HomelistiDbEntities();
            List<ListingDTO> list = WebApiApplication._mapper.Map<List<ListingDTO>>(_dbContext.Listings.ToList());
            foreach (var item in list)
            {
                List<CustomFieldDTO> custom_fields = WebApiApplication._mapper.Map<List<CustomFieldDTO>>(_dbContext.Listings_CustomFields
                .Where(c => c.listing_id == item.listing_id)
                .Select(c => c.CustomField)
                .ToList());

                foreach (var temp in custom_fields)
                {
                    List<ChoiceDTO> choices = WebApiApplication._mapper.Map<List<ChoiceDTO>>(_dbContext.CustomFields_Choices
                    .Where(c => c.custom_fields_id == temp.id)
                    .Select(c => c.Choice)
                    .ToList());
                    temp.choices = choices.ToArray();

                    List<ValueeDTO> values = WebApiApplication._mapper.Map<List<ValueeDTO>>(_dbContext.CustomFields_Values
                    .Where(c => c.custom_fields_id == temp.id && c.listing_id == item.listing_id)
                    .Select(c => c.Valuess)
                    .ToList());
                    temp.value = values.ToArray();
                }

                item.custom_fields = custom_fields.ToArray();

            }
            return list;
        }

        [HttpGet]
        public List<ListingDTO> Get(int id)
        {
            var _dbContext = new HomelistiDbEntities();
            List<ListingDTO> list = WebApiApplication._mapper.Map<List<ListingDTO>>(_dbContext.Listings
                .Where(c => c.listing_id == id)
                .ToList());
            foreach (var item in list)
            {
                List<CustomFieldDTO> custom_fields = WebApiApplication._mapper.Map<List<CustomFieldDTO>>(_dbContext.Listings_CustomFields
                .Where(c => c.listing_id == item.listing_id)
                .Select(c => c.CustomField)
                .ToList());

                foreach (var temp in custom_fields)
                {
                    List<ChoiceDTO> choices = WebApiApplication._mapper.Map<List<ChoiceDTO>>(_dbContext.CustomFields_Choices
                    .Where(c => c.custom_fields_id == temp.id)
                    .Select(c => c.Choice)
                    .ToList());
                    temp.choices = choices.ToArray();

                    List<ValueeDTO> values = WebApiApplication._mapper.Map<List<ValueeDTO>>(_dbContext.CustomFields_Values
                    .Where(c => c.custom_fields_id == temp.id && c.listing_id == item.listing_id)
                    .Select(c => c.Valuess)
                    .ToList());
                    temp.value = values.ToArray();
                }

                item.custom_fields = custom_fields.ToArray();

            }
            return list;
        }
        [HttpGet]
        [Route("api/Listings/filter")]
        public List<ListingDTO> Search(string title, string type, int category_id, int location_id, int min_price, int max_price)
        {
            var _dbContext = new HomelistiDbEntities();
            List<ListingDTO> list = WebApiApplication._mapper.Map<List<ListingDTO>>(_dbContext.Listings.ToList());

            if (title != "null" && title != "" && title != null)
            {
                list = list.FindAll(x => x.title.Contains(title));
            }
            if(type != "null" && (type == "sell" || type == "buy" || type == "rent"))
            {
                list = list.FindAll(x => x.listingtype.id == type);
            }
            if (category_id != 0 && list.Find(x => x.category.term_id == category_id) != null)
            {
                list = list.FindAll( x=> x.category.term_id == category_id);
            }
            if(location_id != 0)
            {
                list = list.FindAll(x => x.contact.location.term_id == location_id);
            }
            if (min_price != 0)
            {
                list = list.FindAll(x => Int64.Parse(x.price.Replace(",","")) >= min_price);
            }
            if (min_price != 10000000)
            {
                list = list.FindAll(x => Int64.Parse(x.price.Replace(",", "")) <= max_price);
            }

            return list;
        }
        [HttpPost]
        [Authorize]
        public Listing Post(int listing_id, int author_id, string title, string price, int category_id, string listing_type, int contact_id)
        {
            var _dbContext = new HomelistiDbEntities();
            Listing listing = new Listing();
            listing.listing_id = listing_id;
            listing.author_id = author_id;
            listing.title = title;
            listing.price = price;
            listing.category_term_id = category_id;
            listing.ad_type_id = listing_type;
            listing.view_count = 0;
            listing.contact_id = contact_id;
            _dbContext.Listings.Add(listing);
            _dbContext.SaveChanges();
            return listing;
        }
    }
}
