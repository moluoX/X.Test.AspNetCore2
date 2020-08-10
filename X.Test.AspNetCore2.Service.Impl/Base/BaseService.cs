using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace X.Test.AspNetCore2.Service.Impl
{
    public class BaseService<T> : IBaseService<T> where T : class, new()
    {
        protected DbContext _context;
        protected DbSet<T> _dbSet;
        protected DbContext _contextRead;
        protected DbSet<T> _dbSetRead;
        public BaseService(DbContext context, DbContext contextRead)
        {
            _context = context;
            _dbSet = _context.Set<T>();
            _contextRead = contextRead;
            _dbSetRead = _contextRead.Set<T>();
        }

        public async Task Add(T m)
        {
            _dbSet.Add(m);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T m)
        {
            _dbSet.Update(m);
            await _context.SaveChangesAsync();
        }

        public async Task<T> Get(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<T>> ListAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task Delete(int id)
        {
            var student = await Get(id);
            _dbSet.Remove(student);
            await _context.SaveChangesAsync();
        }
    }
}

