using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
namespace DumpingBufferKomponenta
{
    public class DumpingBuffer : IDumpingBuffer
    {
        int brojac = 0;//koristimo da gledamo gledamo koji cemo string slati u funkciji za automatsko slanje

 #region lista kodova
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
 #endregion

        double vrijednost = 0.0;
        Random random = new Random();
        Podatak p = new Podatak();



        int brojacKonverzija = 0; // sluzi za generisanje jedinstvenog Id
        bool dveRazliciteVrednostiUOkviruIstogDataseta = false;
        int brojacUkupnoPrimljenihPodatakaOdWritera = 0;
        bool update = false;
        bool add = false;
        bool remove = false;
        DeltaCD dc = new DeltaCD();

        //funkcija za svaku vrijednsot brojaca ima odredjeno koji kod salje, dok je vrijednsot koju salje 
        //random broj koji se izracunava po odredjenom formuli
        public void automatskiUDumpingBuffer()
        {
            brojac++;
            switch (brojac)
            {
                case 1:
                    p.Kod = kodAnalog;
                    vrijednost = random.NextDouble()*(1000.0 - 0.1) + 0.1;
                    vrijednost = (double)System.Math.Round(vrijednost, 2);
                    p.Vrijednost = vrijednost;
                    p.Vrijeme = DateTime.Now;
                    Console.WriteLine(p);
                    KonverzijaPodatakaUCollectionDescription(p);
                    break;
                case 2:
                    p.Kod = kodDigital;       
                    vrijednost = random.NextDouble() * (1000.0 - 0.1) + 0.1;
                    vrijednost = (double)System.Math.Round(vrijednost, 2);
                    p.Vrijednost = vrijednost;
                    p.Vrijeme = DateTime.Now;
                    Console.WriteLine(p);
                    KonverzijaPodatakaUCollectionDescription(p);
                    break;
                case 3:
                    p.Kod = kodCustom;
                    vrijednost = random.NextDouble() * (1000.0 - 0.1) + 0.1;
                    vrijednost = (double)System.Math.Round(vrijednost, 2);
                    p.Vrijednost = vrijednost;
                    p.Vrijeme = DateTime.Now;
                    Console.WriteLine(p);
                    KonverzijaPodatakaUCollectionDescription(p);
                    break;
                case 4:
                    p.Kod = kodLimitset;
                    vrijednost = random.NextDouble() * (1000.0 - 0.1) + 0.1;
                    vrijednost = (double)System.Math.Round(vrijednost, 2);
                    p.Vrijednost = vrijednost;
                    p.Vrijeme = DateTime.Now;
                    Console.WriteLine(p);
                    KonverzijaPodatakaUCollectionDescription(p);
                    break;
                case 5:
                    p.Kod = kodSinglenoe;
                    vrijednost = random.NextDouble() * (1000.0 - 0.1) + 0.1;
                    vrijednost = (double)System.Math.Round(vrijednost, 2);
                    p.Vrijednost = vrijednost;
                    p.Vrijeme = DateTime.Now;
                    Console.WriteLine(p);
                    KonverzijaPodatakaUCollectionDescription(p);
                    break;
                case 6:
                    p.Kod = kodMultiplenode;
                    vrijednost = random.NextDouble() * (1000.0 - 0.1) + 0.1;
                    vrijednost = (double)System.Math.Round(vrijednost, 2);
                    p.Vrijednost = vrijednost;
                    p.Vrijeme = DateTime.Now;
                    Console.WriteLine(p);
                    KonverzijaPodatakaUCollectionDescription(p);
                    break;
                case 7:
                    p.Kod = kodConsumer;
                    vrijednost = random.NextDouble() * (1000.0 - 0.1) + 0.1;
                    vrijednost = (double)System.Math.Round(vrijednost, 2);
                    p.Vrijednost = vrijednost;
                    p.Vrijeme = DateTime.Now;
                    Console.WriteLine(p);
                    KonverzijaPodatakaUCollectionDescription(p);
                    break;
                case 8:
                    p.Kod = kodSource;
                    vrijednost = random.NextDouble() * (1000.0 - 0.1) + 0.1;
                    vrijednost = (double)System.Math.Round(vrijednost, 2);
                    p.Vrijednost = vrijednost;
                    p.Vrijeme = DateTime.Now;
                    Console.WriteLine(p);
                    KonverzijaPodatakaUCollectionDescription(p);
                    break;
                case 9:
                    p.Kod = kodMotion;
                    vrijednost = random.NextDouble() * (1000.0 - 0.1) + 0.1;
                    vrijednost = (double)System.Math.Round(vrijednost, 2);
                    p.Vrijednost = vrijednost;
                    p.Vrijeme = DateTime.Now;
                    Console.WriteLine(p);
                    KonverzijaPodatakaUCollectionDescription(p);
                    break;
                case 10:
                    p.Kod = kodSensor;
                    vrijednost = random.NextDouble() * (1000.0 - 0.1) + 0.1;
                    vrijednost = (double)System.Math.Round(vrijednost, 2);
                    p.Vrijednost = vrijednost;
                    p.Vrijeme = DateTime.Now;
                    Console.WriteLine(p);
                    KonverzijaPodatakaUCollectionDescription(p);
                    break;
                default:
                    brojac = 0;
                    break;
            }

        }

