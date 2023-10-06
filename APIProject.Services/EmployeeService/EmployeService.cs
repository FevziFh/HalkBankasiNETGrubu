using APIProject.Entities;
using APIProject.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIProject.Services.EmployeeService
{
    public class EmployeService
    {
        private readonly EmployeeRepo repo;

        public EmployeService(EmployeeRepo repo)
        {
            this.repo = repo;
        }

        public void AddEmployee(Employee employee)
        {
            repo.AddEmployee(employee);
        }
        public void DeleteEmployee(Employee employee)
        {
            repo.DeleteEmployee(employee.Id);
        }
        public Task<Employee> GetEmployee(int id)
        {
            return repo.GetEmployee(id);
        }
        public List<Employee> GetEmployees()
        {
            return (List<Employee>)repo.GetAllEmployees();
        }
        public void UpdateEmployee(Employee employee)
        {
            repo.UpdateEmployee(employee);
        }
    }
}
