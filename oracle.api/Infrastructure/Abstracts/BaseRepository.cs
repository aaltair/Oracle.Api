using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using oracle.api.Infrastructure.Interfaces;

namespace oracle.api.Infrastructure.Abstracts
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        protected BaseRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual TEntity GetById(object id)
        {
            _dbSet.AsNoTracking();

            var entryToFind = _dbSet.Find(id);

            if (entryToFind != null)
                _context.Entry(entryToFind).State = EntityState.Detached;

            return entryToFind;
        }

        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> filter = null)
        {
            var entryToFind = _dbSet.FirstOrDefault(filter);

            if (entryToFind != null)
                _context.Entry(entryToFind).State = EntityState.Detached;

            return entryToFind;
        }

        public virtual TEntity FirstOrDefault(string include, Expression<Func<TEntity, bool>> filter = null)
        {
            var query = _dbSet.Where(filter);
            query = include.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            var entryToFind = query.FirstOrDefault();

            if (entryToFind != null)
                _context.Entry(entryToFind).State = EntityState.Detached;

            return entryToFind;
        }

        public virtual IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "", int? pageIndex = null, int? pageSize = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null) query = query.Where(filter);
            query = includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            if (orderBy != null)
            {
                orderBy(query);
            }

            if (!pageIndex.HasValue || !pageSize.HasValue)
                return query.AsNoTracking().ToList();

            pageIndex = pageIndex.Value <= 0 ? 0 : (pageIndex - 1) * pageSize;
            query = query.Skip(pageIndex.Value);
            query = query.Take(pageSize.Value);
            return query.AsNoTracking().ToList();
        }

        /// <summary>
        /// Find entity by predicate.
        /// </summary>
        /// <param name="predicate">Predicate expression.</param>
        /// <returns>IEnumerable collection of entities.</returns>
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            _dbSet.AsNoTracking();
            return _dbSet.Where(predicate);
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);


        }

        /// <summary>
        /// Add range of entities.
        /// </summary>
        /// <param name="entities">IEnumerable collection of entities.</param>
        public void AddRange(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }

        public virtual void Remove(object id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            Remove(entityToDelete);
        }

        public virtual void Remove(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            _dbSet.AsNoTracking();
            _dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }
        /// <summary>
        /// Remove range of entities.
        /// </summary>
        /// <param name="entities">IEnumerable collection of entities.</param>
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        /// <summary>
        /// Get entities count.
        /// </summary>
        /// <returns>Entities count.</returns>
        public int Count()
        {
            return _dbSet.Count();
        }

    }
}