using System;
using System.Collections.Generic;
using System.Text;

namespace TypTop.Repository
{
    interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Remove(TEntity entity);
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
    }
}