        //manuelni unos poredi kakav kod je prosledjen i na osnovu nejga ispisuje  sta je poslato i da li je ispravno
        public void manuelnoUDumpingBuffer(Podatak p)
        {
           
            switch (p.Kod.ToUpper())
            {
                case "CODE_ANALOG":
                    p.Kod = "CODE_ANALOG";
                    Console.WriteLine(p);
                    KonverzijaPodatakaUCollectionDescription(p);
                    break;
                case "CODE_DIGITAL":
                    p.Kod ="CODE_DIGITAL";
                    Console.WriteLine(p);
                    KonverzijaPodatakaUCollectionDescription(p);
                    break;
                case "CODE_CUSTOM":
                    p.Kod = "CODE_CUSTOM";
                    Console.WriteLine(p);
                    KonverzijaPodatakaUCollectionDescription(p);
                    break;
                case "CODE_LIMITSET":
                    p.Kod = "CODE_LIMITSET";
                    Console.WriteLine(p);
                    KonverzijaPodatakaUCollectionDescription(p);
                    break;
                case "CODE_SINGLENOE":
                    p.Kod = "CODE_SINGLENOE";
                    Console.WriteLine(p);
                    KonverzijaPodatakaUCollectionDescription(p);
                    break;
                case "CODE_MULTIPLENODE":
                    p.Kod = "CODE_MULTIPLENODE";
                    Console.WriteLine(p);
                    KonverzijaPodatakaUCollectionDescription(p);
                    break;
                case "CODE_CONSUMER":
                    p.Kod = "CODE_CONSUMER";
                    Console.WriteLine(p);
                    KonverzijaPodatakaUCollectionDescription(p);
                    break;
                case "CODE_SOURCE":
                    p.Kod = "CODE_SOURCE";
                    Console.WriteLine(p);
                    KonverzijaPodatakaUCollectionDescription(p);
                    break;
                case "CODE_MOTION":
                    p.Kod = "CODE_MOTION";
                    Console.WriteLine(p);
                    KonverzijaPodatakaUCollectionDescription(p);
                    break;
                case "CODE_SENSOR":
                    p.Kod = "CODE_SENSOR";
                    Console.WriteLine(p);
                    KonverzijaPodatakaUCollectionDescription(p);
                    break;
                default:
                    Console.WriteLine("Unijeli ste nepostojeci kod");
                    break;
            }
           
        }


        public void KonverzijaPodatakaUCollectionDescription(Podatak p)
        {
            CollectionDescription cd = new CollectionDescription();
            cd.Id = brojacKonverzija;

            brojacUkupnoPrimljenihPodatakaOdWritera++;


            switch (p.Kod)
            {
                case "CODE_ANALOG":
                    cd.Dataset[kodAnalog] = 1;
                    break;
                case "CODE_DIGITAL":
                    cd.Dataset[kodDigital] = 1;
                    break;
                case "CODE_CUSTOM":
                    cd.Dataset[kodCustom] = 2;
                    break;
                case "CODE_LIMITSET":
                    cd.Dataset[kodLimitset] = 2;
                    break;
                case "CODE_SINGLENOE":
                    cd.Dataset[kodSinglenoe] = 3;
                    break;
                case "CODE_MULTIPLENODE":
                    cd.Dataset[kodMultiplenode] = 3;
                    break;
                case "CODE_CONSUMER":
                    cd.Dataset[kodConsumer] = 4;
                    break;
                case "CODE_SOURCE":
                    cd.Dataset[kodSource] = 4;
                    break;
                case "CODE_MOTION":
                    cd.Dataset[kodMotion] = 5;
                    break;
                case "CODE_SENSOR":
                    cd.Dataset[kodSensor] = 5;
                    break;

            }

            if (cd.DumpingPropertyCollection.ContainsKey(p.Kod))
            {
                cd.DumpingPropertyCollection[p.Kod] = p.Vrijednost;
                update = true;

            }
            else
            {
                cd.DumpingPropertyCollection.Add(p.Kod, p.Vrijednost);
                add = true;

            }

            if (cd.Dataset.ContainsKey(p.Kod) && cd.DumpingPropertyCollection.ContainsKey(p.Kod) && cd.DumpingPropertyCollection[p.Kod] != p.Vrijednost)
            {
                dveRazliciteVrednostiUOkviruIstogDataseta = true;
            }

            if (dveRazliciteVrednostiUOkviruIstogDataseta == true)
            {

                dc.TransactionId = brojacKonverzija;
                if (add == true)
                    dc.Add = cd;
                else
                    dc.Update = cd;

            }

            if (brojacUkupnoPrimljenihPodatakaOdWritera == 10)
            {
                if (dc.Add != null && dc.Update != null)
                {
                    //if(brojacUkupnoPrimljenihPodatakaOdWritera==20)
                    //Kako proslediti IHistorical  u Dumping buffer da bi mogla da se implementira metoda Write
                    //writeToHistory
                }
                else
                {
                    if (brojacUkupnoPrimljenihPodatakaOdWritera == 20)
                    {
                        //WriteToHistory
                    }

                }
            }
            brojacKonverzija++;

        }

    }
}
