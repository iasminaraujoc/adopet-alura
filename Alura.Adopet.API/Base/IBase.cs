using System.Linq.Expressions;

namespace Alura.Adopet.API.Base
{
    public interface IBase<T>
    {
        Task<IEnumerable<T>> Get();        
        T GetById(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
