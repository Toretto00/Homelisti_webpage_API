namespace homelisti_API.Models.Domain
{
    public class User
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string  last_name { get; set; }
        public string username { get; set; }
        public Contact contact { get; set; }
        public Account account { get; set; }
    }
}
