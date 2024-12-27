using DATA.Data.Entity;
using DATA.Data;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository.Concrete
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly BookDbContext context;
        public BookRepository(BookDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<Book>> Search(string input)
        {
            var bookEntity = await context.Books.Where(b=>b.BookName == input || b.Genre == input || b.Publisher == input).ToListAsync();
            return bookEntity;
        }

        public Task<List<Book>> Search<T>(T input)
        {
            throw new NotImplementedException();
        }
    }
}
