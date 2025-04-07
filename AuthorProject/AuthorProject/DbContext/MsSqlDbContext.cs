using AuthorProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthorProject.DbContexts
{
    public class MsSqlDbContext :DbContext
    {
        public MsSqlDbContext(DbContextOptions<MsSqlDbContext> options) : base(options)
        {
        }
        public DbSet<Author> Authors { get; set; }
    }
}
