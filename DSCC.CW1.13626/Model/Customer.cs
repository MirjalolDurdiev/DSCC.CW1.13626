using System.ComponentModel.DataAnnotations;

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
        public string PhoneNumber { get; set; }

        public ICollection<Order> Orders
        {
            get; set;
        }
    }
}
