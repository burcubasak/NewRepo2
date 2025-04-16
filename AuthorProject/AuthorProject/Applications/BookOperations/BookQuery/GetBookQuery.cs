using AuthorProject.DbContext;
using AuthorProject.DbContexts;

namespace AuthorProject.Applications.BookOperations.BookQuery
{
    public class GetBookQuery
    {
        private readonly IMsSqlDbContext _context;
        public int BookId { get; set; }
        public GetBookQuery(MsSqlDbContext context)
        {
            _context = context;

        }

        public List<BookViewModel> Handle()
        {
            var books = _context.Books.Where(x => x.IsActive == true).OrderBy(x => x.Id);
            List<BookViewModel> obj = new List<BookViewModel>();
            foreach (var book in books)
            {
                BookViewModel bookViewModel = new BookViewModel();
                bookViewModel.BookId = book.Id;
                bookViewModel.Title = book.Title;
                obj.Add(bookViewModel);
            }
            return obj;
        }




    }

    public class BookViewModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; } = true;
    }

}
