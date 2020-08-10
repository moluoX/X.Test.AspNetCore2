using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using X.Test.AspNetCore2.Service.Base;

namespace X.Test.AspNetCore2.Service.Impl.Base
{
    public class BaseService<T> : IBaseService<T> where T : class, new()
    {
        private IDbContextFactory<DbContext> _contextFactory;
        private DbContext _context;
        private DbSet<T> _set;
        private DbContext _contextRead;
        private DbSet<T> _setRead;

        protected DbContext Context(DbContextReadOrWrite readOrWrite = DbContextReadOrWrite.Write)
        {
            switch (readOrWrite)
            {
                case DbContextReadOrWrite.Read:
                    if (_contextRead == null)
                    {
                        _contextRead = _contextFactory.GetDbContext(DbContextReadOrWrite.Read);
                    }
                    return _contextRead;
                case DbContextReadOrWrite.Write:
                    if (_context == null)
                    {
                        _context = _contextFactory.GetDbContext(DbContextReadOrWrite.Write);
                    }
                    return _context;
                default:
                    throw new ArgumentOutOfRangeException(nameof(readOrWrite));
            }
        }

        protected DbSet<T> Set(DbContextReadOrWrite readOrWrite = DbContextReadOrWrite.Write)
        {
            switch (readOrWrite)
            {
                case DbContextReadOrWrite.Read:
                    if (_setRead == null)
                    {
                        _setRead = Context(readOrWrite).Set<T>();
                    }
                    return _setRead;
                case DbContextReadOrWrite.Write:
                    if (_set == null)
                    {
                        _set = Context(readOrWrite).Set<T>();
                    }
                    return _set;
                default:
                    throw new ArgumentOutOfRangeException(nameof(readOrWrite));
            }
        }

        public BaseService(IDbContextFactory<DbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Add(T m)
        {
            Set().Add(m);
            await Context().SaveChangesAsync();
        }

        public async Task Update(T m)
        {
            Set().Update(m);
            await Context().SaveChangesAsync();
        }

        public async Task<T> Get(int id, DbContextReadOrWrite readOrWrite = DbContextReadOrWrite.Read)
        {
            return await Set(readOrWrite).FindAsync(id);
        }

        public async Task<List<T>> ListAll(DbContextReadOrWrite readOrWrite = DbContextReadOrWrite.Read)
        {
            return await Set(readOrWrite).ToListAsync();
        }

        public async Task Delete(int id)
        {
            var student = await Set().FindAsync(id);
            Set().Remove(student);
            await Context().SaveChangesAsync();
        }
    }
}

