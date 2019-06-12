using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Buchhaltung.Persistence.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext ctx;

        public Repository(DbContext ctx)
        {
            this.ctx = ctx;
        }

        public TEntity Get(int id)
        {
            return ctx.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            if (orderBy != null)
            {
                IQueryable<TEntity> query = ctx.Set<TEntity>();
                return orderBy(query).ToList();
            }
            else
            {
                return ctx.Set<TEntity>().ToList();
            }
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return ctx.Set<TEntity>().Where(predicate);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return ctx.Set<TEntity>().SingleOrDefault(predicate);
        }

        public void Add(TEntity entity)
        {
            ctx.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            ctx.Set<TEntity>().AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            ctx.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            ctx.Set<TEntity>().RemoveRange(entities);
        }
        public void Update(TEntity entity)
        {
            ctx.Set<TEntity>().Attach(entity);
            ctx.Entry(entity).State = EntityState.Modified;
        }
    }
}