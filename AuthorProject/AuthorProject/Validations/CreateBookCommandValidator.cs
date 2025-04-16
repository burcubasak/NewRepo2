using AuthorProject.Applications.BookOperations.BookCommand;
using FluentValidation;

namespace AuthorProject.Validations
{
    public class CreateBookCommandValidator:AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(x => x.Model.Title).NotEmpty().MinimumLength(3).WithMessage("Kitap ismi en az 3 karakter olmalıdır.");
            RuleFor(x => x.Model.GenreId).NotEmpty().GreaterThan(0).WithMessage("Kitap türü boş geçilemez.");
            RuleFor(x => x.Model.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date).WithMessage("Yayın tarihi bugünden önce olmalıdır.");
            RuleFor(x => x.Model.Author).NotEmpty().MinimumLength(3).WithMessage("Yazar ismi en az 3 karakter olmalıdır.");
            

        }
    }
   
}
