using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext carContext = new TContext())
            {
                var addedCar = carContext.Entry(entity);
                addedCar.State = EntityState.Added;
                carContext.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext carContext = new TContext())
            {
                var deletedCar = carContext.Entry(entity);
                deletedCar.State = EntityState.Deleted;
                carContext.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext carContext = new TContext())
            {
                return carContext.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext carContext = new TContext())
            {
                return filter == null ?
                    carContext.Set<TEntity>().ToList() : carContext.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext carContext = new TContext())
            {
                var updatedCar = carContext.Entry(entity);
                updatedCar.State = EntityState.Modified;
                carContext.SaveChanges();
            }
        }
    }
}
