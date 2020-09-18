﻿using BookSearchDomain.Aplication;
using BookSearchDomain.Dto;
using BookSearchDomain.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
            [FromQuery]string name,
            [FromQuery]string genre,
            [FromQuery]string illustrator,
            [FromQuery]double? initialprice,
            [FromQuery]double? finalprice,
            [FromQuery]int? initialnumberpages,
            [FromQuery]int? finalnumberpages,
            [FromQuery]string orderby,
            [FromQuery]bool asc
            )
        {

            var filter = new FilterDTO
            {
                Author = author,
                Name = name,
                Genre = genre,
                Illustrator = illustrator,
                InitialPrice = initialprice,
                FinalPrice = finalprice,
                InitialNumberPages = initialnumberpages,
                FinalNumberPages = finalnumberpages,
                OrderBy = orderby,
                Ascending = asc
            };

            return _service.SearchBook(filter);
        }
    }
}