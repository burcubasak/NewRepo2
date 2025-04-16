using AuthorProject.Applications.BookOperations.BookCommand;
using FluentValidation;

namespace AuthorProject.Validations
{
    public class DeleteBookValidator: AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookValidator()
        {
            RuleFor(x => x.BookId).NotEmpty().GreaterThan(0).WithMessage("Kitap Id'si boş geçilemez.");
        }
    }
   
}
