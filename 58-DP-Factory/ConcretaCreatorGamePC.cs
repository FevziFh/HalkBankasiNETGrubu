using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _58_DP_Factory
{
    public class ConcretaCreatorGamePC : CreatorComputer
    {
        private string cpu;
        private string ram;
        private string hdd;

        public ConcretaCreatorGamePC(string cpu, string ram, string hdd)
        {
            this.cpu = cpu;
            this.ram = ram;
            this.hdd = hdd;
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
