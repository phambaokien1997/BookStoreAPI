using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    [Table("Orders")]
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string OrderStatus { get; set; }
        public string ShippingAddress { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
    }
}
