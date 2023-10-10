using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _57_DP_Singleton
{
    internal class SampleSingleton
    {
        private static SampleSingleton sampleSingleton;
        private string data;

        protected SampleSingleton()
        {
            
        }
        public string Data
        {
            get { return data; }
            set { data = value; }
        }
        public static  SampleSingleton CreateSampleSingleton()
        {
            if (sampleSingleton is null)
            {
                sampleSingleton = new();
            }
            return sampleSingleton;
        }
    }
}
