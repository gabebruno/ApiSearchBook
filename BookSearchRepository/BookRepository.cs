using BookSearchDomain.Model;
using BookSearchDomain.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BookSearchRepository
{
    public class BookRepository : IBookRepository
    {
        public List<Book> Query()
        {
            var json = File.ReadAllText(@"../FindBookRepository/Mock/books.json", Encoding.GetEncoding("iso-8859-1"));

            var books = JsonConvert.DeserializeObject<List<Book>>(json);

            return books;
        }
    }
}
