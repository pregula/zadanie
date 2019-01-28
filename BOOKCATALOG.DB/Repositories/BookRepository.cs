using BOOKCATALOG.DB.Entities;
using BOOKCATALOG.DB.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BOOKCATALOG.DB.Repositories
{
    public class BookRepository : IBookRepository
    {
        private Context _context = null;

        public BookRepository(Context ctx)
        {
            _context = ctx;
        }

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public List<Book> GetBooks()
        {
            return _context.Books.ToList();
        }
    }
}