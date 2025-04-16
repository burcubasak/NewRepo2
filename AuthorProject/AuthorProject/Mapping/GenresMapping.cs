using AuthorProject.Applications.GenreOperations.GenreQuery;
using AuthorProject.Entities;
using AutoMapper;

namespace AuthorProject.Mapping
{
    public class GenresMapping:Profile
    {
        public GenresMapping() 
        {
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenresIdModel>();
        }
    }
}
