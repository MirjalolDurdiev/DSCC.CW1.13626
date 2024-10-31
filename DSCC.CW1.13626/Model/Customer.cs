using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DSCC.CW1._13626.Model
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [StringLength(100)]
        public string PhoneNumber { get; set; }

        [JsonIgnore]
        public ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
