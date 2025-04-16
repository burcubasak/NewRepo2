using AuthorProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthorProject.DbContext
{
    public interface IMsSqlDbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }

        int SaveChanges();
    }
}
