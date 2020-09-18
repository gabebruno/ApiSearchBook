using BookSearchAplication;
using BookSearchDomain.Aplication;
using BookSearchDomain.Repository;
using BookSearchRepository;
using Microsoft.Extensions.DependencyInjection;

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
