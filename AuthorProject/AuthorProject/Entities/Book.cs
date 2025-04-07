namespace AuthorProject.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; } // Foreign key to Author
        public int Genre { get; set; } 
        public Author Author { get; set; } // Navigation property
      
    }
}
