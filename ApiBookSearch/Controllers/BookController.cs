using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookSearchDomain.Aplication;
using BookSearchDomain.Dto;
using BookSearchDomain.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApiBookSearch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;

        public BookController(IBookService service)
        {
            _service = service;
        }

        public List<Book> Get(
            [FromQuery]string author,
            [FromQuery]string bookname,
            [FromQuery]string genre,
            [FromQuery]string illustrator,
            [FromQuery]double? initialprice,
            [FromQuery]double? finalprice,
            [FromQuery]int? initialnumberpages,
            [FromQuery]int? finalnumberpages
            )
        {

            var filter = new FilterDTO
            {
                Author = author,
                BookName = bookname,
                Genre = genre,
                Illustrator = illustrator,
                InitialPrice = initialprice,
                FinalPrice = finalprice,
                InitialNumberPages = initialnumberpages,
                FinalNumberPages = finalnumberpages,
            };

            return _service.SearchBook(filter);
        }
    }
}