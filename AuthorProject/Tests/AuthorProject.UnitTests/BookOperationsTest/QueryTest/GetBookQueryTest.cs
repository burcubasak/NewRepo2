using AuthorProject.Applications.BookOperations.BookQuery;
using AuthorProject.DbContexts;
using AuthorProject.Entities;
using AuthorProject.UnitTests.TestSetup;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AuthorProject.UnitTests.BookOperationsTest.QueryTest
{
    public class GetBookQueryTest : IClassFixture<CommanTestFixture>
    {
        private readonly MsSqlDbContext _dbContext;

        public GetBookQueryTest(CommanTestFixture testFixture)
        {
            _dbContext = testFixture.Context;
        }

        [Fact]
        // Aktif kitaplar döndürülmeli
        public void WhenBooksExist_ActiveBooks_ShouldBeReturned()
        {
            // Arrange

            _dbContext.Books.RemoveRange(_dbContext.Books);
            _dbContext.SaveChanges();

            // Test verisi oluşturma
            var books = new List<Book>
            {
                new Book { Title = "Book 1", IsActive = true },
                new Book { Title = "Book 2", IsActive = false },
                new Book { Title = "Book 3", IsActive = true }
            };

            _dbContext.Books.AddRange(books);
            _dbContext.SaveChanges();

            var query = new GetBookQuery(_dbContext);

            // Act
            var result = query.Handle();

            // Assert
            result.Should().NotBeNull();
            result.Count.Should().Be(2); // Sadece aktif kitaplar
            result.Select(x => x.Title).Should().Contain("Book 1").And.Contain("Book 3");
        }

        [Fact]
        //Hiç kitap yoksa boş bir liste döndürülmeli
        public void WhenNoBooksExist_EmptyList_ShouldBeReturned()
        {
           // Arrange
          _dbContext.Books.RemoveRange(_dbContext.Books);
          _dbContext.SaveChanges();

           var query = new GetBookQuery(_dbContext);

          // Act
         var result = query.Handle();

           // Assert
            result.Should().NotBeNull();
           result.Should().BeEmpty();
        }
    }
}
