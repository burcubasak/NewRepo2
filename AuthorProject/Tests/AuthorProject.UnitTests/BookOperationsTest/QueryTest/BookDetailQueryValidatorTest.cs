using AuthorProject.Applications.BookOperations.BookQuery;
using AuthorProject.UnitTests.TestSetup;
using AuthorProject.Validations;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorProject.UnitTests.BookOperationsTest.QueryTest
{
    public class BookDetailQueryValidatorTest:IClassFixture<CommanTestFixture>
    {
       
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenInvalidInputIsGiven_Validator_ShouldBeReturnErrors(int bookId)
        {
            //arrange
            var query = new BookDetailQuery( null);
            query.BookId = bookId;
            //act
            var validator = new GetBookIdQueryValidator();
            var result = validator.Validate(query);
            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
  
}
