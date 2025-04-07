using AuthorProject.Dtos.Author;
using FluentValidation;

namespace AuthorProject.Validations
{
    public class CreateAuthorValidation: AbstractValidator<CreateAuthorDto>
    {
        public CreateAuthorValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required.")
                .Length(2, 50)
                .WithMessage("Name must be between 2 and 50 characters.");
            RuleFor(x => x.Surname)
                .NotEmpty()
                .WithMessage("Surname is required.")
                .Length(2, 50)
                .WithMessage("Surname must be between 2 and 50 characters.");
            RuleFor(x => x.Date)
                .NotEmpty()
                .WithMessage("Date is required.")
                .LessThan(DateTime.Now)
                .WithMessage("Date must be in the past.");
        }
    }
}
