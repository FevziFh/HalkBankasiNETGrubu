using EventProject.Core.Entities;
using EventProject.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Service.EventDetailService
{
    public class EventDetailService : IEventDetailService
    {
        private readonly IEventDetailRepo _repo;
        public EventDetailService(IEventDetailRepo repo)
        {
            _repo = repo;
        }
        public bool Any(Expression<Func<EventDetail, bool>> expression)
        {
            return _repo.Any(expression);
        }

        public void Create(EventDetail Entity)
        {
            if (Entity.EventDetailId > 0) 
            {
                _repo.Create(Entity);
            }
            else
            {
                throw new Exception("Böyle bir ID yok");
            }
        }

        public void Delete(EventDetail Entity)
        {
            _repo.Delete(Entity);
        }

        public EventDetail GetDefault(Expression<Func<EventDetail, bool>> expression)
        {
            return _repo.GetDefault(expression);
        }

        public EventDetail GetDefaultById(int id)
        {
            return _repo.GetDefaultById(id);
        }

        public IList<EventDetail> GetDefaults(Expression<Func<EventDetail, bool>> expression)
        {
            return _repo.GetDefaults(expression);
        }

        public void Update(EventDetail Entity)
        {
            _repo.Update(Entity);
        }
    }
}
