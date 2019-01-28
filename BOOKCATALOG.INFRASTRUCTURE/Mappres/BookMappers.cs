using BOOKCATALOG.DB.Entities;
using BOOKCATALOG.INFRASTRUCTURE.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace BOOKCATALOG.INFRASTRUCTURE.Mappres
{
    public static class BookMappers
    {
        public static BookDTO MapToDTO(this Book bookDB)
        {
            return new BookDTO()
            {
                Id = bookDB.Id,
                Title = bookDB.Title,
                ReleaseDate = bookDB.ReleaseDate,
                Price = bookDB.Price,
                Count = bookDB.Count
            };
        }

        public static List<BookDTO> MapToDTOs(this List<Book> booksDB)
        {
            return booksDB.Select(b => b.MapToDTO()).ToList();
        }

        public static Book MapToEntity(this BookDTO bookDTO)
        {
            return new Book()
            {
                Title = bookDTO.Title,
                ReleaseDate = bookDTO.ReleaseDate,
                Price = bookDTO.Price,
                Count = bookDTO.Count
            };
        }
    }
}