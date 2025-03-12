using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    [Table("Publishers")]
    public class Publisher
    {//Name Description Address ContactEmail PhoneNumber
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }

        public string ContactEmail { get; set; }
        public string PhoneNumber { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
