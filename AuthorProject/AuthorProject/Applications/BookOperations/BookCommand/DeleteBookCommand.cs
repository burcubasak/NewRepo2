using AuthorProject.DbContexts;

namespace AuthorProject.Applications.BookOperations.BookCommand
{
    public class DeleteBookCommand
    {
        public int BookId { get; set; }
        private readonly MsSqlDbContext _context;
        public DeleteBookCommand(MsSqlDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == BookId);
            if (book is null)
                throw new InvalidOperationException("Book not found");
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
    public class DeleteBookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
