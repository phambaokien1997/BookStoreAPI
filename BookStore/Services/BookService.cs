using BookStore.DTOs;
using BookStore.Models;
using BookStore.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;

namespace BookStore.Services
{
    public class BookService : IBookService
    {
        private readonly IGenericRepository<Book> _repository;
        public BookService(IGenericRepository<Book> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<BookDTO>> GetBooksAsync()
        {
            var books = await _repository.GetAllAsync();
            var bookDtos = books.Select(b => new BookDTO()
            {
                Id = b.Id,
                Name = b.Name,
                Description = b.Description,
                Price = b.Price,
                Quantity = b.Quantity,
                PublicationDate = b.PublicationDate,
                AuthorIds = b.BookAuthors.Select(ba => ba.AuthorId).ToList(),
                GenreIds = b.BookGenres.Select(bg => bg.GenreId).ToList(),
                PublisherId = b.PublisherId
            });
            return bookDtos;
        }
        public async Task<BookDTO> GetBookAsync(int id)
        {
            var book = await _repository.GetByIdAsync(id);
            var bookDto = new BookDTO()
            {
                Id = book.Id,
                Name = book.Name,
                Description = book.Description,
                Price = book.Price,
                Quantity = book.Quantity,
                PublicationDate = book.PublicationDate,
                AuthorIds = book.BookAuthors.Select(ba => ba.AuthorId).ToList(),
                GenreIds = book.BookGenres.Select(bg => bg.GenreId).ToList(),
                PublisherId = book.PublisherId
            };
            return bookDto;
        }
        public async Task AddBookAsync(BookDTO bookDto)
        {
            //var listBookAuthor = new List<BookAuthor>();
            //foreach(var authorIds in bookDto.AuthorIds)
            //{
            //    listBookAuthor.Add(new BookAuthor()
            //    {
            //        AuthorId = authorIds,
            //    });
            //}
            //var listBookGenre = new List<BookGenre>();
            //foreach(var genreIds in bookDto.GenreIds)
            //{
            //    listBookGenre.Add(new BookGenre()
            //    {
            //        GenreId = genreIds
            //    });
            //}
            if (bookDto == null) throw new ArgumentNullException(nameof(bookDto));
            var listBookAuthor = bookDto.AuthorIds.Select(aid => new BookAuthor { AuthorId = aid}).ToList();
            var listBookGenre = bookDto.GenreIds.Select(gid => new BookGenre { GenreId = gid }).ToList();
            var book = new Book()
            {
                Name = bookDto.Name,
                Description = bookDto.Description,
                Price = bookDto.Price,
                Quantity = bookDto.Quantity,
                PublicationDate = bookDto.PublicationDate,
                PublisherId = bookDto.PublisherId,
                BookAuthors = listBookAuthor,
                BookGenres = listBookGenre
            };
            await _repository.AddAsync(book);
            await _repository.SaveChangesAsync();
        }
        public async Task UpdateBookAsync(BookDTO bookDto)
        {
            if (bookDto == null) throw new ArgumentNullException(nameof(bookDto));
            var book = await _repository.GetByIdAsync(bookDto.Id);
            if(book == null)
            {
                throw new Exception("Book Not Found!");
            }
            book.Name = bookDto.Name;
            book.Description = bookDto.Description;
            book.Price = bookDto.Price;
            book.Quantity = bookDto.Quantity;
            book.BookAuthors = bookDto.AuthorIds.Select(aid => new BookAuthor { AuthorId = aid ,Book = book}).ToList();
            book.BookGenres = bookDto.GenreIds.Select(gid => new BookGenre { GenreId = gid, Book = book }).ToList();
            book.PublisherId = bookDto.PublisherId;
            await _repository.UpdateAsync(book);
            await _repository.SaveChangesAsync();
        }
        public async Task DeleteBookAsync(int id)
        {
            await _repository.DeleteAsync(id);
            await _repository.SaveChangesAsync();
        }
    }
}
