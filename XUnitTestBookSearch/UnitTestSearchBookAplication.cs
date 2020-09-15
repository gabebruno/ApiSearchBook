using BookSearchAplication;
using BookSearchDomain.Aplication;
using BookSearchDomain.Dto;
using BookSearchDomain.Model;
using BookSearchDomain.Repository;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace XUnitTestBookSearch
{
    public class UnitTestSearchBookAplication
    {
        private readonly IBookService _bookService;
        private readonly Mock<IBookRepository> _bookRepositoryMock = new Mock<IBookRepository>();

        public UnitTestSearchBookAplication()
        {
            //Realiza manualmente a injeção de dependência
            _bookService = new BookService(_bookRepositoryMock.Object);
        }

        private List<Book> MockBookList()
        {
            var json = File.ReadAllText(@"../../../Mock/books.json", Encoding.GetEncoding("iso-8859-1"));

            var books = JsonConvert.DeserializeObject<List<Book>>(json);

            return books;
        }

        [Theory]
        [InlineData("Jules Verne", 2)]
        [InlineData("J. K. Rowling", 2)]
        [InlineData("J. R. R. Tolkien", 1)]
        [InlineData("J", 5)]
        [InlineData("Gabriel", 0)]
        public void AuthorSearchBook(string name, int returnCount)
        {
            //Arranjo
            var filter = new FilterDTO
            {
                Author = name
            };
            _bookRepositoryMock.Setup(m => m.Query()).Returns(MockBookList());

            //Ação
            var result = _bookService.SearchBook(filter);

            //Confirmação
            Assert.Equal(returnCount, result.Count);
        }

        [Theory]
        [InlineData("Journey to the Center of the Earth", 1)]
        [InlineData("20,000 Leagues Under the Sea", 1)]
        [InlineData("Harry Potter and the Goblet of Fire", 1)]
        [InlineData("Fantastic Beasts and Where to Find Them: The Original Screenplay", 1)]
        [InlineData("The Lord of the Rings", 1)]
        [InlineData("a", 4)]
        public void NameSearchBook(string name, int returnCount)
        {
            //Arranjo
            var filter = new FilterDTO
            {
                BookName = name
            };
            _bookRepositoryMock.Setup(m => m.Query()).Returns(MockBookList());

            //Ação
            var result = _bookService.SearchBook(filter);

            //Confirmação
            Assert.Equal(returnCount, result.Count);
        }



        [Theory]
        [InlineData(10, 3)]
        [InlineData(11, 1)]
        [InlineData(12, 0)]
        [InlineData(0, 5)]
        public void InitialPriceSearchBook(double price, int returnCount)
        {
            //Arranjo
            var filter = new FilterDTO
            {
                InitialPrice = price
            };
            _bookRepositoryMock.Setup(m => m.Query()).Returns(MockBookList());

            //Ação
            var result = _bookService.SearchBook(filter);

            //Confirmação
            Assert.Equal(returnCount, result.Count);
        }

        [Theory]
        [InlineData(6.15, 1)]
        [InlineData(5, 0)]
        [InlineData(7.31, 2)]
        [InlineData(100, 5)]
        public void FinalPriceSearchBook(double price, int returnCount)
        {
            //Arranjo
            var filter = new FilterDTO
            {
                FinalPrice = price
            };
            _bookRepositoryMock.Setup(m => m.Query()).Returns(MockBookList());

            //Ação
            var result = _bookService.SearchBook(filter);

            //Confirmação
            Assert.Equal(returnCount, result.Count);
        }



        [Theory]
        [InlineData("Adventure fiction", 2)]
        [InlineData("Adventure Fiction", 1)]
        [InlineData("banana", 0)]
        [InlineData("Science Fiction", 1)]
        public void GenreSearchBook(string genre, int returnCount)
        {
            //Arranjo
            var filter = new FilterDTO
            {
                Genre = genre
            };
            _bookRepositoryMock.Setup(m => m.Query()).Returns(MockBookList());

            //Ação
            var result = _bookService.SearchBook(filter);

            //Confirmação
            Assert.Equal(returnCount, result.Count);
        }


        [Theory]
        [InlineData("Cliff Wright", 2)]
        [InlineData("Édouard Riou", 2)]
        [InlineData("Mary GrandPré", 1)]
        [InlineData("Tolkien", 1)]
        public void IllustratorSearchBook(string name, int returnCount)
        {
            //Arranjo
            var filter = new FilterDTO
            {
                Illustrator = name
            };
            _bookRepositoryMock.Setup(m => m.Query()).Returns(MockBookList());

            //Ação
            var result = _bookService.SearchBook(filter);

            //Confirmação
            Assert.Equal(returnCount, result.Count);
        }





        [Theory]
        [InlineData(0, 5)]
        [InlineData(1000, 0)]
        [InlineData(184, 4)]
        [InlineData(213, 4)]
        public void InitialPageSearchBook(int pages, int returnCount)
        {
            //Arranjo
            var filter = new FilterDTO
            {
                InitialNumberPages = pages
            };
            _bookRepositoryMock.Setup(m => m.Query()).Returns(MockBookList());

            //Ação
            var result = _bookService.SearchBook(filter);

            //Confirmação
            Assert.Equal(returnCount, result.Count);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1000, 5)]
        [InlineData(184, 1)]
        [InlineData(636, 4)]
        public void FinalPageSearchBook(int pages, int returnCount)
        {
            //Arranjo
            var filter = new FilterDTO
            {
                FinalNumberPages = pages
            };
            _bookRepositoryMock.Setup(m => m.Query()).Returns(MockBookList());

            //Ação
            var result = _bookService.SearchBook(filter);

            //Confirmação
            Assert.Equal(returnCount, result.Count);
        }



        [Theory]
        [InlineData("autor", true, 3)]
        [InlineData("autor", false, 1)]
        [InlineData("nome", true, 2)]
        [InlineData("nome", false, 5)]
        [InlineData("preco", true, 5)]
        [InlineData("preco", false, 4)]
        [InlineData("pagina", true, 1)]
        [InlineData("pagina", false, 5)]
        public void OrderedSearchBook(string field, bool ascending, int registryId)
        {
            //Arranjo
            var filter = new FilterDTO
            {
                Orderby = field,
                Ascending = ascending
            };
            _bookRepositoryMock.Setup(m => m.Query()).Returns(MockBookList());

            //Ação
            var result = _bookService.SearchBook(filter);

            //Confirmação
            Assert.Equal(registryId, result.First().Id);
        }


        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 2.02)]
        [InlineData(3, 1.462)]
        [InlineData(4, 2.23)]
        [InlineData(5, 1.2300000000000002)]
        public void ShippingCost(int id, double shipping)
        {
            //Arranjo
            _bookRepositoryMock.Setup(m => m.Query()).Returns(MockBookList());

            //Ação
            var result = _bookService.Shipping(id);

            //Confirmação
            Assert.Equal(shipping, result);
        }


    }
}
