using AuthorProject.Applications.BookOperations.BookQuery;
using AuthorProject.DbContexts;
using AuthorProject.Entities;
using AuthorProject.UnitTests.TestSetup;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace AuthorProject.UnitTests.BookOperationsTest.QueryTest
{
    public class BookDetailQueryTest : IClassFixture<CommanTestFixture>
    {
        private readonly MsSqlDbContext _dbContext;

        public BookDetailQueryTest(CommanTestFixture testFixture)
        {
            _dbContext = testFixture.Context;
        }

        [Fact]
        // Geçerli bir kitap ID'si verildiğinde doğru kitap döndürülmeli
        public void WhenValidBookIdIsGiven_Book_ShouldBeReturned()
        {
            // Arrange
            var book = new Book
            {
                Title = "Test Book",
                AuthorId = 1,
                Genre = new Genre { Name = "Fiction" },
                IsActive = true
            };

            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();

            var query = new BookDetailQuery(_dbContext)
            {
                BookId = book.Id
            };

            // Act
            var result = query.Handle();

            // Assert
            result.Should().NotBeNull();
            result.Title.Should().Be(book.Title);
            result.Genre.Should().Be("Fiction");
        }

        [Fact]
        // Geçersiz bir kitap ID'si verildiğinde hata fırlatmalı
        public void WhenInvalidBookIdIsGiven_InvalidOperationException_ShouldBeThrown()
        {
            // Arrange
            var query = new BookDetailQuery(_dbContext)
            {
                BookId = 999 // Geçersiz ID
            };

            // Act & Assert
            FluentActions
                .Invoking(() => query.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap Bulunamadı!");
        }
    }
}
