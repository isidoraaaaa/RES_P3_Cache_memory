using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Singleton
    {
        private static IHistorical instance;

        public static IHistorical Instance()
        {
            if (instance == null)
            {
                try
                {
                    ChannelFactory<IHistorical> factory = new ChannelFactory<IHistorical>(
                    new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:8000/IHistorical")
                    );

                    instance = factory.CreateChannel();

                    Console.WriteLine("Uspjesno uspostavljena veza sa Historicalom");

                }
                catch (Exception)
                {
                    Console.WriteLine("Neuspesno povezivanje sa serverom");
                    Console.ReadLine();
                }
            }

            return instance;
        }
    }
}
