using System;

namespace BOOKCATALOG.INFRASTRUCTURE.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleaseDate { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
    }
}