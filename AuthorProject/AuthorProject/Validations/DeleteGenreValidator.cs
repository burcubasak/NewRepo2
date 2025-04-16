using AuthorProject.Applications.GenreOperations.GenreCommand;
using FluentValidation;

namespace AuthorProject.Validations
{
    public class DeleteGenreValidator : AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreValidator()
        {
            RuleFor(x => x.GenreId).NotEmpty().GreaterThan(0);
        }
    }
    
}
