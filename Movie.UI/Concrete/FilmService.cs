using Movie.DAL.Interfaces;
using Movie.DATA.Concrete;
using Movie.UI.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Movie.UI.Concrete
{
    public class FilmService : IFilmService
    {
        private readonly IFilmDAL _filmDAL;
        public FilmService(IFilmDAL filmDAL)
        {
            _filmDAL = filmDAL;
        }

        public void Add(Film entity)
        {
            if (entity is not null)
            {
                _filmDAL.Create(entity);
            }
            else
            {
                throw new Exception("Film ekleme işleminde hata oldu.");
            }
        }

        public void Delete(Film entity)
        {
            if (entity is not null)
            {
                entity.DeletedDate = DateTime.Now;
                entity.Status = DATA.Enums.Status.Deleted;
                _filmDAL.Delete(entity);
            }
            else
            {
                throw new Exception("Film silme işleminde hata oldu.");
            }
        }

        public List<Film> GetByDefaults(Expression<Func<Film, bool>> expression, int _skip, int _take)
        {

            return _filmDAL.GetDefaults(expression).Skip(_skip).Take(_take).ToList();
        }

        public List<Film> GetByDefaultsOrdered(Expression<Func<Film, bool>> expression)
        {
            return _filmDAL.GetDefaults(expression).OrderBy(f => f.PublishDate).ToList();
        }

        public void Update(Film entity)
        {
            if (entity is not null)
            {
                entity.UpdateDate = DateTime.Now;
                entity.Status = DATA.Enums.Status.Modified;
                _filmDAL.Update(entity);
            }
            else
            {
                throw new Exception("Film silme işleminde hata oldu.");
            }
        }
    }
}
