using AuthorProject.Applications.BookOperations.BookQuery;
using FluentValidation;

namespace AuthorProject.Validations
{
    public class GetBookIdQueryValidator : AbstractValidator<BookDetailQuery>
    {
        public GetBookIdQueryValidator()
        {
            RuleFor(x => x.BookId).GreaterThan(0).NotEmpty().WithMessage("Kitap Id'si Boş Geçilemez!");
        }
    }
    
}
