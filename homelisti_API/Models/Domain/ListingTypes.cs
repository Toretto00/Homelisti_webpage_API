using System.ComponentModel.DataAnnotations;

namespace homelisti_API.Models.Domain
{
    public class ListingTypes
    {
        [Key]
        public string id { get; set; }
        public string name { get; set; }
    }
}
