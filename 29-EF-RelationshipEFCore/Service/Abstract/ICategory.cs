using _29_EF_RelationshipEFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _29_EF_RelationshipEFCore.Service.Abstract
{
    public interface ICategory
    {
        void Add(Category entity);
        void Delete(Category entity);
        void Update(Category entity);
        IList<Category> GetCategory();
        IList<Category> GetByDefaults(Expression<Func<Category, bool>> expression);
        Category GetCategoryById(int id);
        bool GetCategoryAny(int id);
    }
}
