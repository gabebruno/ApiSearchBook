using BookSearchDomain.Dto;
using BookSearchDomain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookSearchDomain.Aplication
{
    public interface IBookService
    {
        List<Book> SearchBook(FilterDTO filter);
        double Shipping(int id);
    }
}
