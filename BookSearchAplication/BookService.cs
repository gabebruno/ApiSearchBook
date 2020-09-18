using BookSearchDomain.Aplication;
using BookSearchDomain.Dto;
using BookSearchDomain.Model;
using BookSearchDomain.Repository;
using System.Collections.Generic;
using System.Linq;

namespace BookSearchAplication
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repo;

        public BookService(IBookRepository repo)
        {
            _repo = repo;
        }

        public List<Book> SearchBook(FilterDTO filters)
        {
            var books = _repo.Query();

            if (!string.IsNullOrEmpty(filters.Author))
                books = books.Where(p => p.Specifications.Author.Contains(filters.Author)).ToList();

            if (!string.IsNullOrEmpty(filters.Name))
                books = books.Where(p => p.Name.Contains(filters.Name)).ToList();

            if (filters.InitialPrice != null)
                books = books.Where(p => p.Price >= filters.InitialPrice).ToList();

            if (filters.FinalPrice != null)
                books = books.Where(p => p.Price <= filters.FinalPrice).ToList();

            if (!string.IsNullOrEmpty(filters.Genre))
                books = books.Where(p => p.Specifications.Genres.Contains(filters.Genre)).ToList();

            if (!string.IsNullOrEmpty(filters.Illustrator))
                books = books.Where(p => p.Specifications.Illustrator.Any(s => s.Contains(filters.Illustrator))).ToList();

            if (filters.InitialNumberPages != null)
                books = books.Where(p => p.Specifications.PageCount >= filters.InitialNumberPages).ToList();

            if (filters.FinalNumberPages != null)
                books = books.Where(p => p.Specifications.PageCount <= filters.FinalNumberPages).ToList();


            switch (filters.OrderBy)
            {
                case "author":
                    books = filters.Ascending ? books.OrderBy(p => p.Specifications.Author).ToList() : books.OrderByDescending(p => p.Specifications.Author).ToList();
                    break;

                case "name":
                    books = filters.Ascending ? books.OrderBy(p => p.Name).ToList() : books.OrderByDescending(p => p.Name).ToList();
                    break;

                case "page":
                    books = filters.Ascending ? books.OrderBy(p => p.Specifications.PageCount).ToList() : books.OrderByDescending(p => p.Specifications.PageCount).ToList();
                    break;

                case "price":
                    books = filters.Ascending ? books.OrderBy(p => p.Price).ToList() : books.OrderByDescending(p => p.Price).ToList();
                    break;

                default:
                    break;
            }


            return books;
        }

        public double Shipping(int id)
        {
            var book = _repo.Query().Where(p => p.Id == id).FirstOrDefault();

            if (book == null)
                return 0;

            return book.Price * 0.2;
        }
    }
}
