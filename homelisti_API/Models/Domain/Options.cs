using System.ComponentModel.DataAnnotations;

namespace homelisti_API.Models.Domain
{
    public class Options
    {
        [Key]
        public string defaults { get; set; }
        public Choices[] choices { get; set; }
    }
}
