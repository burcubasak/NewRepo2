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
    public class DeleteCommandValidatorTest: IClassFixture<CommanTestFixture>
    {
        private readonly CommanTestFixture _fixture;
        public DeleteCommandValidatorTest(CommanTestFixture fixture)
        {
            _fixture = fixture;
        }
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenInvalidInputIsGiven_Validator_ShouldBeReturnErrors(int bookId)
        {
            //arrange
            var command = new DeleteBookCommand(_fixture.Context);
            command.BookId = bookId;
            //act
            var validator = new DeleteBookValidator();
            var result = validator.Validate(command);
            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }

}
