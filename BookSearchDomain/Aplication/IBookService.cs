using BookSearchDomain.Dto;
using BookSearchDomain.Model;
using System.Collections.Generic;

namespace BookSearchDomain.Aplication
{
    public interface IBookService
    {
        List<Book> SearchBook(FilterDTO filter);
        double Shipping(int id);
    }
}
