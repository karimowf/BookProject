using DATA.Data;
using Microsoft.EntityFrameworkCore;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly BookDbContext context;
        private readonly DbSet<T> table;

        public GenericRepository(BookDbContext context)
        {
            this.context = context;
            table = context.Set<T>();
        }

        public async Task Create(T entity)
        {
            await table.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            table.Remove(entity);
        }

        public async Task<List<T>> GetAll()
        {
            var allEntities = await table.ToListAsync();
            return allEntities;
        }

        public async Task<T>? GetByID(int ID)
        {
            var entity = await table.FindAsync(ID);

            return entity;

        }

        public void Update(T entity)
        {
            table.Update(entity);
        }
    }
}
