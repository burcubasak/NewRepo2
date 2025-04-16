using AuthorProject.DbContexts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using AuthorProject.Mapping;

namespace AuthorProject.UnitTests.TestSetup
{
    public class CommanTestFixture
    {
        public MsSqlDbContext Context { get; set; }

        public IMapper Mapper { get; set; }

        public CommanTestFixture()
        {
            var options = new DbContextOptionsBuilder<MsSqlDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            Context = new MsSqlDbContext(options);
            Context.Database.EnsureCreated();
            AuthorSeeder.AddAuthors(Context); 
            GenreSeeder.AddGenres(Context);   
            BookSeeder.AddBooks(Context);    
            Context.SaveChanges();



            Mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AuthorMapping>();
                cfg.AddProfile<GenresMapping>();
                cfg.AddProfile<BookMapping>();
            }).CreateMapper();

        }


    }
}
