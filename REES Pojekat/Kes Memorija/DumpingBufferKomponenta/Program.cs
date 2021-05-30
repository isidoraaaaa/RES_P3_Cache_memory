using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Common;
namespace DumpingBufferKomponenta
{
    public class Program
    {
        int brojacKonverzija = 0; // sluzi za generisanje jedinstvenog Id
        bool dveRazliciteVrednostiUOkviruIstogDataseta = false;
        int brojacUkupnoPrimljenihPodatakaOdWritera = 0;
        bool update = false;
        bool add = false;
        bool remove = false;
        DeltaCD dc = new DeltaCD();

        string kodAnalog = "CODE_ANALOG";
        string kodDigital = "CODE_DIGITAL";
        string kodCustom = "CODE_CUSTOM";
        string kodLimitset = "CODE_LIMITSET";
        string kodSinglenoe = "CODE_SINGLENOE";
        string kodMultiplenode = "CODE_MULTIPLENODE";
        string kodConsumer = "CODE_CONSUMER";
        string kodSource = "CODE_SOURCE";
        string kodMotion = "CODE_MOTION";
        string kodSensor = "CODE_SENSOR";

       
        static void Main(string[] args)
        {
            IHistorical kanal;
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

                 kanal = factory.CreateChannel();

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
