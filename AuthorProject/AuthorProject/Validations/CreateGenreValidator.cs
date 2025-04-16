using AuthorProject.Applications.GenreOperations.GenreCommand;
using FluentValidation;

namespace AuthorProject.Validations
{
    public class CreateGenreValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreValidator()
        {
            RuleFor(x => x.Model.Name).NotEmpty().MinimumLength(2).MaximumLength(50);
        }
    
    }
}
