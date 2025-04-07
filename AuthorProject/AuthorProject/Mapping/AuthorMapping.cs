using AuthorProject.Dtos.Author;
using AuthorProject.Entities;
using AutoMapper;

namespace AuthorProject.Mapping
{
    public class AuthorMapping:Profile
    {
        public AuthorMapping()
        {
            CreateMap<CreateAuthorDto, Author>();
            CreateMap<UpdateAuthorDto, Author>();
            CreateMap<Author, AuthorDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.Name} {src.Surname}"));
        }
    }
}
