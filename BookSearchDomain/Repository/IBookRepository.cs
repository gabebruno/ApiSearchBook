using BookSearchDomain.Model;
using System.Collections.Generic;

namespace BookSearchDomain.Repository
{
    public interface IBookRepository
    {
        List<Book> Query();
    }
}
