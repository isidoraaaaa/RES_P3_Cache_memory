using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Common;
namespace DumpingBufferKomponenta

{
    public enum KOD { CODE_ANALOG, CODE_DIGITAL, CODE_CUSTOM, CODE_LIMITSET, CODE_SINGLENODE, CODE_MULTIPLENODE, CODE_CONSUMER, CODE_SOURCE, CODE_MOTION , CODE_SENSOR }  
    public class DumpingBuffer : IDumpingBuffer
    {

        public DumpingBuffer() { }

        Random r = new Random();


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
        [ExcludeFromCodeCoverage]
        public void automatskiUDumpingBuffer()
        {
            int brojac = r.Next(1, 10);
            switch (brojac)
            {
                case 1:
                    p.Kod = KOD.CODE_ANALOG.ToString();
                    vrijednost = random.NextDouble()*(1000.0 - 0.1) + 0.1;
                    vrijednost = (double)System.Math.Round(vrijednost, 2);
                    p.Vrijednost = vrijednost;
                    p.Vrijeme = DateTime.Now;
                    Console.WriteLine(p);
                    KonverzijaPodatakaUCollectionDescription(p);
                    break;
                case 2:
                    p.Kod = KOD.CODE_DIGITAL.ToString();      
                    vrijednost = random.NextDouble() * (1000.0 - 0.1) + 0.1;
                    vrijednost = (double)System.Math.Round(vrijednost, 2);
                    p.Vrijednost = vrijednost;
                    p.Vrijeme = DateTime.Now;
                    Console.WriteLine(p);
                    KonverzijaPodatakaUCollectionDescription(p);
                    break;
                case 3:
                    p.Kod = KOD.CODE_CUSTOM.ToString();
                    vrijednost = random.NextDouble() * (1000.0 - 0.1) + 0.1;
                    vrijednost = (double)System.Math.Round(vrijednost, 2);
                    p.Vrijednost = vrijednost;
                    p.Vrijeme = DateTime.Now;
                    Console.WriteLine(p);
                    KonverzijaPodatakaUCollectionDescription(p);
                    break;
                case 4:
                    p.Kod = KOD.CODE_LIMITSET.ToString();
                    vrijednost = random.NextDouble() * (1000.0 - 0.1) + 0.1;
                    vrijednost = (double)System.Math.Round(vrijednost, 2);
                    p.Vrijednost = vrijednost;
                    p.Vrijeme = DateTime.Now;
                    Console.WriteLine(p);
                    KonverzijaPodatakaUCollectionDescription(p);
                    break;
                case 5:
                    p.Kod = KOD.CODE_SINGLENODE.ToString();
                    vrijednost = random.NextDouble() * (1000.0 - 0.1) + 0.1;
                    vrijednost = (double)System.Math.Round(vrijednost, 2);
                    p.Vrijednost = vrijednost;
                    p.Vrijeme = DateTime.Now;
                    Console.WriteLine(p);
                    KonverzijaPodatakaUCollectionDescription(p);
                    break;
                case 6:
                    p.Kod = KOD.CODE_MULTIPLENODE.ToString();
                    vrijednost = random.NextDouble() * (1000.0 - 0.1) + 0.1;
                    vrijednost = (double)System.Math.Round(vrijednost, 2);
                    p.Vrijednost = vrijednost;
                    p.Vrijeme = DateTime.Now;
                    Console.WriteLine(p);
                    KonverzijaPodatakaUCollectionDescription(p);
                    break;
                case 7:
                    p.Kod = KOD.CODE_CONSUMER.ToString();
                    vrijednost = random.NextDouble() * (1000.0 - 0.1) + 0.1;
                    vrijednost = (double)System.Math.Round(vrijednost, 2);
                    p.Vrijednost = vrijednost;
                    p.Vrijeme = DateTime.Now;
                    Console.WriteLine(p);
                    KonverzijaPodatakaUCollectionDescription(p);
                    break;
                case 8:
                    p.Kod = KOD.CODE_SOURCE.ToString();
                    vrijednost = random.NextDouble() * (1000.0 - 0.1) + 0.1;
                    vrijednost = (double)System.Math.Round(vrijednost, 2);
                    p.Vrijednost = vrijednost;
                    p.Vrijeme = DateTime.Now;
                    Console.WriteLine(p);
                    KonverzijaPodatakaUCollectionDescription(p);
                    break;
                case 9:
                    p.Kod = KOD.CODE_MOTION.ToString();
                    vrijednost = random.NextDouble() * (1000.0 - 0.1) + 0.1;
                    vrijednost = (double)System.Math.Round(vrijednost, 2);
                    p.Vrijednost = vrijednost;
                    p.Vrijeme = DateTime.Now;
                    Console.WriteLine(p);
                    KonverzijaPodatakaUCollectionDescription(p);
                    break;
                case 10:
                    p.Kod = KOD.CODE_SENSOR.ToString();
                    vrijednost = random.NextDouble() * (1000.0 - 0.1) + 0.1;
                    vrijednost = (double)System.Math.Round(vrijednost, 2);
                    p.Vrijednost = vrijednost;
                    p.Vrijeme = DateTime.Now;
                    Console.WriteLine(p);
                    KonverzijaPodatakaUCollectionDescription(p);
                    break;
                default:
                    brojac = 0;
                    throw new LosKodArgumentException();
                    
            }
            ispisivanjeBrojac++;
            if (ispisivanjeBrojac == 10)
            {
                Console.WriteLine("---------------------------------------------------------------");
                ispisivanjeBrojac = 0;
            }
               

        }

