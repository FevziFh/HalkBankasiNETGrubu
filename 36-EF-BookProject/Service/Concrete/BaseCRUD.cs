using _36_EF_BookProject.Context;
using _36_EF_BookProject.Enums;
using _36_EF_BookProject.Model;
using _36_EF_BookProject.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _36_EF_BookProject.Service.Concrete
{
    public class BaseCRUD<T> : IBaseCRUD<T> where T : BaseEntity
    {
        private readonly AppDbContext appDbContext;
        public BaseCRUD(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public void Add(T entity)
        {
            appDbContext.Set<T>().Add(entity);
            appDbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            entity.Status = Status.Passive;
            entity.DeleteDate = DateTime.Now;
            appDbContext.SaveChanges();
        }

        public IList<T> GetAll()
        {
            return appDbContext.Set<T>().Where(x => x.Status != Status.Passive).ToList();
        }

        public T GetBy(int id)
        {
            return appDbContext.Set<T>().FirstOrDefault(x => x.Id == id && x.Status != Status.Passive);
        }

        public void Modified(T entity)
        {
            entity.Status = Status.Modified;
            entity.UpdateDate = DateTime.Now;
            appDbContext.Set<T>().Update(entity);
            appDbContext.SaveChanges();
        }
    }
}
