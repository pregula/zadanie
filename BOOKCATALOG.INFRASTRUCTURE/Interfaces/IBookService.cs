using BOOKCATALOG.INFRASTRUCTURE.DTOs;
using System.Collections.Generic;

namespace BOOKCATALOG.INFRASTRUCTURE.Interfaces
{
    public interface IBookService
    {
        List<BookDTO> GetBookDTOs();

        void AddBook(BookDTO bookDTO);
    }
}