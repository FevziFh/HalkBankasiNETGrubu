﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _56_SOLIDPrenciples._04_InterfaceSegregation.BadImplementation
{
    internal class Bus : IVehicle
    {
        public void Acclereta()
        {
            //...
        }

        public void ApplyBrakes()
        {
            //...
        }

        public void Fly()
        {
            throw new NotImplementedException();
        }
    }
}
