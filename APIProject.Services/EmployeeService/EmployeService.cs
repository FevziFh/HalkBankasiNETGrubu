using APIProject.Entities;
using APIProject.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIProject.Services.EmployeeService
{
    public class EmployeService : IEmployeeService
    {
        private readonly IEmployeeRepo repo;

        public EmployeService(IEmployeeRepo repo)
        {
            this.repo = repo;
        }

        public void AddEmployee(Employee employee)
        {
            if (employee is not null)
            {
                repo.AddEmployee(employee);
            }
            else
            {
                throw new Exception("Employe boş olamaz");
            }
            
        }
        public void DeleteEmployee(int id)
        {
            if (id is not 0)
            {
                repo.DeleteEmployee(id);
            }
            else
            {
                throw new Exception("Silme işleminde id parametresi boş olamaz");
            }
           
        }
        public Task<Employee> GetEmployeeById(int id)
        {
            if (id>0)
            {
                return repo.GetEmployeeById(id);
            }
            else
            {
                throw new Exception();
            }
            
        }
        public List<Employee> GetEmployees()
        {
            return (List<Employee>)repo.GetAllEmployees();
        }

        public List<Employee> GetEmployeesByDepartment(string department)
        {
            if (department is not null)
            {
                return repo.GetEmployeesByDeparment(department);
            }
            else
            {
                throw new Exception("Departman adi boş olamaz");
            }
            
        }

        public List<Employee> GetEmployeesWhere(IEnumerable<Employee> source, Func<Employee, bool> WhereExp)
        {
            var data = source.Where(WhereExp);
            return data.ToList();
        }

        public void UpdateEmployee(Employee employee)
        {
            repo.UpdateEmployee(employee);
        }
    }
}
