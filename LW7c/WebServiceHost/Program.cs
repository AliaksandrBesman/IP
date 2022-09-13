using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF_Service;
using System.ServiceModel;

namespace WebServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using(ServiceHost host = new ServiceHost(typeof(TS)))
            {
                host.Open();
                Console.ReadKey();
                host.Close();
            }

        }
    }
}
