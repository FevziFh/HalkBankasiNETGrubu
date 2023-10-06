using EventProject.Core.Entities;
using EventProject.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TicketProject.Service.TicketService;

namespace EventProject.Service.TicketService
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepo _repo;
        public TicketService(ITicketRepo repo)
        {
            _repo = repo;
        }
        public bool Any(Expression<Func<Ticket, bool>> expression)
        {
            return _repo.Any(expression);
        }

        public void Create(Ticket Entity)
        {
            if (Entity.Customer != null)
            {
                if (Entity.Event != null)
                {
                    if (Entity.Customer.CustomerAge >= Entity.Event.EventAgeControl)
                    {
                        _repo.Create(Entity);
                    }
                    else
                        throw new Exception("Yaşınız tutmuyor");
                }
                else
                    throw new Exception("Event seçiniz.");
            }
            else
                throw new Exception("Customer seçiniz.");
        }

        public void Delete(Ticket Entity)
        {
            _repo.Delete(Entity);
        }

        public int GetAttendCount(int eventId)
        {
            return _repo.GetAttendCount(eventId);
        }

        public List<Customer> GetAttends(int eventId)
        {
            return _repo.GetAttends(eventId);
        }

        public int GetCustomerOfEventCount(int customerId)
        {
            return _repo.GetCustomerOfEventCount(customerId);
        }

        public List<Event> GetCustomerOfEvents(int customerId)
        {
            return _repo.GetCustomerOfEvents(customerId);
        }

        public Ticket GetDefault(Expression<Func<Ticket, bool>> expression)
        {
            return _repo.GetDefault(expression);
        }

        public Ticket GetDefaultById(int id)
        {
            return _repo.GetDefaultById(id);
        }

        public IList<Ticket> GetDefaults(Expression<Func<Ticket, bool>> expression)
        {
            return _repo.GetDefaults(expression);
        }

        public void Update(Ticket Entity)
        {
            _repo.Update(Entity);
        }
    }
}
