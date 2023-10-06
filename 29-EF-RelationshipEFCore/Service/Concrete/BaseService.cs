using _29_EF_RelationshipEFCore.Contexts;
using _29_EF_RelationshipEFCore.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _29_EF_RelationshipEFCore.Service.Concrete
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly AppDbContext context;

        public BaseService(AppDbContext context)
        {
            this.context = context;
        }

        public void Add(T entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }

        public IList<T> GetByDefaults(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().Where(expression).ToList();
        }

        public IList<T> Get()
        {
            return context.Set<T>().ToList();
        }

        public bool GetAny(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().Any(expression);
        }

        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            context.Update(entity);
            context.SaveChanges();
        }
    }
}
