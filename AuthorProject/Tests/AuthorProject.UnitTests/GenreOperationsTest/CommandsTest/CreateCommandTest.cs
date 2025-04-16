using AuthorProject.Applications.GenreOperations.GenreCommand;
using AuthorProject.DbContexts;
using AuthorProject.Entities;
using AuthorProject.UnitTests.TestSetup;
using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AuthorProject.UnitTests.GenreOperationsTest.CommandsTest
{
    public class CreateCommandTest:IClassFixture<CommanTestFixture>
    {

        private readonly IMapper _mapper;
        private readonly MsSqlDbContext _dbContext;
        public CreateCommandTest(CommanTestFixture fixture)
        {
            _mapper = fixture.Mapper;
            _dbContext = fixture.Context;

        }

        [Fact]
        public void WhenInValidInputIsGiven_Validator_ShouldBeReturnErrors()
        { 
            
            var yeniGenre = new Genre()
            {
                Name ="Burcu" ,
            };

            _dbContext.Genres.Add(yeniGenre);
            _dbContext.SaveChanges();
            _dbContext.ChangeTracker.Clear();

            // Arrange
            CreateGenreCommand command = new CreateGenreCommand(_mapper,_dbContext);
            command.Model = new GenreModel
            {
                Name = yeniGenre.Name,

            };



            // Act&Assert
            FluentActions
           .Invoking(() => command.Handle())//burada CreateGenreCommand sınıfınfaki command.Handle() metodu çağrılıyor
           .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap Türü Zaten Mevcut");




        }
    }
}
