using AuthorProject.Applications.GenreOperations.GenreCommand;
using FluentValidation;

namespace AuthorProject.Validations
{
    public class UpdateGenreCommandValidator:AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(x => x.GenreId).NotEmpty().GreaterThan(0);
            //BBu kural, Model.Name boşluklardan arındırılmış hali boş değilse (string.Empty değilse) çalışır.
            RuleFor(x => x.Model.Name).NotEmpty().MinimumLength(4).When(x=>x.Model.Name.Trim()!=string.Empty).MaximumLength(50);
            RuleFor(x => x.Model.IsActive).NotNull();
        }
    }
   
}
