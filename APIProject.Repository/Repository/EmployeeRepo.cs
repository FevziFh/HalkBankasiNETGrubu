using APIProject.Entities;
using APIProject.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIProject.Repository.Repository
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly AppDbContext _context;

        public EmployeeRepo(AppDbContext context)
        {
            _context = context;
        }

        public Employee AddEmployee(Employee employee)
        {
            _context.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public void DeleteEmployee(int id)
        {
            _context.Remove(GetAllEmployees().FirstOrDefault(x=>x.Id==id));
            _context.SaveChanges();
        }

        public IList<Employee> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }

        public Task<Employee> GetEmployee(int id)
        {
            return _context.Employees.FirstOrDefaultAsync(x=>x.Id==id);
        }

        public Employee UpdateEmployee(Employee employee)
        {
            _context.Add(employee);
            _context.SaveChanges();
            return employee;
        }
    }
}
