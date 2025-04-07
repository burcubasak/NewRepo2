namespace AuthorProject.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Date { get; set; }

        ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
