using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.Business.Abstract
{
    public interface IService<TEntity>
    {
        void Create(TEntity entity);
        void Delete(int entityId);
        TEntity Get(int entityId);
        void Update(TEntity entity);
    }
}
