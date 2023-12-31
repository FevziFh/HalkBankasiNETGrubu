﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query;
using Movie.DAL.Contexts;
using Movie.DAL.Interfaces;
using Movie.DATA.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Movie.DAL.Concrete
{
    public class BaseDAL<T> : IBaseDAL<T> where T : BaseFilm
    {
        private DbSet<T> _table;
        private FilmContext _filmContext;
        public BaseDAL(FilmContext filmContext)
        {
            _filmContext = filmContext;
            _table = filmContext.Set<T>();
        }

        public bool Any(Expression<Func<T, bool>> expression)
        {

            throw new NotImplementedException();
        }

        public void Create(T Entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T Entity)
        {
            throw new NotImplementedException();
        }

        public T GetDefault(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public List<T> GetDefaults(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public List<TResult> GetFilteredList<TResult>(Expression<Func<T, TResult>> select, Expression<Func<T, bool>> where, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> join = null)
        {
            IQueryable<T> query = _table;

            if (join != null)
            {
                query = join(_table);
            }
            if (where != null)
            {
                query = query.Where(where);
            }
            if (orderBy != null)
            {
                return orderBy(query).Select(select).ToList();
            }
            else
            {
                return query.Select(select).ToList();
            }
        }

        public void Update(T Entity)
        {
            throw new NotImplementedException();
        }
    }
}
