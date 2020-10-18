using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class EFBookRepository : IBookRepository
    {
        private ApplicationDbContext context;

        public EFBookRepository(ApplicationDbContext ef)
        {
            context = ef;
        }

        public IQueryable<Book> Books => context.Books;

        public IEnumerable<Book> BooksByAuthorOrName(string query)
        {
            return context.Books.Where(book => book.Author.Contains(query) ||
            book.Name.Contains(query));
        }
    }
}
