using AuthorProject.Applications.GenreOperations.GenreCommand;
using AuthorProject.DbContexts;
using AuthorProject.Entities;
using AuthorProject.UnitTests.TestSetup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorProject.UnitTests.GenreOperationsTest.CommandsTest
{
    public class UpdateCommandTest:IClassFixture<CommanTestFixture>
    {

        private readonly MsSqlDbContext _dbContext;
        public UpdateCommandTest(CommanTestFixture fixture)
        {
            _dbContext = fixture.Context;
        }
        [Fact]
        public void WhenValidGenreIdIsGiven_Genre_ShouldBeUpdated()
        {

            // Arrange
            var genre = new Genre
            {
                Name = "Old Genre",
                IsActive = true
            };

            _dbContext.Genres.Add(genre);
            _dbContext.SaveChanges();

            var command = new UpdateGenreCommand(_dbContext);
            command.GenreId = genre.Id;

            command.Model = new UpdateGenreModel
            {
                Name = "New Genre"
            };

            // Act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            // Assert
            var updatedGenre = _dbContext.Genres.SingleOrDefault(g => g.Id == genre.Id);
            updatedGenre.Should().NotBeNull();
            updatedGenre.Name.Should().Be("New Genre");
        }
        [Fact]
        public void WhenInvalidGenreIdIsGiven_InvalidOperationException_ShouldBeThrown()
        {
            // Arrange
            var command = new UpdateGenreCommand(_dbContext);
            command.GenreId = 999; // Invalid ID

            // Act & Assert
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>()
                .WithMessage("Kitap Türü Bulunamadı");
        }
    }
}
