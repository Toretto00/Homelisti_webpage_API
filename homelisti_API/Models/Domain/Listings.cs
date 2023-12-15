using System.ComponentModel.DataAnnotations;

namespace homelisti_API.Models.Domain
{
    public class Listings
    {
        [Key]
        public int listing_id { get; set; }
        public int author_id { get; set; }
        public string title { get; set; }
        public string price { get; set; }
        public string price_type { get; set; }
        public Categories categories { get; set; }
        public ListingTypes ad_type { get; set; }
        public Images[] images { get; set; }
        public int view_count { get; set; }
        public Contact contact { get; set; }
        public CustomFields[] custom_fields { get; set; }
    }
}
