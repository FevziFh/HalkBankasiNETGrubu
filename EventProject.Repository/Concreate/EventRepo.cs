using EventProject.Core.Entities;
using EventProject.Repository.Contexts;
using EventProject.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Repository.Concreate
{
    public class EventRepo : BaseRepo<Event>, IEventRepo
    {
        private readonly AppDbContext _context;
        public EventRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IList<Event> GetEventsByDate(DateTime startDate, DateTime endDate)
        {
            return _context.Events.Where(e => (e.EventStartDate >= startDate && e.EventStartDate <= endDate) || (e.EventFinishDate<=endDate && e.EventFinishDate >= startDate)).ToList();
        }

        public IList<Event> GetEventsByLocation(string location)
        {
            return _context.Events.Where(e => e.EventLocation.Contains(location)).ToList();
        }

        public IList<Event> GetEventsOrderByPriceASC()
        {
            return _context.Events.OrderBy(e => e.EventPrice).ToList();
        }

        public IList<Event> GetEventsOrderByPriceDESC()
        {
            return _context.Events.OrderByDescending(e => e.EventPrice).ToList();
        }
    }
}
