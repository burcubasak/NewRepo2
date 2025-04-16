using AuthorProject.DbContext;


namespace AuthorProject.Applications.GenreOperations.GenreCommand
{
    public class UpdateGenreCommand
    {
        public int GenreId { get; set; }
        public UpdateGenreModel Model { get; set; }
        private readonly IMsSqlDbContext _context;
        public UpdateGenreCommand(IMsSqlDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId);
            if (genre is null)
                throw new InvalidOperationException("Kitap Türü Bulunamadı");

            genre.Name = Model.Name;
            _context.SaveChanges();


            if (_context.Genres.Any(x => x.Name.ToLower() == Model.Name.ToLower() & x.Id != GenreId))
                throw new InvalidOperationException("Aynı İsimli Kitap Türü Zaten Mevcut");

           // Bu işlem, Model.Name boş bir değer gönderildiğinde, mevcut genre.Name değerinin üzerine yazılmasını engeller.Böylece, istemci tarafından boş bir isim gönderilse bile, var olan isim korunur.            genre.Name =string.IsNullOrEmpty(Model.Name.Trim()) ?  genre.Name:Model.Name;
            genre.IsActive = Model.IsActive;
            _context.SaveChanges();
        }

    }
    public class UpdateGenreModel
    {
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
