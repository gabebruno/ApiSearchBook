using BookSearchDomain.Model;
using BookSearchDomain.Repository;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace BookSearchRepository
{
    public class BookRepository : IBookRepository
    {
        public List<Book> Query()
        {
            var booksJson = File.ReadAllText(@"../BookSearchRepository/Mock/books.json", Encoding.GetEncoding("iso-8859-1"));
            var json = JsonConvert.DeserializeObject(booksJson).ToString();
            DebuggerDisplayAttribute(json);
            var result = JsonConvert.DeserializeObject<List<Book>>(booksJson);

            //var books = JsonConvert.DeserializeObject<List<Book>>(json);

            return result;
        }
    }
}
