using AuthorProject.Applications.BookOperations.BookCommand;
using AuthorProject.DbContexts;
using AuthorProject.Entities;
using AuthorProject.UnitTests.TestSetup;
using FluentAssertions;
using AutoMapper;
using System.Linq;
using Xunit;

namespace AuthorProject.UnitTests.BookOperationsTest.CommandsTest
{
    public class UpdateCommandTest : IClassFixture<CommanTestFixture>
    {
        private readonly MsSqlDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateCommandTest(CommanTestFixture testFixture)
        {
            _dbContext = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        // Mevcut bir kitabı güncellemeli
        public void WhenValidBookIdIsGiven_Book_ShouldBeUpdated()
        {
            // Arrange
            var book = new Book
            {
                Title = "Old Title",
                AuthorId = 1,
                IsActive = true
            };

            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();

            var command = new UpdateBookCommand(_dbContext, _mapper)
            {
                BookId = book.Id,
                Model = new UpdateBookModel
                {
                    Title = "New Title",
                    AuthorId = 2
                }
            };

            // Act
            command.Handle();

            // Assert
            var updatedBook = _dbContext.Books.SingleOrDefault(x => x.Id == book.Id);
            updatedBook.Should().NotBeNull();
            updatedBook.Title.Should().Be("New Title");
            updatedBook.AuthorId.Should().Be(2);
        }

        //[Fact]
        //// Geçersiz bir kitap ID'si verildiğinde hata fırlatmalı
        //public void WhenInvalidBookIdIsGiven_InvalidOperationException_ShouldBeThrown()
        //{
        //    // Arrange
        //    var command = new UpdateBookCommand(_dbContext, _mapper)
        //    {
        //        BookId = 999, // Geçersiz bir ID
        //        Model = new UpdateBookModel
        //        {
        //            Title = "New Title",
        //            AuthorId = 2
        //        }
        //    };

        //    // Act & Assert
        //    FluentActions
        //        .Invoking(() => command.Handle())
        //        .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Book not found!");
        //}
    }
}
