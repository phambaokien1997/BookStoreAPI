using BookStore.DTOs;
using BookStore.Models;

namespace BookStore.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookDTO>> GetBooksAsync();
        Task<BookDTO> GetBookAsync(int id);
        Task AddBookAsync(BookDTO bookDto);
        Task UpdateBookAsync(BookDTO bookDto);
        Task DeleteBookAsync(int id);
    }
}
