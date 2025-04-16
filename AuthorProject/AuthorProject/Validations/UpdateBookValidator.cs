using AuthorProject.Applications.BookOperations.BookCommand;
using FluentValidation;

namespace AuthorProject.Validations
{
    public class UpdateBookValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookValidator()
        {
            RuleFor(x => x.Model.Title).NotEmpty().MinimumLength(3).WithMessage("Kitap ismi en az 3 karakter olmalıdır.");
  
            RuleFor(x => x.Model.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date).WithMessage("Yayın tarihi bugünden önce olmalıdır.");
            RuleFor(x => x.Model.AuthorId).NotEmpty().GreaterThan(0).WithMessage("Kitap türü boş geçilemez.");
    
        }
    }
  
}
