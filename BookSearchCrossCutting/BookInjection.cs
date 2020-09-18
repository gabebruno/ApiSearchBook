using BookSearchAplication;
using BookSearchDomain.Aplication;
using BookSearchDomain.Repository;
using BookSearchRepository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookSearchCrossCutting
{
    public class BookInjector
    {
        public static void Main(IServiceCollection services)
        {
            //Repositories
            services.AddScoped<IBookRepository, BookRepository>();

            //Services
            services.AddScoped<IBookService, BookService>();
        }

    }
}
