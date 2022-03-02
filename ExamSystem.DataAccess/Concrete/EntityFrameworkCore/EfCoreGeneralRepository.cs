using ExamSystem.DataAccess.Abstract;
using ExamSystem.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamSystem.DataAccess.Concrete.EntityFramework
{
    public class EfCoreGeneralRepository<TEntity, TContext> : IRepository<TEntity> where TEntity : class, IEntity where TContext : DbContext, new()
    {
        public void Create(TEntity entity)
        {
            using(var context = new TContext())
            {
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(int entityId)
        {
            using(var context = new TContext())
            {
                var entity = context.Set<TEntity>().Find(entityId);
                context.Set<TEntity>().Remove(entity);
            }
        }

        public TEntity Get(int entityId)
        {
            using(var context = new TContext())
            {
                var entity = context.Set<TEntity>().Find(entityId);
                return entity;
            }
        }

        public List<TEntity> GetAll()
        {
            using(var context = new TContext())
            {
                var entityList = context.Set<TEntity>().ToList();
                return entityList;
            }
        }

        public void Update(TEntity entity)
        {
            using(var context = new TContext())
            {
                context.Set<TEntity>().Update(entity);
                context.SaveChanges();
            }
        }
    }
}
