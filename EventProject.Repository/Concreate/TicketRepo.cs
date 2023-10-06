using EventProject.Core.Entities;
using EventProject.Repository.Contexts;
using EventProject.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Repository.Concreate
{
    public class TicketRepo : BaseRepo<Ticket>, ITicketRepo
    {
        private readonly AppDbContext _context;
        public TicketRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public int GetAttendCount(int eventId)
        {
            return _context.Tickets.Count(t => t.EventId == eventId);
        }

        public List<Customer> GetAttends(int eventId)
        {
            //Yol-1
            //return _context.Tickets
            //    .Where(t => t.EventId == eventId)
            //    .Select(x => new Customer 
            //    { 
            //        Id = x.Customer.Id,
            //        CustomerName = x.Customer.CustomerName,
            //        CustomerAge = x.Customer.CustomerAge,
            //        CustomerPhone = x.Customer.CustomerPhone
            //    }).ToList();

            //return _context.Tickets
            //    .Where(x => x.EventId == eventId)
            //    .Join(_context.Customers,
            //    t => t.CustomerId,
            //    c => c.Id,
            //    (t, c) => new Customer
            //    {
            //        Id = c.Id,
            //        CustomerName = c.CustomerName,
            //        CustomerAge = c.CustomerAge,
            //        CustomerPhone = c.CustomerPhone
            //    }
            //    ).ToList();

            // Eager Loading
            return _context.Customers.Include(x => x.Tickets).Where(x => x.Tickets.Any(x => x.EventId.Equals(eventId))).ToList();
        }

        public int GetCustomerOfEventCount(int customerId)
        {
            return _context.Tickets.Count(t => t.CustomerId == customerId);
        }

        public List<Event> GetCustomerOfEvents(int customerId)
        {
            return _context.Tickets
                .Where(x => x.CustomerId == customerId)
                .Join(_context.Events,
                t => t.EventId,
                e => e.Id,
                (t, e) => new Event
                {
                    Id = e.Id,
                    EventName = e.EventName,
                    EventPrice = e.EventPrice,
                    EventAttends = e.EventAttends,
                    EventDetail = e.EventDetail,
                    EventAgeControl = e.EventAgeControl,
                    EventLocation = e.EventLocation,
                    EventFinishDate = e.EventFinishDate,
                    EventStartDate = e.EventStartDate,
                }).ToList();
        }
    }
}
