using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    [Table("BookGenres")]
    public class BookGenre
    {
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }
        public int GenreId { get; set; }
        [ForeignKey("GenreId")]
        public virtual Genre Genre { get; set; }
    }
}
