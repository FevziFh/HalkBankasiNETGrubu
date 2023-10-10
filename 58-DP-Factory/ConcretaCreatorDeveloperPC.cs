using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _58_DP_Factory
{
    public class ConcretaCreatorDeveloperPC : CreatorComputer
    {
        private readonly string ram;
        private readonly string hdd;
        private readonly string cpu;

        public ConcretaCreatorDeveloperPC(string ram,string hdd,string cpu)
        {
            this.ram = ram;
            this.hdd = hdd;
            this.cpu = cpu;
        }
        public override string GetCPU()
        {
            return ram;
        }

        public override string GetHDD()
        {
            return hdd;
        }

        public override string GetRam()
        {
            return cpu;
        }
    }
}
