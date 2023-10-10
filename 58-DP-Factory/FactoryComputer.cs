using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _58_DP_Factory
{
    public class FactoryComputer
    {
        public static CreatorComputer FactoryMetod(ModelPC model,string ram,string cpu,string hdd)
        {
            if (model == ModelPC.DeveloperPC)
            {
                return new ConcretaCreatorDeveloperPC(ram, cpu, hdd);
            }
            else if (model == ModelPC.GamePC)
            {
                return new ConcretaCreatorGamePC(ram, cpu, hdd);
            }
            else if (model == ModelPC.OfficePC)
            {
                return new ConcretaCreatorOfficePC(ram, cpu, hdd);
            }
            else
                return null;
        }
    }
}
