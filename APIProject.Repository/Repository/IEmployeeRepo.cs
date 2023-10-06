using APIProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIProject.Repository.Repository
{
    public interface IEmployeeRepo
    {
        public Employee AddEmployee(Employee employee);
        public Task<Employee> GetEmployee(int id);
        public void DeleteEmployee(int id);
        public Employee UpdateEmployee(Employee employee);
        public IList<Employee> GetAllEmployees();
        //List<Employee> GetEmployeesWhered(IEnumerable<Employee> source,Func<Employee,bool> WhereExp);
    }
}
