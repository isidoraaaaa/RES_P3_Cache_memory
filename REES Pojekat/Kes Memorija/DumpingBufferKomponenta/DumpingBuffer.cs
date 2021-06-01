using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Common;
namespace DumpingBufferKomponenta

{
   
    public class DumpingBuffer : IDumpingBuffer
    {

        Random r = new Random();
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



        bool update = false;
        bool add = false;
        DeltaCD dc = new DeltaCD();
        int brojacKonverzija = 0; // sluzi za generisanje jedinstvenog Id
        bool dveRazliciteVrednostiUOkviruIstogDataseta = false;
        int brojacUkupnoPrimljenihPodatakaOdWritera = 0;
        IHistorical kanal = Singleton.Instance();
        CollectionDescription cd = new CollectionDescription();
        int ispisivanjeBrojac = 0;
        int ispisivanjeManuleno = 0;





        //funkcija za svaku vrijednsot brojaca ima odredjeno koji kod salje, dok je vrijednsot koju salje 
        //random broj koji se izracunava po odredjenom formuli
        public void automatskiUDumpingBuffer()
        {
            int brojac = r.Next(1, 10);
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
            ispisivanjeBrojac++;
            if (ispisivanjeBrojac == 10)
            {
                Console.WriteLine("---------------------------------------------------------------");
                ispisivanjeBrojac = 0;
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
            ispisivanjeManuleno++;
            if (ispisivanjeManuleno == 5)
            {
                Console.WriteLine("---------------------------------------------------------------");
                ispisivanjeManuleno = 0;
            }

        }

        public void KonverzijaPodatakaUCollectionDescription(Podatak p)
        {
            
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
            else//(!cd.DumpingPropertyCollection.ContainsKey(p.Kod))
            {   cd.DumpingPropertyCollection.Add(p.Kod, p.Vrijednost);
                add = true;

            }

            //Provera da li dati kod postoji u okviru dataseta, da li dati kod postoji vec u dumpingProperyCollection strukturi i ako postoji da li je njegova vrednost razlicita
            //od pristigle vrednosti pristiglog podatka

            for (int i = 0; i < cd.DumpingPropertyCollection.Count; i++)
            {
                for (int j = 0; j < cd.DumpingPropertyCollection.Count; j++)
                {
                    KeyValuePair<string, double> pair1 = cd.DumpingPropertyCollection.ElementAt(i);
                    KeyValuePair<string, double> pair2 = cd.DumpingPropertyCollection.ElementAt(j);
                    if (cd.Dataset[pair1.Key] == cd.Dataset[pair2.Key])
                    {
                        if (pair1.Value != pair2.Value)
                            dveRazliciteVrednostiUOkviruIstogDataseta = true;
                    }

                }

            }

            if (dveRazliciteVrednostiUOkviruIstogDataseta == true)
            {

                dc.TransactionId = brojacKonverzija;
                if (add == true)
                    dc.Add = cd;
                else if(update==true)
                    dc.Update = cd;

            }

            if (brojacUkupnoPrimljenihPodatakaOdWritera == 10)//10
            {
                if (dc.Add == null && dc.Update == null)
                {
                    if (brojacUkupnoPrimljenihPodatakaOdWritera == 20)//20
                    {
                        kanal.WriteToHistory(dc);
                        brojacUkupnoPrimljenihPodatakaOdWritera = 0;
                        cd = new CollectionDescription();
                        dc = new DeltaCD();
                    }
                    //ne treba u else-u da setujemo brojacUkupnoPrimljenihPodatakaOdWritera=0 jer zelimo da stignemo
                    //do broja 20. Isto tako ne prepisujemo objekte zato sto zelimo da se u medjuvremenu postojeci
                    //sadrzaj update-uje
                }
                else
                {
                    kanal.WriteToHistory(dc);
                    brojacUkupnoPrimljenihPodatakaOdWritera = 0;
                   cd = new CollectionDescription();
                    dc = new DeltaCD();
                }
            }
            brojacKonverzija++;

        }



    }
}
