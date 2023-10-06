using EventProject.Core.Entities;
using EventProject.Repository.Contexts;
using EventProject.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Repository.Concreate
{
    public class EventDetailRepo : IEventDetailRepo
    {
        private readonly AppDbContext _context;
        public EventDetailRepo(AppDbContext context) 
        {
            _context = context;
        }

        public bool Any(Expression<Func<EventDetail, bool>> expression)
        {
            return _context.EventDetails.Any(expression);
        }

        public void Create(EventDetail Entity)
        {
            _context.EventDetails.Add(Entity);
            _context.SaveChanges();
        }

        public void Delete(EventDetail Entity)
        {
            _context.EventDetails.Remove(Entity);
            _context.SaveChanges();
        }

        public EventDetail GetDefault(Expression<Func<EventDetail, bool>> expression)
        {
            return _context.EventDetails.FirstOrDefault(expression);
        }

        public EventDetail GetDefaultById(int id)
        {
            return _context.EventDetails.Find(id);
        }

        public IList<EventDetail> GetDefaults(Expression<Func<EventDetail, bool>> expression)
        {
            return _context.EventDetails.Where(expression).ToList();
        }

        public void Update(EventDetail Entity)
        {
            _context.EventDetails.Update(Entity);
            _context.SaveChanges();
        }
    }
}
