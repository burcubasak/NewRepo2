using AuthorProject.DbContexts;
using AutoMapper;

namespace AuthorProject.Applications.BookOperations.BookCommand
{
    public class UpdateBookCommand
    {
        public UpdateBookModel Model { get; set; }
        public int BookId { get; set; }
        private readonly MsSqlDbContext _context;
        private readonly IMapper _mapper;
        public UpdateBookCommand(MsSqlDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == BookId);
            if (book is null)
                throw new InvalidOperationException("Book not found!");
            book.Title = Model.Title != default ? Model.Title : book.Title;
            
            book.AuthorId = Model.AuthorId != default ? Model.AuthorId : book.AuthorId;
            _context.SaveChanges();
        }
    }
    public class UpdateBookModel
    {
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public int AuthorId { get; set; }
    }
}
