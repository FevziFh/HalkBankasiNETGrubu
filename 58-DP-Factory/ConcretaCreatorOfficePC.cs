using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace _58_DP_Factory
{
    public class ConcretaCreatorOfficePC : CreatorComputer
    {
        private readonly string ram;
        private readonly string hdd;
        private readonly string cpu;

        public ConcretaCreatorOfficePC(string ram, string hdd, string cpu)
        {
            this.ram = ram;
            this.hdd = hdd;
            this.cpu = cpu;
        }
        public override string GetCPU()
        {
            return cpu;
        }

        public override string GetHDD()
        {
            return hdd;
        }

        public override string GetRam()
        {
            return ram;
        }
    }
}
