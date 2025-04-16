using AuthorProject.DbContext;
using AuthorProject.DbContexts;
using AutoMapper;

namespace AuthorProject.Applications.GenreOperations.GenreQuery
{
    public class GenresDetailQuery
    {
        public int GenreId { get; set; }
        private readonly IMapper _mapper;
        private readonly IMsSqlDbContext _dbContext;
        public GenresDetailQuery(IMapper mapper, IMsSqlDbContext dbContext) 
        {
            _mapper = mapper;
            _dbContext = dbContext;
        
        }


        public GenresIdModel Handle()
        { 
            var genreId=_dbContext.Genres.FirstOrDefault(x=>x.IsActive & x.Id== GenreId);
            if (genreId == null)
                throw new InvalidOperationException("Kitap Türü Bulunamadı!");
            return _mapper.Map<GenresIdModel>(genreId);

        }
    }

    public class GenresIdModel
    { 
        public int Id { get; set; }
        public string Name { get; set; }
  
    }
}
