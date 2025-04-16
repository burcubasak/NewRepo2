using AuthorProject.DbContext;
using AuthorProject.DbContexts;

namespace AuthorProject.Applications.GenreOperations.GenreCommand
{
    public class DeleteGenreCommand
    {

        public int GenreId { get; set; }
        private readonly IMsSqlDbContext _context;
        public DeleteGenreCommand(IMsSqlDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId);
            if (genre is null)
                throw new InvalidOperationException("Kitap Türü Bulunamadı");
            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }

    
    }
}
