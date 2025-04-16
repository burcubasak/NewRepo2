using AuthorProject.Applications.BookOperations.BookCommand;
using AuthorProject.DbContexts;
using AuthorProject.Entities;
using AuthorProject.UnitTests.TestSetup;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorProject.UnitTests.BookOperationsTest.CommandsTest
{
    public class DeleteCommandTest : IClassFixture<CommanTestFixture>
    {
        private readonly MsSqlDbContext _dbContext;
        public DeleteCommandTest(CommanTestFixture testFixture)
        {
            _dbContext = testFixture.Context;
        }

        [Fact]
        // Mevcut bir kitabı silmeli
        public void WhenValidBookIdIsGiven_Book_ShouldBeDeleted()
        {
            // Arrange
            var book = new Book
            {
                Title = "Test Book for Deletion",
                AuthorId = 1,
                IsActive = true
            };

            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();

            var command = new DeleteBookCommand(_dbContext)
            {
                BookId = book.Id
            };

            // Act
            command.Handle();

            // Assert
            var deletedBook = _dbContext.Books.SingleOrDefault(x => x.Id == book.Id);
            deletedBook.Should().BeNull();
        }









    }
}
