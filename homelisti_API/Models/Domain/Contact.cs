using System.ComponentModel.DataAnnotations;

namespace homelisti_API.Models.Domain
{
    public class Contact
    {
        public Locations location { get; set; }
        public string address { get; set; }
        [Key]
        public string phone { get; set; }
        public string whatsapp_number { get; set; }
        public string email { get; set; }
    }
}
