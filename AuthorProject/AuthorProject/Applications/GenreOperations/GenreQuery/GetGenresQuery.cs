using AuthorProject.DbContext;
using AuthorProject.DbContexts;
using AutoMapper;

namespace AuthorProject.Applications.GenreOperations.GenreQuery
{
    public class GetGenresQuery
    {
        private readonly IMsSqlDbContext _context;
        private readonly IMapper _mapper;
        public GetGenresQuery(IMsSqlDbContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        
        
        }

        public List<GenresViewModel> Handle()
        { 
        var genres= _context.Genres.Where(x=>x.IsActive==true).OrderBy(x=>x.Id);
            List<GenresViewModel>obj = _mapper.Map< List<GenresViewModel>>(genres);
            return obj;
        
        }
    }


    public class GenresViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;


    }
}
