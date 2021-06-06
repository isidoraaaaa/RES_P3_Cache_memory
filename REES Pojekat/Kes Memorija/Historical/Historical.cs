using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BazaPodataka;
using Common;

namespace Historical
{
    public class Historical : IHistorical
    {
        private IBaza b;
        public Historical() { }
        Dictionary<string, double> HistoricalProperty = new Dictionary<string, double>();
        Description description = new Description();
        List<Description> listDescriptions = new List<Description>();
        Baza baza = new Baza();
        Connection c = new Connection();
        int brojac = 1;
        
        bool ispravanPodatak1=false;
        bool ispravanPodatak2 = false;
        bool ispravanPodatak3 = false;
        bool ispravanPodatak4 = false;
        bool ispravanPodatak5 = false;
        public bool WriteToHistory(DeltaCD cd)
        {
          
            if (konverzijaULD(cd)==true)
            {
                return true;
            }
            else
             return false;

        }
        //ne moze se ni ovo testirati posto zahtjeva rad sa bazom
        public bool konverzijaULD(DeltaCD dc)
        {
            if (dc.Add != null)
            {
                HistoricalProperty = new Dictionary<string, double>();
                description.Id = dc.TransactionId;
                description.DataSet = dc.Add.Dataset;
                foreach (KeyValuePair<string, double> pair in dc.Add.DumpingPropertyCollection)
                {
                    HistoricalProperty.Add(pair.Key, pair.Value);

                }
                description.ListHistoricalPropertys.Add(HistoricalProperty);
                listDescriptions.Add(description);

                if (c.ProveriKonekciju() == false)
                {
                    c.OtvoriRemoteKonekciju();
                }

                foreach (KeyValuePair<string, double> pair in HistoricalProperty)
                {
                    if (ProveraDeadband(pair) == true && ProveraPodataka(description.DataSet) == true)
                    {
                        UpisPodatakaUBazuSaHistoricala(pair);
                    }
                }

                HistoricalProperty.Clear();

                return true;
            }
            else
            {
                HistoricalProperty = new Dictionary<string, double>();
                description.Id = dc.TransactionId;
                description.DataSet = dc.Update.Dataset;
                foreach (KeyValuePair<string, double> pair in dc.Update.DumpingPropertyCollection)
                {
                    HistoricalProperty.Add(pair.Key, pair.Value);
                }
                description.ListHistoricalPropertys.Add(HistoricalProperty);
                listDescriptions.Add(description);

               

                foreach (KeyValuePair<string, double> pair in HistoricalProperty)
                {
                    //if (ProveraDeadband(pair) == true && ProveraPodataka(description.DataSet) == true)
                    //{
                    UpisPodatakaUBazuSaHistoricala(pair);

                    //}
                }
                return false;
            }
        }
        public bool ProveraPodataka(Dictionary<string,int> dataset)
        {
            foreach(KeyValuePair<string,int> pair in dataset)
            {
                if ((pair.Key.Equals("CODE_ANALOG") || pair.Key.Equals("CODE_DIGITAL")) && pair.Value.Equals(1))
                {
                     ispravanPodatak1=true;
                }
                if ((pair.Key.Equals("CODE_CUSTOM") || pair.Key.Equals("CODE_LIMITSET")) && pair.Value.Equals(2))
                {
                    ispravanPodatak2 = true;

                }
                if ((pair.Key.Equals("CODE_SINGLENODE") || pair.Key.Equals("CODE_MULTIPLENODE")) && pair.Value.Equals(3))
                {
                    ispravanPodatak3=true;
                }
                if ((pair.Key.Equals("CODE_CONSUMER") || pair.Key.Equals("CODE_SOURCE")) && pair.Value.Equals(4))
                {
                   ispravanPodatak4=true;
                }
                if ((pair.Key.Equals("CODE_MOTION") || pair.Key.Equals("CODE_SENSOR")) && pair.Value.Equals(5))
                {
                    ispravanPodatak5 = true;
                }
                
            }

            if (ispravanPodatak1 == true || ispravanPodatak2 == true || ispravanPodatak3 == true || ispravanPodatak4 == true || ispravanPodatak5 == true)
            {
                ispravanPodatak1 = false;
                ispravanPodatak2 = false;
                ispravanPodatak3 = false;
                ispravanPodatak4 = false;
                ispravanPodatak5 = false;
                return true;

            }
            return false;
        }
        //testiranje nije obavljeno zato sto nije jos implementirana funkcija do kraja
        public bool ProveraDeadband(KeyValuePair<string,double> pair)
        {
            
                bool upisivanje  = false;
                List<double> list = CitanjePodatakaIzBaze(pair.Key);
                if (list.Count == 0)
                {
                    upisivanje = true;
                }
                else
                {
                    
                    foreach (double d in list)
                    {
                        
                        if (pair.Value > (d * 0.02))
                        {
                            upisivanje = true;

                        }

                    }
                   
                    list = new List<double>();
                }
                return upisivanje;
           

        }
        //Ne moze da se testira posto mora biti otvorena konekcija
        public void UpisPodatakaUBazuSaHistoricala(KeyValuePair<string,double> pair)
        {
           
                if (pair.Key.Equals("CODE_ANALOG"))
                {
                    baza.UpisPodatakaUBazu("dataset_1", pair.Key, pair.Value,DateTime.Now);
                }
                if (pair.Key.Equals("CODE_DIGITAL"))
                {
                    baza.UpisPodatakaUBazu("dataset_1", pair.Key, pair.Value, DateTime.Now);
                }
                if (pair.Key.Equals("CODE_CUSTOM"))
                {
                    baza.UpisPodatakaUBazu("dataset_2", pair.Key, pair.Value, DateTime.Now);
                }
                if (pair.Key.Equals("CODE_LIMITSET"))
                {
                    baza.UpisPodatakaUBazu("dataset_2", pair.Key, pair.Value, DateTime.Now);
                }
                if (pair.Key.Equals("CODE_SINGLENODE"))
                {
                    baza.UpisPodatakaUBazu("dataset_3", pair.Key, pair.Value, DateTime.Now);
                }
               if (pair.Key.Equals("CODE_MULTIPLENODE"))
                {
                    baza.UpisPodatakaUBazu("dataset_3", pair.Key, pair.Value, DateTime.Now);
                }
                if (pair.Key.Equals("CODE_CONSUMER"))
                {
                    baza.UpisPodatakaUBazu("dataset_4", pair.Key, pair.Value, DateTime.Now);
                }
                if (pair.Key.Equals("CODE_SOURCE"))
                {
                    baza.UpisPodatakaUBazu("dataset_4", pair.Key, pair.Value, DateTime.Now);
                }
                if (pair.Key.Equals("CODE_MOTION"))
                {
                    baza.UpisPodatakaUBazu("dataset_5", pair.Key, pair.Value, DateTime.Now);
                }
               if (pair.Key.Equals("CODE_SENSOR"))
                {
                    baza.UpisPodatakaUBazu("dataset_5", pair.Key, pair.Value, DateTime.Now);
                }

        }
        //Pokrivenost koda ne moze da se provjeri za ovo jer se konekcija sa bazom uspostavi tek nakon pokretanja programa
        public List<double> CitanjePodatakaIzBaze(string code)
        {
            
                List<double> lista = new List<double>();

                if (code.ToUpper().Equals("CODE_ANALOG"))
                {
                   lista= baza.CitanjePodatakaIzBaze("dataset_1", code);
                }
                if (code.ToUpper().Equals("CODE_DIGITAL"))
                {
                lista = baza.CitanjePodatakaIzBaze("dataset_1", code);
                }
                if (code.ToUpper().Equals("CODE_CUSTOM"))
                {
                lista = baza.CitanjePodatakaIzBaze("dataset_2", code);
                }
                if (code.ToUpper().Equals("CODE_LIMITSET"))
                {
                lista = baza.CitanjePodatakaIzBaze("dataset_2", code);
                }
                if (code.ToUpper().Equals("CODE_SINGLENODE"))
                {
                lista = baza.CitanjePodatakaIzBaze("dataset_3", code);
                }
                 if (code.ToUpper().Equals("CODE_MULTIPLENODE"))
                {
                lista = baza.CitanjePodatakaIzBaze("dataset_3", code);
                }
                 if (code.ToUpper().Equals("CODE_CONSUMER"))
                {
                lista = baza.CitanjePodatakaIzBaze("dataset_4", code);
                }
                 if (code.ToUpper().Equals("CODE_SOURCE"))
                {
                lista = baza.CitanjePodatakaIzBaze("dataset_4",code);
                }
                 if (code.ToUpper().Equals("CODE_MOTION"))
                {
                lista = baza.CitanjePodatakaIzBaze("dataset_5",code);
                }
                   if (code.ToUpper().Equals("CODE_SENSOR"))
                {
                lista = baza.CitanjePodatakaIzBaze("dataset_5", code);
                }
              

            return lista;
            

        }

       
    }
}
