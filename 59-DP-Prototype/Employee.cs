using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _59_DP_Prototype
{
    public class Employee : ICloneable
    {
        private List<string> empList;

        private Employee(List<string> empList)
        {
            this.empList = empList;
        }

        public Employee()
        {
            empList = new List<string>();
        }
        public void LoadData()
        {
            empList.Add("Fatih");
            empList.Add("Naime");
            empList.Add("Furkan");
            empList.Add("Fevzi");
            empList.Add("Sefa");
        }
        public List<string> GetEmpList()
        {
            return empList;
        }
        public object Clone()
        {
            List<string> list = new List<string>();
            foreach (string item in GetEmpList())
            {
                list.Add(item);
            }
            return new Employee(list);
        }
    }
}
