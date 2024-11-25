using BooksStore.Core.Models;
using BookStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccess.Repository
{
    public class BookRepository
    {
        private readonly BookStoreDbContext context;

        public BookRepository(BookStoreDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Book>> Get()
        {
            var bookEntities = await context.Books.AsNoTracking().ToListAsync();
            var books = bookEntities.Select(b => Book.Create(b.Id, b.Title, b.Description, b.Price).book)
                .ToList();
            return books;
        }
        public async Task<Guid> Create(Book book)
        {
            var bookEntiity = new BookEntity() {
                Id = book.Id,
                Description = book.Description,
                Price = book.Price,
                Title = book.Title,
            
            };    
            await context.Books.AddAsync(bookEntiity);
            await context.SaveChangesAsync();
            return bookEntiity.Id;
        }
    }
}
