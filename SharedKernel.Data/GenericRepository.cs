using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SharedKernel.Data
{
    public class GenericRepository<TEntity> where TEntity : class, IEntity, IClientChangeTracker
    {
        protected DbContext _dataContext;
        protected DbSet<TEntity> _dataTable;
        public GenericRepository(DbContext dataContext)
        {
            if (dataContext == null)
            {
                throw new ArgumentNullException("dataContext");
            }
            _dataContext = dataContext;
            _dataTable = _dataContext.Set<TEntity>();

            _dataContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public virtual void Add(params TEntity[] items)
        {
            Edit(items);
        }

        public virtual void Edit(params TEntity[] items)
        {
            foreach (TEntity item in items)
            {
                _dataContext.FixState(item);
            }
        }
        public virtual void Delete(params TEntity[] items)
        {
            foreach (TEntity item in items)
            {
                _dataTable.Remove(item);
            }
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dataTable.ToList();
        }

        public virtual TEntity GetById(int id)
        {
            return _dataTable.SingleOrDefault(e => e.Id == id);
        }

        public virtual IEnumerable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate)
        {
            return _dataTable.Where(predicate).ToList();
        }

        public virtual IEnumerable<TEntity> GetAllInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return GetAllIncluding(includeProperties).ToList();
        }

        public virtual IEnumerable<TEntity> SearchForInclude(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = GetAllIncluding(includeProperties);
            return query.Where(predicate).ToList();
        }

        private IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> queryable = _dataTable;
            return includeProperties.Aggregate(queryable, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
