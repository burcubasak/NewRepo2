using AuthorProject.Applications.BookOperations.BookQuery;
using AuthorProject.Applications.GenreOperations.GenreQuery;
using AuthorProject.DbContexts;
using AuthorProject.Entities;
using AuthorProject.UnitTests.TestSetup;
using AutoMapper;
using FluentAssertions;


namespace AuthorProject.UnitTests.GenreOperationsTest.QueryTest
{
    public class GenreDetailQueryTest : IClassFixture<CommanTestFixture>
    {
        private readonly MsSqlDbContext _dbContext;
        private readonly IMapper _mapper;
        public GenreDetailQueryTest(CommanTestFixture fixture)
        {
            _dbContext = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void WhenInValidInputIsGiven_Validator_ShouldBeReturnErrors()
        {

            var genre = new Genre()
            {
                Name = "Burcu",

            };

            _dbContext.Genres.Add(genre);
            _dbContext.SaveChanges();

            var command = new GenresDetailQuery(_mapper, _dbContext)
            {
                GenreId = genre.Id
            };
            // Act
            var result = command.Handle();

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().Be(genre.Name);

        }

        [Fact]
        // Geçersiz bir kitap ID'si verildiğinde hata fırlatmalı
        public void WhenInvalidBookIdIsGiven_InvalidOperationException_ShouldBeThrown()
        {
            // Arrange
            var query = new GenresDetailQuery(_mapper, _dbContext)
            {
                GenreId = 999 // Geçersiz ID
            };

            // Act & Assert
            FluentActions
                .Invoking(() => query.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap Türü Bulunamadı!");
        }
    }
}
