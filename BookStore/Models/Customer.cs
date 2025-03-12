using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    [Table("Customers")]
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
