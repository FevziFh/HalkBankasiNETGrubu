using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _29_EF_RelationshipEFCore.Service.Abstract
{
    public interface IBaseService<T> where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        IList<T> Get();
        IList<T> GetByDefaults(Expression<Func<T, bool>> expression);
        T GetById(int id);
        bool GetAny(Expression<Func<T, bool>> expression);
    }
}
