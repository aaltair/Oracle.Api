using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace oracle.api.Infrastructure.Interfaces
{
    public interface IRepository<TEntity>
    {

        TEntity GetById(object id);


        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, string includeProperties
            , int? pageIndex, int? pageSize);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);


        void Add(TEntity entity);


        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);


        void RemoveRange(IEnumerable<TEntity> entities);


        int Count();

        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> filter = null);
    }
}