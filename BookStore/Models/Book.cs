using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    [Table("Books")]
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime PublicationDate { get; set; }

        public virtual ICollection<BookAuthor> BookAuthors { get; set; }

        public virtual ICollection<BookGenre> BookGenres { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public int PublisherId { get; set; }
        [ForeignKey("PublisherId")]
        public virtual Publisher Publisher { get; set; }

    }
}
