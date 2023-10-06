using EventProject.Core.Entities;
using EventProject.Core.Enums;
using EventProject.Repository.Concreate;
using EventProject.Repository.Contexts;
using EventProject.Repository.Interfaces;
using EventProject.Service.CategoryService;
using EventProject.Service.CustomerService;
using EventProject.Service.EventDetailService;
using EventProject.Service.EventService;
using EventProject.Service.TicketService;
using TicketProject.Service.TicketService;

namespace EventProject.ConsoleApp
{
    internal class Program
    {
        private static AppDbContext appDbContext;

        private static ICategoryService categoryService;
        private static ICategoryRepo categoryRepo;

        private static IEventRepo eventRepo;
        private static IEventService eventService;

        private static IEventDetailRepo eventDetailRepo;
        private static IEventDetailService eventDetailService;

        private static ICustomerRepo customerRepo;
        private static ICustomerService customerService;

        private static ITicketRepo ticketRepo;
        private static ITicketService ticketService;
        static void Main(string[] args)
        {
            appDbContext = new();
            categoryRepo = new CategoryRepo(appDbContext);
            categoryService = new CategoryService(categoryRepo);

            eventRepo = new EventRepo(appDbContext);
            eventService = new EventService(eventRepo);

            eventDetailRepo = new EventDetailRepo(appDbContext);
            eventDetailService = new EventDetailService(eventDetailRepo);

            customerRepo = new CustomerRepo(appDbContext);
            customerService = new CustomerService(customerRepo);

            ticketRepo= new TicketRepo(appDbContext);
            ticketService = new TicketService(ticketRepo);
            //CategoryAdd();
            //CategoryList();
            //EventAdd();
            //EventGets();
            //EventDetailAdd();
            //CustomerAdd();
            CustomerList();
            BiletAl();
            Console.WriteLine("Başarılı");
        }
        #region Kategori işlemler
        public static void CategoryAdd()
        {
            categoryService.Create(new Category
            {
                CategoryName = "Test",
            });
        }
        public static void CategoryList()
        {
            var category = categoryService.GetDefaults(x => x.Status != Status.Passive);
            foreach (var item in category)
            {
                Console.WriteLine($"Kategori Id:{item.Id} Kategori Name: {item.CategoryName}");
            }
        }
        public static void CategoryUpdate()
        {
            CategoryList();
            Console.WriteLine("Lütfen güncellemek istediğiniz kategorini ıdsini giriniz.");
            int catID = int.Parse(Console.ReadLine());
        }
        #endregion
        #region Event işlemler
        public static void EventAdd()
        {
            CategoryList();
            Console.WriteLine("istediğiniz kategoriyi seçiniz.");
            int catId = int.Parse(Console.ReadLine());
            var event1 = new Event()
            {
                CategoryId = catId,
                EventName = "tarkan",
                EventAgeControl = 15,
                EventAttends = 500,
                EventFinishDate = DateTime.Now.AddDays(5),
                EventStartDate = DateTime.Now.AddDays(1),
                EventLocation = "Yozgat",
                EventPrice = 1000
            };
            eventService.Create(event1);
        }
        public static void EventGets()
        {
            //var events = eventService.GetDefaults(x => x.Status != Status.Passive);
            var events = eventService.GetEventsOrderByPriceASC();
            foreach (var item in events)
            {
                Console.WriteLine($"Id: {item.Id}, Name: {item.EventName}, Fiyat:{item.EventPrice}, Başlangıç: {item.EventStartDate}, Bitiş Tarihi: {item.EventFinishDate}, Yaş Sınırı: {item.EventAgeControl}");
            }
        }
        #endregion
        #region EventDetay işlemleri
        public static void EventDetailAdd()
        {
            var eventDetail = new EventDetail()
            {
                EventDetailId = 1,
                EventMail = "mahmut@mail.com",
                EventPhone = "555 555 55 55",
            };
            eventDetailService.Create(eventDetail);
        }
        #endregion
        #region Customer işlemleri
        public static void CustomerAdd()
        {
            var customer = new Customer()
            {
                CustomerName = "Mehmet Ali",
                CustomerAge = 24,
                CustomerPhone = "555"
            };
            customerService.Create(customer);
        }
        public static void CustomerList()
        {
            var customers = customerService.GetDefaults(x => x.Status != Status.Passive);
            foreach (var item in customers)
            {
                Console.WriteLine($"Adı: {item.CustomerName}, Yaş:{item.CustomerAge}");
            }
        }
        #endregion
        #region Ticket İşlemleri
        public static void BiletAl()
        {
            Console.WriteLine("Müşteri Id giriniz: ");
            int customerId=int.Parse(Console.ReadLine());
            Console.WriteLine("Event Id: ");
            int eventId = int.Parse(Console.ReadLine());
            var customer = customerService.GetDefaultById(customerId);
            var event1 = eventService.GetDefaultById(eventId);

            var ticket = new Ticket()
            {
                Customer = customer,
                CustomerId = customerId,
                Event = event1,
                EventId = eventId
            };
            ticketService.Create(ticket);
        }
        public static void MusteriKonserbilgileri()
        {
            var konser = ticketService.GetCustomerOfEvents(2);
            foreach (var item in konser)
            {
                Console.WriteLine($"Konser Name: {item.EventName}");
            }
        }
        #endregion
    }
}