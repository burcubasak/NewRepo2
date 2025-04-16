using AuthorProject.DbContext;
using AuthorProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthorProject.DbContexts
{
    public class MsSqlDbContext : Microsoft.EntityFrameworkCore.DbContext, IMsSqlDbContext
    {
        public MsSqlDbContext(DbContextOptions<MsSqlDbContext> options) : base(options)
        {
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
