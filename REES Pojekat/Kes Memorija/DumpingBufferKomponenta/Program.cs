using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Common;
using System.Diagnostics.CodeAnalysis;

namespace DumpingBufferKomponenta
{
    public class Program
    {

        [ExcludeFromCodeCoverage]
        static void Main(string[] args)
        {
            
            try
            {
                ServiceHost server = new ServiceHost(typeof(DumpingBuffer));
                server.AddServiceEndpoint(typeof(Common.IDumpingBuffer), new NetTcpBinding(), new Uri("net.tcp://localhost:4000/IDumpingBuffer"));
                server.Open();
                Console.WriteLine("Server uspjesno podignut!");
            }
            catch (Exception)
            {

                Console.WriteLine("Server nije uspio da se podigne!");
            }



            Console.ReadLine();
        }

     
    }
}
