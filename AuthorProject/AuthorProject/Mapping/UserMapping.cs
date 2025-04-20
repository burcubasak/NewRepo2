using AuthorProject.Applications.UserOperations.UserCommand;
using AuthorProject.Entities;
using AutoMapper;

namespace AuthorProject.Mapping
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {

            CreateMap<CreateUserModel, User>();
        }
    }
  
}
