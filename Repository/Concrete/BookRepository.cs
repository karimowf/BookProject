using DATA.Data.Entity;
using DATA.Data;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Concrete
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly BookDbContext context;
        public BookRepository(BookDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Book> Search(string input)
        {
            var bookEntity = await context.Books.Where(b => b.AuthorName == input || b.Bookname == input || b.Genre == input || b.Publisher == input).FirstOrDefaultAsync();
            return bookEntity;
        }
    }
}
