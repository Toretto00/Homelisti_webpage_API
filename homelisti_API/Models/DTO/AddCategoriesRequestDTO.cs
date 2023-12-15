using System.ComponentModel.DataAnnotations;

namespace homelisti_API.Models.DTO
{
    public class AddCategoriesRequestDTO
    {
        [Key]
        public int term_id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public int count { get; set; }
    }
}
