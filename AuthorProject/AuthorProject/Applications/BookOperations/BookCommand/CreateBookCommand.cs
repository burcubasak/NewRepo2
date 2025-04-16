using AuthorProject.DbContexts;
using AuthorProject.Entities;
using AutoMapper;

namespace AuthorProject.Applications.BookOperations.BookCommand
{
    public class CreateBookCommand
    {

        public CreateBookViewModel Model { get; set; }
        private readonly MsSqlDbContext _context;
        private readonly IMapper _mapper;

        public CreateBookCommand(MsSqlDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.Title == Model.Title);
            if (book is not null)
                throw new InvalidOperationException("Book already exists.");
            book = _mapper.Map<Book>(Model);

            _context.Books.Add(book);
            _context.SaveChanges();
        }
    }

    public class CreateBookViewModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int GenreId { get; set; }
        public DateTime PublishDate { get; set; }
        public bool IsActive { get; set; } = true;
    }
}