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
    public class CreateCommandValidatorTest:IClassFixture<CommanTestFixture>
    {
        private readonly CommanTestFixture _fixture;

        public CreateCommandValidatorTest(CommanTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Theory]
        [InlineData(" ", " ", 0)]
        [InlineData("ali", " ", 0)]
        [InlineData("veli ", "aad", 0)]
        [InlineData(" ", " ", 1)]
        [InlineData(" ", "a", 1)]
        [InlineData("a", " ", 1)]
        [InlineData("a", "a", 0)]

        public void WhenInvalidInputIsGiven_Validator_ShouldBeReturnErrors(string Title, string Author,int GenreId)
        {
            //arrange
            var command = new CreateBookCommand(null, null);
            command.Model = new CreateBookViewModel() 
            {
                Title = Title,
                Author = Author,
                GenreId = GenreId,
                PublishDate = DateTime.Now.Date.AddYears(-1),//burada güncel tarih yaparsak hata alırız, bir yıl öncesi olmalı
                IsActive = true


            };


            //act
            var validator = new CreateBookCommandValidator();
            var result = validator.Validate(command);


            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }

}
