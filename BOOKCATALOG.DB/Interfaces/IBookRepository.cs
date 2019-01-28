using BOOKCATALOG.DB.Entities;
using System.Collections.Generic;

namespace BOOKCATALOG.DB.Interfaces
{
    public interface IBookRepository
    {
        List<Book> GetBooks();
        void AddBook(Book book);
    }
}