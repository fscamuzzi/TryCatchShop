using Business.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public abstract class Repository<TObject> : IRepository<TObject> where TObject : class
    {
        protected DbContext _context;

        /// <summary>
        /// The contructor requires an open DataContext to work with
        /// </summary>
        /// <param name="context">An open DataContext</param>
        protected Repository(DbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns a single object with a primary key of the provided id
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="id">The primary key of the object to fetch</param>
        /// <returns>A single object with the provided primary key or null</returns>
        public virtual TObject GetById(int id)
        {
            return _context.Set<TObject>().Find(id);
        }

        public virtual async Task<TObject> GetByIdAsync(int id)
        {
            return await _context.Set<TObject>().FindAsync(id);
        }

        /// <summary>
        /// Returns a single object with a primary key of the provided id
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="id">The primary key of the object to fetch</param>
        /// <returns>A single object with the provided primary key or null</returns>
        public virtual async Task<TObject> GetAsync(int id)
        {
            return await _context.Set<TObject>().FindAsync(id);
        }

        /// <summary>
        /// Gets a collection of all objects in the database
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <returns>An ICollection of every object in the database</returns>
        public virtual ICollection<TObject> GetAll()
        {
            return _context.Set<TObject>().ToList();
        }

        /// <summary>
        /// Finds the entity by.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns></returns>
        public virtual TObject FindEntityBy(Expression<Func<TObject, bool>> match)
        {
            return _context.Set<TObject>().FirstOrDefault(match);
        }

        /// <summary>
        /// Gets a collection of all objects in the database
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <returns>An ICollection of every object in the database</returns>
        public virtual async Task<ICollection<TObject>> GetAllAsync()
        {
            return await _context.Set<TObject>().ToListAsync();
        }

        /// <summary>
        /// Returns a single object which matches the provided expression
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="match">A Linq expression filter to find a single result</param>
        /// <returns>A single object which matches the expression filter.
        /// If more than one object is found or if zero are found, null is returned</returns>
        public virtual ICollection<TObject> Find(Expression<Func<TObject, bool>> match)
        {
            return _context.Set<TObject>().Where(match).ToList();
        }

        /// <summary>
        /// Returns a single object which matches the provided expression
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="match">A Linq expression filter to find a single result</param>
        /// <returns>A single object which matches the expression filter.
        /// If more than one object is found or if zero are found, null is returned</returns>
        public virtual async Task<TObject> FindAsync(Expression<Func<TObject, bool>> match)
        {
            return await _context.Set<TObject>().SingleOrDefaultAsync(match);
        }

        /// <summary>
        /// Returns a collection of objects which match the provided expression
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="match">A linq expression filter to find one or more results</param>
        /// <returns>An ICollection of object which match the expression filter</returns>
        public virtual ICollection<TObject> FindAll(Expression<Func<TObject, bool>> match)
        {
            return _context.Set<TObject>().Where(match).ToList();
        }

        /// <summary>
        /// Returns a collection of objects which match the provided expression
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="match">A linq expression filter to find one or more results</param>
        /// <returns>An ICollection of object which match the expression filter</returns>
        public virtual async Task<ICollection<TObject>> FindAllAsync(Expression<Func<TObject, bool>> match)
        {
            return await _context.Set<TObject>().Where(match).ToListAsync();
        }

        /// <summary>
        /// Inserts a single object to the database and commits the change
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="t">The object to insert</param>
        /// <returns>The resulting object including its primary key after the insert</returns>
        public virtual TObject Add(TObject t)
        {
            using (DbContextTransaction dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Set<TObject>().Add(t);
                    _context.SaveChanges();
                    dbContextTransaction.Commit();

                    return t;
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                    return null;
                }
            }
        }

        /// <summary>
        /// Inserts a single object to the database and commits the change
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="t">The object to insert</param>
        /// <returns>The resulting object including its primary key after the insert</returns>
        public virtual async Task<TObject> AddAsync(TObject t)
        {
            using (DbContextTransaction dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Set<TObject>().Add(t);
                    await _context.SaveChangesAsync();
                    dbContextTransaction.Commit();

                    return t;
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                    return null;
                }
            }
        }

        /// <summary>
        /// Inserts a collection of objects into the database and commits the changes
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="tList">An IEnumerable list of objects to insert</param>
        /// <returns>The IEnumerable resulting list of inserted objects including the primary keys</returns>
        public virtual IEnumerable<TObject> AddAll(IEnumerable<TObject> tList)
        {
            using (DbContextTransaction dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var addAll = tList as IList<TObject> ?? tList.ToList();
                    _context.Set<TObject>().AddRange(addAll);
                    _context.SaveChanges();
                    dbContextTransaction.Commit();

                    return addAll;
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                    return null;
                }
            }
        }

        /// <summary>
        /// Inserts a collection of objects into the database and commits the changes
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="tList">An IEnumerable list of objects to insert</param>
        /// <returns>The IEnumerable resulting list of inserted objects including the primary keys</returns>
        public virtual async Task<IEnumerable<TObject>> AddAllAsync(IEnumerable<TObject> tList)
        {
            using (DbContextTransaction dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Set<TObject>().AddRange(tList);
                    await _context.SaveChangesAsync();
                    dbContextTransaction.Commit();
                    return tList;
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                    return null;
                }
            }
        }

        /// <summary>
        /// Updates a single object based on the provided primary key and commits the change
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="updated">The updated object to apply to the database</param>
        /// <param name="key">The primary key of the object to update</param>
        /// <returns>The resulting updated object</returns>
        public virtual TObject Update(TObject updated, int key)
        {
            using (DbContextTransaction dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    if (updated == null) return null;

                    TObject existing = _context.Set<TObject>().Find(key);
                    if (existing == null) return null;
                    _context.Entry(existing).CurrentValues.SetValues(updated);
                    _context.SaveChanges();
                    return existing;
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                    return null;
                }
            }
        }

        /// <summary>
        /// Updates a single object based on the provided primary key and commits the change
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="updated">The updated object to apply to the database</param>
        /// <param name="key">The primary key of the object to update</param>
        /// <returns>The resulting updated object</returns>
        public virtual async Task<TObject> UpdateAsync(TObject updated, int key)
        {
            if (updated == null) return null;

            using (DbContextTransaction dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    TObject existing = await _context.Set<TObject>().FindAsync(key);
                    if (existing == null) return null;
                    _context.Entry(existing).CurrentValues.SetValues(updated);
                    await _context.SaveChangesAsync();
                    dbContextTransaction.Commit();

                    return existing;
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                    return null;
                }
            }
        }

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Insert(TObject entity)
        {
            using (DbContextTransaction dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Set<TObject>().Add(entity);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                }
            }
        }

        /// <summary>
        /// Deletes a single object from the database and commits the change
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="t">The object to delete</param>
        public virtual void Delete(TObject t)
        {
            using (DbContextTransaction dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Set<TObject>().Remove(t);
                    _context.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                }
            }
        }

        /// <summary>
        /// Deletes a single object from the database and commits the change
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="t">The object to delete</param>
        public virtual async Task<int> DeleteAsync(TObject t)
        {
            using (DbContextTransaction dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Set<TObject>().Remove(t);
                    int rows = await _context.SaveChangesAsync();
                    dbContextTransaction.Commit();
                    return rows;
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                    return 0;
                }
            }
        }

        /// <summary>
        /// Gets the count of the number of objects in the databse
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <returns>The count of the number of objects</returns>
        public virtual int Count()
        {
            return _context.Set<TObject>().Count();
        }

        /// <summary>
        /// Gets the count of the number of objects in the databse
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <returns>The count of the number of objects</returns>
        public virtual async Task<int> CountAsync()
        {
            return await _context.Set<TObject>().CountAsync();
        }
    }
}