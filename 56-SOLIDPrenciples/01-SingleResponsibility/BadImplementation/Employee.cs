using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _56_SOLIDPrenciples._01_SingleResponsibility.BadImplementation
{
    internal class Employee
    {
        //Fields
        private string fullName;
        private string dateOjJoin;
        private double salary;

        //Properties
        //...
        public string FullName { get => fullName; set => fullName = value; }
        public string DateOjJoin { get => dateOjJoin; set => dateOjJoin = value; }
        public double Salary { get => salary; set => salary = value; }
        public double CalculateEmployeSalary { get; set; }
        public double CalculateTaxSalary { get; set; }

        public void SaveEmployee()
        {
            //Kaydet
        }
        public void UpdateEmployee()
        {
            //Güncelleme
        }
    }
}
