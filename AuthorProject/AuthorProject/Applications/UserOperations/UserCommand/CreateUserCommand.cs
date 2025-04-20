using AuthorProject.DbContext;
using AuthorProject.Entities;
using AutoMapper;

namespace AuthorProject.Applications.UserOperations.UserCommand
{
    public class CreateUserCommand
    {
        public CreateUserModel Model { get; set; }
        private readonly IMsSqlDbContext _context;
        private readonly IMapper _mapper;
        public CreateUserCommand(IMsSqlDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var user = _context.Users.SingleOrDefault(x => x.Email == Model.Email);
            if (user is not null)
                throw new InvalidOperationException("Kullanıcı Zaten Mevcut");
            user = _mapper.Map < User > (Model);
        
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
    public class CreateUserModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
