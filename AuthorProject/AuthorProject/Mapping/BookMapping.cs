using AuthorProject.Applications.BookOperations.BookQuery;
using AuthorProject.Entities;
using AutoMapper;

namespace AuthorProject.Mapping
{
    public class BookMapping: Profile
    {
        public BookMapping()
        {

            CreateMap<Book, BookDetailViewModel>();
            CreateMap<Book, BookViewModel>();
        }
    }
   
}
