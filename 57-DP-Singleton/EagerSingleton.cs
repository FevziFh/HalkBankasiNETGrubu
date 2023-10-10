using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _57_DP_Singleton
{
    internal class EagerSingleton
    {
        public static EagerSingleton instance;

        private static readonly object lock_obj = new object();
        private EagerSingleton() 
        {
        }
        //Lazy Singleton ikili kontrol
        public static EagerSingleton GetInstance()
        {
            {
                lock (lock_obj)
                {
                    if (instance is null)
                    {
                        instance = new EagerSingleton();
                    }
                    return instance;
                }
            }           
        }
    }
}
