using AuthorProject.DbContexts;
using AuthorProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorProject.UnitTests.TestSetup
{
    public static class GenreSeeder
    {
        public static void AddGenres(this MsSqlDbContext context)
        {
            // Mevcut türleri temizle
            context.Genres.RemoveRange(context.Genres);
            context.SaveChanges();

            // Yeni türleri ekle
            context.Genres.AddRange(
                new Genre { Name = "Fiction", IsActive = true },
                new Genre { Name = "Fantasy", IsActive = true }
            );
            context.SaveChanges();
        }
    }

}
