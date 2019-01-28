using BOOKCATALOG.DB.Interfaces;
using BOOKCATALOG.INFRASTRUCTURE.DTOs;
using BOOKCATALOG.INFRASTRUCTURE.Interfaces;
using BOOKCATALOG.INFRASTRUCTURE.Mappres;
using System.Collections.Generic;

namespace BOOKCATALOG.INFRASTRUCTURE.Services
{
    public class BookService : IBookService
    {
        private IBookRepository bookRepository = null;

        public BookService(IBookRepository bookRepo)
        {
            bookRepository = bookRepo;
        }

        public void AddBook(BookDTO bookDTO)
        {
            bookRepository.AddBook(bookDTO.MapToEntity());
        }

        public List<BookDTO> GetBookDTOs()
        {
            return bookRepository.GetBooks().MapToDTOs();
        }
    }
}