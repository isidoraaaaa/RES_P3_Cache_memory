using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Common;
namespace DumpingBufferKomponenta
{
    class Program
    {
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


            try
            {
                ChannelFactory<IHistorical> factory = new ChannelFactory<IHistorical>(
                new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:8000/IHistorical")
                );

                IHistorical kanal = factory.CreateChannel();

                Console.WriteLine("Uspjesno uspostavljena veza sa Historicalom");
              
            }
            catch (Exception)
            {
                Console.WriteLine("Neuspesno povezivanje sa serverom");
                Console.ReadLine();
            }

            Console.ReadLine();
        }
    }
}
