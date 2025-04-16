using AuthorProject.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace AuthorProject.Applications.BookOperations.BookQuery
{
    public class BookDetailQuery
    {
        private readonly MsSqlDbContext _context;
        public int BookId { get; set; }
        public BookDetailQuery(MsSqlDbContext context)
        {
            _context = context;
        }

        public BookDetailViewModel Handle()
        {
            var book = _context.Books
                .Include(x => x.Genre)
                .Include(x => x.Author)
                .FirstOrDefault(x => x.Id == BookId);
            if (book is null)
                throw new InvalidOperationException("Kitap Bulunamadı!");
            return new BookDetailViewModel
            {
                Id = book.Id,
                Title = book.Title,
                Genre = book.Genre.Name,
                Author = book.Author.Name,

            };
        }
    }


    public class BookDetailViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }

    }

}
