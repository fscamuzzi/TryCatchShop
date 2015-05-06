using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.IRepositories
{
    public interface IRepository<TEntity>
    {
        void Insert(TEntity entity);

        void Delete(TEntity entity);

        Task<int> DeleteAsync(TEntity t);

        int Count();

        Task<int> CountAsync();

        ICollection<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        ICollection<TEntity> GetAll();

        Task<ICollection<TEntity>> GetAllAsync();

        TEntity GetById(int id);
        Task<TEntity> GetByIdAsync(int id);

        TEntity FindEntityBy(Expression<Func<TEntity, bool>> match);

        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match);

        ICollection<TEntity> FindAll(Expression<Func<TEntity, bool>> match);

        Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match);

        TEntity Add(TEntity t);

        Task<TEntity> AddAsync(TEntity t);

        IEnumerable<TEntity> AddAll(IEnumerable<TEntity> tList);

        Task<IEnumerable<TEntity>> AddAllAsync(IEnumerable<TEntity> tList);

        TEntity Update(TEntity updated, int key);

        Task<TEntity> UpdateAsync(TEntity updated, int key);
    }
}