using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Common;
using System.Threading;

namespace WriterKomponenta
{
    class Program
    {
        static void Main(string[] args)
        {
            int brojac = 0;
            ConsoleKeyInfo k = new ConsoleKeyInfo();
            try
            {
               ChannelFactory<IDumpingBuffer> factory = new ChannelFactory<IDumpingBuffer>(
               new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:4000/IDumpingBuffer")
               );

                IDumpingBuffer kanal = factory.CreateChannel();
                Console.WriteLine("Uspjesno uspostavljena veza sa serverom");
                // kanal.automatskiUDumpingBuffer();
                //kanal.manuelnoUDumpingBuffer("analogni kod 3");
                while (true)
                {
                    brojac++;
                    Thread.Sleep(1000); 
                    if (brojac != 2)
                    {
                        //radimo manuelni upis podataka
                        Console.WriteLine("Unesite signal i vrijednost:");
                        
                     
                        string signal = Console.ReadLine();

                        //unos mora biti tipa "code = vrijednost"
                        string[] dio = signal.Split('=');
                        string kod = dio[0].Trim();
                        double vrijednost = Convert.ToDouble(dio[1].Trim());
                        DateTime datum = DateTime.Now;
                        Podatak p = new Podatak(kod, vrijednost, datum);
                        kanal.manuelnoUDumpingBuffer(p);
                    }
                    else
                    {
                        //salji automatski
                        kanal.automatskiUDumpingBuffer();
                        brojac = 0;
                    }
                }
              

            }
            catch (Exception  )
            {

                Console.WriteLine("Konekcija nije uspjesno uspostavljena sa serverom.Sacekaj da se prvo podigne server pa probaj ponovo.");
                Console.ReadLine();
            }

           
           
          
            Console.ReadLine();
        }
    }
}
