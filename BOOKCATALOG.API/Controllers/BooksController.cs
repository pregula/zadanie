using BOOKCATALOG.INFRASTRUCTURE.DTOs;
using BOOKCATALOG.INFRASTRUCTURE.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BOOKCATALOG.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAllOrigins")]
    public class BooksController : ControllerBase
    {
        private IBookService _bookService = null;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public List<BookDTO> Get()
        {
            return _bookService.GetBookDTOs();
        }

        [HttpPost]
        public void Post(BookDTO request)
        {
            _bookService.AddBook(request);
        }
    }
}