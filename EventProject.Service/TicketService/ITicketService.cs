using EventProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TicketProject.Service.TicketService
{
    public interface ITicketService
    {
        void Create(Ticket Entity);
        void Update(Ticket Entity);
        void Delete(Ticket Entity);
        bool Any(Expression<Func<Ticket, bool>> expression);
        Ticket GetDefault(Expression<Func<Ticket, bool>> expression);
        Ticket GetDefaultById(int id);
        IList<Ticket> GetDefaults(Expression<Func<Ticket, bool>> expression);
        //Eventeki kişi sayısı
        int GetAttendCount(int eventId);
        //Eventeki kişiler
        List<Customer> GetAttends(int eventId);

        int GetCustomerOfEventCount(int customerId);
        List<Event> GetCustomerOfEvents(int customerId);
    }
}
