using AuthorProject.DbContext;
using AuthorProject.DbContexts;
using AuthorProject.Entities;

using AutoMapper;

namespace AuthorProject.Applications.GenreOperations.GenreCommand
{
    public class CreateGenreCommand
    {
        public GenreModel Model { get; set; }

        private readonly IMapper _mapper;
        private readonly IMsSqlDbContext _context;
        public CreateGenreCommand(IMapper mapper, IMsSqlDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public void Handle()
        {
            var createGenre = _context.Genres.FirstOrDefault(x => x.Name == Model.Name);
            if (createGenre != null)
                throw new InvalidOperationException("Kitap Türü Zaten Mevcut");

            var genre = new Genre();
            genre.Name = Model.Name;
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }
    }

    public class GenreModel
    {
        public string Name { get; set; }
    }
}

