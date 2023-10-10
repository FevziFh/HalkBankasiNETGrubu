using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _56_SOLIDPrenciples._02_OpenClosed.BadImplementation
{
    internal class EmployeeSalary
    {
        public double CalculateSalary(Employee employee,int day,double bonus)
        {
            double salary = 0;
            if (employee.EmployeeType == "Kadrolu")
            {
                salary = (employee.DailyWages * day) + bonus;
            }
            else if (employee.EmployeeType == "Sozlesmeli")
            {
                salary = (employee.DailyWages * day);
            }
            //else if(employee.EmployeeType == "Stajyer")
            //{

            //}

            return salary;
        }
    }
}
