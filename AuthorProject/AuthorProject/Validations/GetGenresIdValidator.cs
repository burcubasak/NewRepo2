using AuthorProject.Applications.GenreOperations.GenreQuery;
using FluentValidation;

namespace AuthorProject.Validations
{
    public class GetGenresIdValidator:AbstractValidator<GenresDetailQuery>
    {
        public GetGenresIdValidator()
        {
            RuleFor(query=>query.GenreId).GreaterThan(0);
        }

    }
}
