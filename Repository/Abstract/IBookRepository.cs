using DATA.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<List<Book>> Search<T>(T input);
    }
}
