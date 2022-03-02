using ExamSystem.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.DataAccess.Abstract
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        TEntity Get(int entityId);
        void Delete(int entityId);
        List<TEntity> GetAll();
    }
}
