using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _56_SOLIDPrenciples._02_OpenClosed.GoodImplamentation
{
    internal interface IEmployeeSalary
    {
        public double CalculateSalary(Employee employee, int day);
    }
}
