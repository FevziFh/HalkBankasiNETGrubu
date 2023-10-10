using APIProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIProject.Services.EmployeeService
{
    public interface IEmployeeService
    {
        public void AddEmployee(Employee employee);
        public void DeleteEmployee(int id);
        public Task<Employee> GetEmployeeById(int id);
        public List<Employee> GetEmployees();
        public List<Employee> GetEmployeesByDepartment(string department);
        public void UpdateEmployee(Employee employee);
        List<Employee> GetEmployeesWhere(IEnumerable<Employee> source, Func<Employee, bool> WhereExp);
    }
}