        //manuelni unos poredi kakav kod je prosledjen i na osnovu nejga ispisuje  sta je poslato i da li je ispravno
        [ExcludeFromCodeCoverage]
        public void manuelnoUDumpingBuffer(Podatak p)
        {
           
            switch (p.Kod.ToUpper())
            {
                case "CODE_ANALOG":
                    p.Kod = KOD.CODE_ANALOG.ToString();
                    Console.WriteLine(p);
                    KonverzijaPodatakaUCollectionDescription(p);
                    break;
                case "CODE_DIGITAL":
                    p.Kod =KOD.CODE_DIGITAL.ToString();
                    Console.WriteLine(p);
                    KonverzijaPodatakaUCollectionDescription(p);
                    break;
                case "CODE_CUSTOM":
                    p.Kod = KOD.CODE_CUSTOM.ToString();
                    Console.WriteLine(p);
                    KonverzijaPodatakaUCollectionDescription(p);
                    break;
                case "CODE_LIMITSET":
                    p.Kod = KOD.CODE_LIMITSET.ToString();
                    Console.WriteLine(p);
                    KonverzijaPodatakaUCollectionDescription(p);
                    break;
                case "CODE_SINGLENODE":
                    p.Kod = KOD.CODE_SINGLENODE.ToString();
                    Console.WriteLine(p);
                    KonverzijaPodatakaUCollectionDescription(p);
                    break;
                case "CODE_MULTIPLENODE":
                    p.Kod = KOD.CODE_MULTIPLENODE.ToString();
                    Console.WriteLine(p);
                    KonverzijaPodatakaUCollectionDescription(p);
                    break;
                case "CODE_CONSUMER":
                    p.Kod = KOD.CODE_CONSUMER.ToString();
                    Console.WriteLine(p);
                    KonverzijaPodatakaUCollectionDescription(p);
                    break;
                case "CODE_SOURCE":
                    p.Kod = KOD.CODE_SOURCE.ToString();
                    Console.WriteLine(p);
                    KonverzijaPodatakaUCollectionDescription(p);
                    break;
                case "CODE_MOTION":
                    p.Kod = KOD.CODE_MOTION.ToString();
                    Console.WriteLine(p);
                    KonverzijaPodatakaUCollectionDescription(p);
                    break;
                case "CODE_SENSOR":
                    p.Kod = KOD.CODE_SENSOR.ToString();
                    Console.WriteLine(p);
                    KonverzijaPodatakaUCollectionDescription(p);
                    break;
                default:
                    Console.WriteLine("Unijeli ste nepostojeci kod");
                    throw new LosKodArgumentException();


            }
            ispisivanjeManuleno++;
            if (ispisivanjeManuleno == 5)
            {
                Console.WriteLine("---------------------------------------------------------------");
                ispisivanjeManuleno = 0;
               
            }

        }

        [ExcludeFromCodeCoverage]
        public void KonverzijaPodatakaUCollectionDescription(Podatak p)
        {
            
            cd.Id = brojacKonverzija;

            brojacUkupnoPrimljenihPodatakaOdWritera++;


            switch (p.Kod)
            {
                case "CODE_ANALOG":
                    cd.Dataset[KOD.CODE_ANALOG.ToString()] = 1;
                    break;
                case "CODE_DIGITAL":
                    cd.Dataset[KOD.CODE_DIGITAL.ToString()] = 1;
                    break;
                case "CODE_CUSTOM":
                    cd.Dataset[KOD.CODE_CUSTOM.ToString()] = 2;
                    break;
                case "CODE_LIMITSET":
                    cd.Dataset[KOD.CODE_LIMITSET.ToString()] = 2;
                    break;
                case "CODE_SINGLENODE":
                    cd.Dataset[KOD.CODE_SINGLENODE.ToString()] = 3;
                    break;
                case "CODE_MULTIPLENODE":
                    cd.Dataset[KOD.CODE_MULTIPLENODE.ToString()] = 3;
                    break;
                case "CODE_CONSUMER":
                    cd.Dataset[KOD.CODE_CONSUMER.ToString()] = 4;
                    break;
                case "CODE_SOURCE":
                    cd.Dataset[KOD.CODE_SOURCE.ToString()] = 4;
                    break;
                case "CODE_MOTION":
                    cd.Dataset[KOD.CODE_MOTION.ToString()] = 5;
                    break;
                case "CODE_SENSOR":
                    cd.Dataset[KOD.CODE_SENSOR.ToString()] = 5;
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

            if (brojacUkupnoPrimljenihPodatakaOdWritera == 2)//10
            {
                if (dc.Add == null && dc.Update == null)
                {
                    if (brojacUkupnoPrimljenihPodatakaOdWritera == 6)//20
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
