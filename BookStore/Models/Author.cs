using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    [Table("Authors")]
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public virtual ICollection<BookAuthor> BookAuthors { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }
    }
}
