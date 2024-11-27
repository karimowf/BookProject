using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IGenericRepository<T>
    {
        Task Create(T entity);
        Task<T> GetByID(int ID);
        void Delete(T entity);
        void Update(T entity);
        Task<List<T>> GetAll();
    }
}
