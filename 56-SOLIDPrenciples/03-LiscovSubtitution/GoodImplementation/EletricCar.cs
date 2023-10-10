using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _56_SOLIDPrenciples._03_LiscovSubtitution.GoodImplementation
{
    internal class EletricCar : Car
    {
        public override void Wheels()
        {
            //....
            base.Wheels();
        }
        public override void Run()
        {
            //....
            base.Run();
        }
    }
}
