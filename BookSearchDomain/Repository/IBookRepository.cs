using BookSearchDomain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookSearchDomain.Repository
{
    public interface IBookRepository
    {
        List<Book> Query();
    }
}
