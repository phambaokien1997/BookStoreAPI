using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    [Table("OrderDetails")]
    public class OrderDetail
    {
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
