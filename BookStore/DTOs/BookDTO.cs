namespace BookStore.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime PublicationDate { get; set; }
        public List<int> AuthorIds { get; set; } = new List<int>();
        public List<int> GenreIds { get; set; } = new List<int>();
        public int PublisherId { get; set; }


    }
}
