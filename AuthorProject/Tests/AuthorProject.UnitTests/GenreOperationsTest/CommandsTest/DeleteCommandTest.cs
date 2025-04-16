using AuthorProject.DbContexts;
using AuthorProject.UnitTests.TestSetup;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthorProject.Applications.GenreOperations.GenreCommand;
using AuthorProject.Entities;
using FluentAssertions;


namespace AuthorProject.UnitTests.GenreOperationsTest.CommandsTest
{
    public class DeleteCommandTest : IClassFixture<CommanTestFixture>
    {
        private readonly MsSqlDbContext _dbContext;

        public DeleteCommandTest(CommanTestFixture fixture)
        {
            _dbContext = fixture.Context;
        }

        [Fact]
        public void WhenValidGenreIdIsGiven_Genre_ShouldBeDeleted()
        {
            // Arrange
            var genre = new Genre
            {
                Name = "Genre to Delete",
                IsActive = true
            };
            _dbContext.Genres.Add(genre);
            _dbContext.SaveChanges();

            var command = new DeleteGenreCommand(_dbContext);
            command.GenreId = genre.Id;

            // Act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            // Assert
            var deletedGenre = _dbContext.Genres.SingleOrDefault(g => g.Id == genre.Id);
            deletedGenre.Should().BeNull();
        }

        [Fact]
        public void WhenInvalidGenreIdIsGiven_InvalidOperationException_ShouldBeThrown()
        {
            // Arrange
            var command = new DeleteGenreCommand(_dbContext);
            command.GenreId = 999; 

            // Act & Assert
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>()
                .WithMessage("Kitap Türü Bulunamadı");
        }
    }
}

        
        
        
        
        

