using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReaderKomponenta
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChannelFactory<IHistorical> factory = new ChannelFactory<IHistorical>(
                new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:8000/IHistorical")
                );

                IHistorical kanal = factory.CreateChannel();

                Console.WriteLine("Reader uspjesno povezan sa Historicalom!");
                List<double> opcija1 = new List<double>();
                List<double> opcija2 = new List<double>();
                List<double> opcija3 = new List<double>();
 
 
                Console.WriteLine("Izaberite kriterijum ispisa podataka");
                while (true)
                {
                    Console.WriteLine("********MENI********");
                    Console.WriteLine("1.Kod");
                    Console.WriteLine("2.DataSet");
                    Console.WriteLine("3.Period upisa");
                    string  meniString = Console.ReadLine();
                    
                   
                    if (Int32.TryParse(meniString,out int meni))
                    {
                        meni = Convert.ToInt32(meniString);
                        switch (meni)
                        {
                            case 1:
                                Console.WriteLine("Unesi kod:");
                                string kod = Console.ReadLine();
                                if (kod.ToUpper().Trim() == "CODE_ANALOG" || kod.ToUpper().Trim() == "CODE_DIGITAL" ||
                                    kod.ToUpper().Trim() == "CODE_CUSTOM" || kod.ToUpper().Trim() == "CODE_LIMITSET" ||
                                    kod.ToUpper().Trim() == "CODE_SINGLENODE" || kod.ToUpper().Trim() == "CODE_MULTIPLENODE" ||
                                    kod.ToUpper().Trim() == "CODE_CONSUMER" || kod.ToUpper().Trim() == "CODE_SOURCE" ||
                                    kod.ToUpper().Trim() == "CODE_MOTION" || kod.ToUpper().Trim() == "CODE_SENSOR")
                                {
                                    opcija1 = kanal.CitanjePodatakaIzBaze(kod);
                                    if (opcija1.Count > 0)
                                    {
                                        foreach (double item in opcija1)
                                        {
                                            Console.WriteLine($"{kod.ToUpper()}, vrijednost = {item}");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Trenutno nema tog koda u bazi, pokusajte kasnije!");
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("Unijeli ste nepostojeci kod!");
                                }
                                break;
                            case 2:
                                //treba da prikaze samo dataset ukoliko ga ima
                                Console.WriteLine("Izaberite dataSet za prikaz:");
                                Console.WriteLine("1.DataSet1\n2.DataSet 2\n3.DataSet 3\n4.DataSet 4\n5.DataSet 5");
                                Console.WriteLine("\n=>");
                                string brojString = Console.ReadLine();
                                if(Int32.TryParse(brojString,out int broj))
                                {
                                    broj = Convert.ToInt32(brojString);
                                    switch (broj)
                                    {
                                        case 1:
                                            opcija2 = kanal.CitanjePodatakaIzBaze("CODE_ANALOG");
                                            if (opcija2.Count > 0)
                                            {
                                                foreach (double item in opcija2)
                                                {
                                                    Console.WriteLine($"CODE_ANALOG, vrijednost = {item}");
                                                }
                                            }
                                            opcija2.Clear();
                                            opcija2 = kanal.CitanjePodatakaIzBaze("CODE_DIGITAL");
                                            if (opcija2.Count > 0)
                                            {
                                                foreach (double item in opcija2)
                                                {
                                                    Console.WriteLine($"CODE_DIGITAL, vrijednost = {item}");
                                                }
                                            }

                                            break;
                                        case 2:
                                            opcija2 = kanal.CitanjePodatakaIzBaze("CODE_CUSTOM");
                                            if (opcija2.Count > 0)
                                            {
                                                foreach (double item in opcija2)
                                                {
                                                    Console.WriteLine($"CODE_CUSTOM, vrijednost = {item}");
                                                }
                                            }
                                            opcija2.Clear();
                                            opcija2 = kanal.CitanjePodatakaIzBaze("CODE_LIMITSET");
                                            if (opcija2.Count > 0)
                                            {
                                                foreach (double item in opcija2)
                                                {
                                                    Console.WriteLine($"CODE_LIMITSET, vrijednost = {item}");
                                                }
                                            }
                                            break;
                                        case 3:
                                            opcija2 = kanal.CitanjePodatakaIzBaze("CODE_SINGLENOE");
                                            if (opcija2.Count > 0)
                                            {
                                                foreach (double item in opcija2)
                                                {
                                                    Console.WriteLine($"CODE_SINGLENOE, vrijednost = {item}");
                                                }
                                            }
                                            opcija2.Clear();
                                            opcija2 = kanal.CitanjePodatakaIzBaze("CODE_MULTIPLENODE");
                                            if (opcija2.Count > 0)
                                            {
                                                foreach (double item in opcija2)
                                                {
                                                    Console.WriteLine($"CODE_MULTIPLENODE, vrijednost = {item}");
                                                }
                                            }
                                            break;
                                        case 4:
                                            opcija2 = kanal.CitanjePodatakaIzBaze("CODE_CONSUMER");
                                            if (opcija2.Count > 0)
                                            {
                                                foreach (double item in opcija2)
                                                {
                                                    Console.WriteLine($"CODE_CONSUMER, vrijednost = {item}");
                                                }
                                            }
                                            opcija2.Clear();
                                            opcija2 = kanal.CitanjePodatakaIzBaze("CODE_SOURCE");
                                            if (opcija2.Count > 0)
                                            {
                                                foreach (double item in opcija2)
                                                {
                                                    Console.WriteLine($"CODE_SOURCE, vrijednost = {item}");
                                                }
                                            }
                                            break;
                                        case 5:
                                            opcija2 = kanal.CitanjePodatakaIzBaze("CODE_MOTION");
                                            if (opcija2.Count > 0)
                                            {
                                                foreach (double item in opcija2)
                                                {
                                                    Console.WriteLine($"CODE_MOTION, vrijednost = {item}");
                                                }
                                            }
                                            opcija2.Clear();
                                            opcija2 = kanal.CitanjePodatakaIzBaze("CODE_SENSOR");
                                            if (opcija2.Count > 0)
                                            {
                                                foreach (double item in opcija2)
                                                {
                                                    Console.WriteLine($"CODE_SENSOR, vrijednost = {item}");
                                                }
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Morate da unesete broj a ne slovo ili neki karakter!");
                                }
                                   
                                break;
                            case 3:
                                //prikazuje one kodove koji odgovaraju vremenskom intervalu upisa koji je unesen
                                Console.WriteLine("Izaberite u kom vremenskom intervalu zelite da prikazete upisane podatke. Interval morate uneti u formatu yyyy-dd-MM");
                                string period = Console.ReadLine(); //mora biti u formatu yyyy-MM-dd
                                string []dio = period.Split(' ');
                                Console.WriteLine("Unesite kod:");
                                string kood = Console.ReadLine();
                                switch (kood.ToUpper())
                                {
                                    case "CODE_ANALOG":
                                       opcija3 = kanal.citanjeZaDatum(kood, "dataset_1", dio[0], dio[1]);
                                        if (opcija3.Count > 0)
                                        {
                                            Console.WriteLine("Kodovi koji zadovoljavaju kriterijum:");
                                            foreach (var item in opcija3)
                                            {
                                                Console.WriteLine($"CODE_ANALOG, vrijednost = {item}");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Trenutno nema tog koda u bazi!");
                                        }
                                        break;
                                    case "CODE_DIGITAL":
                                        opcija3 = kanal.citanjeZaDatum(kood, "dataset_1", dio[0], dio[1]);
                                        if (opcija3.Count > 0)
                                        {
                                            Console.WriteLine("Kodovi koji zadovoljavaju kriterijum:");
                                            foreach (var item in opcija3)
                                            {
                                                Console.WriteLine($"CODE_DIGITAL, vrijednost = {item}");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Trenutno nema tog koda u bazi!");
                                        }
                                        break;
                                    case "CODE_CUSTOM":
                                        opcija3 = kanal.citanjeZaDatum(kood, "dataset_2", dio[0], dio[1]);
                                        if (opcija3.Count > 0)
                                        {
                                            Console.WriteLine("Kodovi koji zadovoljavaju kriterijum:");
                                            foreach (var item in opcija3)
                                            {
                                                Console.WriteLine($"CODE_CUSTOM, vrijednost = {item}");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Trenutno nema tog koda u bazi!");
                                        }
                                        break;
                                    case "CODE_LIMITSET":
                                        opcija3 = kanal.citanjeZaDatum(kood, "dataset_2", dio[0], dio[1]);
                                        if (opcija3.Count > 0)
                                        {
                                            Console.WriteLine("Kodovi koji zadovoljavaju kriterijum:");
                                            foreach (var item in opcija3)
                                            {
                                                Console.WriteLine($"CODE_LIMITSET, vrijednost = {item}");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Trenutno nema tog koda u bazi!");
                                        }
                                        break;
                                    case "CODE_SINGLENODE":
                                        opcija3 = kanal.citanjeZaDatum(kood, "dataset_3", dio[0], dio[1]);
                                     
                                        if (opcija3.Count > 0)
                                        {
                                            Console.WriteLine("Kodovi koji zadovoljavaju kriterijum:");
                                            foreach (var item in opcija3)
                                            {
                                                Console.WriteLine($"CODE_SINGLENODE, vrijednost = {item}");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Trenutno nema tog koda u bazi!");
                                        }
                                        break;
                                    case "CODE_MULTIPLENODE":
                                        opcija3 = kanal.citanjeZaDatum(kood, "dataset_3", dio[0], dio[1]);
                                        if (opcija3.Count > 0)
                                        {
                                            Console.WriteLine("Kodovi koji zadovoljavaju kriterijum:");
                                            foreach (var item in opcija3)
                                            {
                                                Console.WriteLine($"CODE_MULTIPLENODE, vrijednost = {item}");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Trenutno nema tog koda u bazi!");
                                        }
                                        break;
                                    case "CODE_CONSUMER":
                                        opcija3 = kanal.citanjeZaDatum(kood, "dataset_4", dio[0], dio[1]);
                                        if (opcija3.Count > 0)
                                        {
                                            Console.WriteLine("Kodovi koji zadovoljavaju kriterijum:");
                                            foreach (var item in opcija3)
                                            {
                                                Console.WriteLine($"CODE_CONSUMER, vrijednost = {item}");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Trenutno nema tog koda u bazi!");
                                        }
                                        break;
                                    case "CODE_SOURCE":
                                        opcija3 = kanal.citanjeZaDatum(kood, "dataset_4", dio[0], dio[1]);
                                        if (opcija3.Count > 0)
                                        {
                                            Console.WriteLine("Kodovi koji zadovoljavaju kriterijum:");
                                            foreach (var item in opcija3)
                                            {
                                                Console.WriteLine($"CODE_SOURCE, vrijednost = {item}");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Trenutno nema tog koda u bazi!");
                                        }
                                        break;
                                    case "CODE_MOTION":
                                        opcija3 = kanal.citanjeZaDatum(kood, "dataset_5", dio[0], dio[1]);
                                        if (opcija3.Count > 0)
                                        {
                                            Console.WriteLine("Kodovi koji zadovoljavaju kriterijum:");
                                            foreach (var item in opcija3)
                                            {
                                                Console.WriteLine($"CODE_MOTION, vrijednost = {item}");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Trenutno nema tog koda u bazi!");
                                        }
                                        break;
                                    case "CODE_SENSOR":
                                        opcija3 = kanal.citanjeZaDatum(kood, "dataset_5", dio[0], dio[1]);
                                        if (opcija3.Count > 0)
                                        {
                                            Console.WriteLine("Kodovi koji zadovoljavaju kriterijum:");
                                            foreach (var item in opcija3)
                                            {
                                                Console.WriteLine($"CODE_SENSOR, vrijednost = {item}");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Trenutno nema tog koda u bazi!");
                                        }
                                        break;
                                    default:
                                        Console.WriteLine("Unijeli ste nepostojeci kod!");
                                        break;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Morate da unesete broj a ne slovo ili neki karakter!");
                    }
                    

                    Console.WriteLine("----------------------");
                  
                }
               
               

                 
            }
            catch (Exception e)
            {
                Console.WriteLine("Konekcija nije uspjesno uspostavljena sa serverom.Sacekaj da se prvo podigne server pa probaj ponovo.");
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
            Console.ReadLine();
        }
    }
}
