using AuthorProject.Applications.GenreOperations.GenreQuery;
using AuthorProject.DbContexts;
using AuthorProject.UnitTests.TestSetup;
using AutoMapper;
using FluentAssertions;
using Xunit;

namespace AuthorProject.UnitTests.GenreOperationsTest.QueryTest
{
    public class GetGenresQueryTest : IClassFixture<CommanTestFixture>
    {
        private readonly MsSqlDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetGenresQueryTest(CommanTestFixture fixture)
        {
            _dbContext = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void WhenGenresExist_Genres_ShouldBeReturned()
        {
            // Arrange
            GenreSeeder.AddGenres(_dbContext);
            var query = new GetGenresQuery(_dbContext, _mapper);

            // Act
            var result = query.Handle();

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCountGreaterThan(0);
            result.All(genre => genre.IsActive).Should().BeTrue();
        }

        [Fact]
        public void WhenNoGenresExist_EmptyList_ShouldBeReturned()//Burada hiç kitap yoksa boş bir liste döndürülmeli
        {
            // Arrange
            _dbContext.Genres.RemoveRange(_dbContext.Genres);
            _dbContext.SaveChanges();

            var query = new GetGenresQuery(_dbContext, _mapper);

            // Act
            var result = query.Handle();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }
    }
}
