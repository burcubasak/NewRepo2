using AuthorProject.DbContexts;
using AuthorProject.Entities;

public static class BookSeeder
{
    public static void AddBooks(this MsSqlDbContext context)
    {
        // Mevcut kitapları temizle
        context.Books.RemoveRange(context.Books);
        context.SaveChanges();

        if (!context.Genres.Any())
        {
            throw new InvalidOperationException("Genres must be seeded before adding books.");
        }

        context.Books.AddRange(
            new Book
            {
              
                Title = "Book 1",
                Genre = context.Genres.First(g => g.Id == 1),
                AuthorId = 1,
                IsActive = true
            },
            new Book
            {
              
                Title = "Book 2",
                Genre = context.Genres.First(g => g.Id == 2),
                AuthorId = 2,
                IsActive = true
            }
        );
        context.SaveChanges();
    }
}
