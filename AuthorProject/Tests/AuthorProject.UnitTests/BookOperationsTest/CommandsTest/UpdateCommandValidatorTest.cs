using AuthorProject.Applications.BookOperations.BookCommand;
using AuthorProject.UnitTests.TestSetup;
using AuthorProject.Validations;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorProject.UnitTests.BookOperationsTest.CommandsTest
{
    public class UpdateCommandValidatorTest:IClassFixture<CommanTestFixture>
    {
      
        [Theory]
        [InlineData(0, " ", 0)]
        [InlineData(0, "ali", 0)]
        [InlineData(0, "veli ", 0)]
        [InlineData(0, " ", 1)]
        public void WhenInvalidInputIsGiven_Validator_ShouldBeReturnErrors(int bookId,string Title,int AuthorId)
        {
            //arrange
            var command = new UpdateBookCommand(null,null);
            command.BookId = bookId;
            command.Model = new UpdateBookModel()
            {
                Title = Title,
                AuthorId = AuthorId,
                PublishDate = DateTime.Now.Date.AddYears(1),
            
            };
            //act
            var validator = new UpdateBookValidator();
            var result = validator.Validate(command);
            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
