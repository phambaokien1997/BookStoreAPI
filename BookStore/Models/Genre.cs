using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    [Table("Genres")]
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<BookGenre> BookGenres { get; set; }

        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public virtual Author Author { get; set; }
    }
}
