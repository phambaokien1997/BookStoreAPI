using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    [Table("BookAuthors")]
    public class BookAuthor
    {
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }

        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public DateTime DateOfWriting { get; set; }
    }
}
