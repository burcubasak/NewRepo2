using AuthorProject.Applications.UserOperations.UserCommand;
using AuthorProject.DbContext;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AuthorProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMsSqlDbContext dbContext;
        private readonly IMapper _mapper;

        readonly IConfiguration _configuration;
        public UserController(IMsSqlDbContext dbContext,IMapper mapper , IConfiguration configuration)
        {
            this.dbContext = dbContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        public IActionResult Create([FromBody] CreateUserModel userModel)
        { 
        CreateUserCommand command = new CreateUserCommand(dbContext, _mapper);
            command.Model = userModel;
            command.Handle();
            return Ok();


        }
    }
}
