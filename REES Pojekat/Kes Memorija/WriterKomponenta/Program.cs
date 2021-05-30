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
         //logika za unos sa konzole
        public static void manuelno(IDumpingBuffer kanal)
        {
            while(true)
            {
                //radimo manuelni upis podataka
                Console.WriteLine("Unesite signal i vrijednost:");
                string signal = Console.ReadLine();
                //unos mora biti tipa "code = vrijednost"
                string[] dio = signal.Split('=');
                string kod = dio[0].Trim();
                double vrijednost = 0;


                switch (kod.ToUpper())
                {
                    case "CODE_ANALOG":
                        kod = "CODE_ANALOG";
                        break;
                    case "CODE_DIGITAL":
                        kod = "CODE_DIGITAL";
                        break;
                    case "CODE_CUSTOM":
                        kod = "CODE_CUSTOM";
                        break;
                    case "CODE_LIMITSET":
                        kod = "CODE_LIMITSET";
                        break;
                    case "CODE_SINGLENOE":
                        kod = "CODE_SINGLENOE";
                        break;
                    case "CODE_MULTIPLENODE":
                        kod = "CODE_MULTIPLENODE";
                        break;
                    case "CODE_CONSUMER":
                        kod = "CODE_CONSUMER";
                        break;
                    case "CODE_SOURCE":
                        kod = "CODE_SOURCE";
                        break;
                    case "CODE_MOTION":
                        kod = "CODE_MOTION";
                        break;
                    case "CODE_SENSOR":
                        kod = "CODE_SENSOR";
                        break;
                    default:
                        kod = "Pogresan kod";
                        break;
                }

                if (kod != "Pogresan kod")
                {
                    if (double.TryParse(dio[1].Trim(), out vrijednost))
                    {
                        vrijednost = Convert.ToDouble(dio[1].Trim());
                        DateTime datum = DateTime.Now;
                        Podatak p = new Podatak(kod, vrijednost, datum);
                        kanal.manuelnoUDumpingBuffer(p);
                    }
                    else
                    {
                        Console.WriteLine("Niste unijeli validnu vrijednost!Vrijednost mora da bude neki broj!");
                    }

                }
                else
                {
                    Console.WriteLine("Pogresan kod");
                }
            }  
    }
       
        //automatski salje podatke svake 2 sekunde
        public static void automatsko(IDumpingBuffer kanal)
        {
            while (true)
            {
                kanal.automatskiUDumpingBuffer();
                Thread.Sleep(10000);
            }
        }
        static void Main(string[] args)
        {

            try
            {
               ChannelFactory<IDumpingBuffer> factory = new ChannelFactory<IDumpingBuffer>(
               new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:4000/IDumpingBuffer")
               );

                IDumpingBuffer kanal = factory.CreateChannel();
            
                Console.WriteLine("Uspjesno uspostavljena veza sa serverom");
                Thread t1 = new Thread(()=>automatsko(kanal));
                Thread t2 = new Thread(()=>manuelno(kanal));
                t1.Start();
                t2.Start();              
            }
            catch (Exception )
            {
                Console.WriteLine("Konekcija nije uspjesno uspostavljena sa serverom.Sacekaj da se prvo podigne server pa probaj ponovo.");
                Console.ReadLine();
            }
            Console.ReadLine();
        }
    }
}
