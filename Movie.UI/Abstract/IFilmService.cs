using Movie.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Movie.UI.Abstract
{
    public interface IFilmService
    {
        void Add(Film entity);
        void Update(Film entity);
        void Delete(Film entity);
        List<Film> GetByDefaults(Expression<Func<Film, bool>> expression, int _skip, int _take);

        List<Film> GetByDefaultsOrdered(Expression<Func<Film, bool>> expression);
    }
}
