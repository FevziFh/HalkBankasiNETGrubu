using _36_EF_BookProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _36_EF_BookProject.Service.Interface
{
    public interface IBaseCRUD<T> where T : BaseEntity
    {
        void Add(T entity);
        void Modified(T entity);
        void Delete(T entity);
        IList<T> GetAll();
        T GetBy(int id);
    }
}
