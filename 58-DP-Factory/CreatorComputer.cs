using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _58_DP_Factory
{
    public abstract class CreatorComputer
    {
        public abstract string GetRam();
        public abstract string GetHDD();
        public abstract string GetCPU();
        public override string ToString()
        {
            return "RAM: " + GetRam() + "HDD: " + GetHDD() + "CPU: " + GetCPU();
        }
    }
}
