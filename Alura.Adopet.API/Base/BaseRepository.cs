using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System;
using Alura.Adopet.API.Dados.Context;

namespace Alura.Adopet.API.Base
{
    public class BaseRepository<T> : IBase<T> where T : class
    {
    
            private DataBaseContext _context;
            public BaseRepository(DataBaseContext context)
            {
                _context = context;
            }

            public void Add(T entity)
            {
                try
                {
                  _context.Set<T>().Add(entity);
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            
            }

            public void Delete(T entity)
            {
                _context.Set<T>().Remove(entity);
            }

            public virtual async Task<IEnumerable<T>> Get()
            {
                return await _context.Set<T>().AsNoTracking().ToListAsync();
            }

            public T GetById(Expression<Func<T, bool>> predicate)
            {
                return _context.Set<T>().SingleOrDefault(predicate);
            }

            public void Update(T entity)
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.Set<T>().Update(entity);
            }
        }
    
}
