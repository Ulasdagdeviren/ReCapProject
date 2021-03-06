using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ReCapProject.Core.Entities;

namespace ReCapProject.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
    }
}
