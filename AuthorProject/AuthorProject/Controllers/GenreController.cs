using AuthorProject.Applications.GenreOperations.GenreCommand;
using AuthorProject.Applications.GenreOperations.GenreQuery;
using AuthorProject.DbContext;
using AuthorProject.DbContexts;
using AuthorProject.Validations;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace AuthorProject.Controllers
{
    [ApiController]
    [Route("apiGenre/[controller]")]
    public class GenreController: ControllerBase
    {
        private readonly IMsSqlDbContext _context;
        private readonly IMapper _mapper;
        public GenreController(IMsSqlDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetGenres()
        {
            GetGenresQuery query = new GetGenresQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetGenreById(int id)
        {
            GenresDetailQuery query = new GenresDetailQuery(_mapper, _context); 
            query.GenreId = id;
            GetGenresIdValidator validator = new GetGenresIdValidator();
            validator.ValidateAndThrow(query);
            var result = query.Handle();
            return Ok(result);
        }


        [HttpPost]
        public IActionResult CreateGenre([FromBody] GenreModel model)
        {

            CreateGenreCommand command = new CreateGenreCommand(_mapper, _context);
            command.Model = model;
            CreateGenreValidator validator = new CreateGenreValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Created("", null);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreModel model)
        {
           UpdateGenreCommand command=new UpdateGenreCommand(_context);
            command.GenreId = id;
            command.Model = model;
            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id)
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            command.GenreId = id;
            DeleteGenreValidator validator = new DeleteGenreValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return NoContent();
        }
    } 
    
}
