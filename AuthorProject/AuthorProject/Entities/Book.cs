using System.ComponentModel.DataAnnotations.Schema;

namespace AuthorProject.Entities
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; } // Foreign key to Author
      //  public int Genre { get; set; } 
        public Author Author { get; set; } // Navigation property
        public Genre Genre { get; set; } // Navigation property
        public bool IsActive { get; set; } = true;

    }
}
