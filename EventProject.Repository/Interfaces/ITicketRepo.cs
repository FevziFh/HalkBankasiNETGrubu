using EventProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Repository.Interfaces
{
    public interface ITicketRepo : IBaseRepo<Ticket>
    {
        //Eventeki kişi sayısı
        int GetAttendCount(int eventId);
        //Eventeki kişiler
        List<Customer> GetAttends(int eventId);

        int GetCustomerOfEventCount(int customerId);
        List<Event> GetCustomerOfEvents(int customerId);
    }
}
