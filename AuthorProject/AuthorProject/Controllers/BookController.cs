using AuthorProject.Applications.BookOperations.BookCommand;
using AuthorProject.Applications.BookOperations.BookQuery;
using AuthorProject.DbContexts;
using AuthorProject.Validations;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace AuthorProject.Controllers
{
    public class BookController : ControllerBase
    {
        private readonly MsSqlDbContext _context;
        private readonly IMapper _mapper;

        public BookController(MsSqlDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }





        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBookQuery query = new GetBookQuery(_context);
            var result = query.Handle();
            return Ok(result);
            
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            BookDetailQuery query = new BookDetailQuery(_context);
            query.BookId = id;
            GetBookIdQueryValidator validator = new GetBookIdQueryValidator();
            validator.ValidateAndThrow(query);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateBook([FromBody] CreateBookViewModel model)
        {
            CreateBookCommand command = new CreateBookCommand(_context,_mapper);
            command.Model = model;
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Created("", null);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel model)
        {
            UpdateBookCommand command = new UpdateBookCommand(_context,_mapper);
            command.BookId = id;
            command.Model = model;
            UpdateBookValidator validator = new UpdateBookValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand command = new DeleteBookCommand(_context);
            command.BookId = id;
            DeleteBookValidator validator = new DeleteBookValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return NoContent();
        }
    }
   
}
