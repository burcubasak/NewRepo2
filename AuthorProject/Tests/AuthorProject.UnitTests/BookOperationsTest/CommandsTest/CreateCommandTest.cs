using AuthorProject.Applications.BookOperations.BookCommand;
using AuthorProject.DbContexts;
using AuthorProject.Entities;
using AuthorProject.UnitTests.TestSetup;
using FluentAssertions;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorProject.UnitTests.BookOperationsTest.CommandsTest
{
    public class CreateCommandTest:IClassFixture<CommanTestFixture>
    {

        private readonly IMapper _mapper;
        private readonly MsSqlDbContext _dbContext;

        public CreateCommandTest(CommanTestFixture testFixture)
        {
           _mapper = testFixture.Mapper;
            _dbContext = testFixture.Context;
        }


        [Fact]
        //zaten var olan bir kitabın kaydı verildiğinde hata döndürmeli
        public void WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //Sadece bu test kapsamında kullanılacak veri yaratıyoruz önce
            // Arrange
            var book = new Book()
            {
        
                Title = "Test_WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn",
                AuthorId = 1,
                IsActive = true,
              

            };

            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
            _dbContext.ChangeTracker.Clear();


            CreateBookCommand command = new CreateBookCommand(_dbContext, _mapper);
            command.Model = new CreateBookViewModel()
            {
                Title = book.Title,

            };


            // Act & Assert
            // Act & Assert
            FluentActions
                .Invoking(() => command.Handle())//burada CreateBookCommand sınıfınfaki command.Handle() metodu çağrılıyor
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Book already exists.");

        }
    }
}

