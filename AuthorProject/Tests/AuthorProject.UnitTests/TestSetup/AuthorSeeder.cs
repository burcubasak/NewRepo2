using AuthorProject.DbContexts;
using AuthorProject.Entities;

public static class AuthorSeeder
{
    public static void AddAuthors(this MsSqlDbContext context)
    {
        // Mevcut yazarları temizle
        context.Authors.RemoveRange(context.Authors);
        context.SaveChanges();

        context.Authors.AddRange(
            new Author
            {
                Name = "Author 1",
                Surname = "Surname 1",
                Date = DateTime.Now.AddYears(-30)
            },
            new Author
            {
                Name = "Author 2",
                Surname = "Surname 2",
                Date = DateTime.Now.AddYears(-25)
            }
        );
        context.SaveChanges();
    }
}
