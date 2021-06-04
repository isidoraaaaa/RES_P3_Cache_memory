using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Common;
using System.Diagnostics.CodeAnalysis;

namespace Historical
{
    class Program
    {
        [ExcludeFromCodeCoverage]
        static void Main(string[] args)
        {
            try
            {
                ServiceHost server = new ServiceHost(typeof(Historical));
                server.AddServiceEndpoint(typeof(IHistorical), new NetTcpBinding(), new Uri("net.tcp://localhost:8000/IHistorical"));
                server.Open();
                Console.WriteLine("Historical uspesno podignut");
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}
