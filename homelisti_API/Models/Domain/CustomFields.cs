using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace homelisti_API.Models.Domain
{
    public class CustomFields
    {
        [Key]
        public int id { get; set; }
        public string label { get; set; }
        public Choices[] value { get; set; }
        public Options[] options { get; set; }
    }
}
