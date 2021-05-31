using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Historical
{
    public class Historical : IHistorical
    {
        Dictionary<string, double> HistoricalProperty = new Dictionary<string, double>();
        Description description = new Description();
        List<Description> listDescriptions = new List<Description>();
        bool ispravanPodatak1=false;
        bool ispravanPodatak2 = false;
        bool ispravanPodatak3 = false;
        bool ispravanPodatak4 = false;
        bool ispravanPodatak5 = false;
        public void WriteToHistory(DeltaCD cd)
        {
            if (cd.Add != null)
            {
                //Console.WriteLine("\n");
                //Console.WriteLine("ADD\n");
                //Console.WriteLine("Transaction id -> " + cd.TransactionId + "\n");
                //Console.WriteLine("PROPERTY COLECTION \n");
                //foreach (KeyValuePair<string, double> i in cd.Add.DumpingPropertyCollection)
                //{
                //    Console.WriteLine($"{i.Key} ->  {i.Value}");
                //}
                //Console.WriteLine("\n");
                //Console.WriteLine("DATASET \n");
                //foreach (KeyValuePair<string, int> i in cd.Add.Dataset)
                //{
                //    Console.WriteLine($"{i.Key} ->  {i.Value}");
                //}

                konverzijaULD(cd);


            }
            else
            {
                //Console.WriteLine("\n");
                //Console.WriteLine("UPDATE\n");
                //Console.WriteLine("Transaction id -> " + cd.TransactionId + "\n");
                //foreach (KeyValuePair<string, double> i in cd.Update.DumpingPropertyCollection)
                //{
                //    Console.WriteLine($"{i.Key} ->  {i.Value}");
                //}
                //Console.WriteLine("\n");
                //Console.WriteLine("DATASET\n");
                //foreach (KeyValuePair<string, int> i in cd.Update.Dataset)
                //{
                //    Console.WriteLine($"{i.Key} ->  {i.Value}");
                //}

                konverzijaULD(cd);
            }
        }
        public void konverzijaULD(DeltaCD dc)
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
                //Console.WriteLine("\n");
                //Console.WriteLine($"DESCRIPTION ID -> {description.Id}");
                //Console.WriteLine("\n");
                //Console.WriteLine("DATASET");
                //foreach (KeyValuePair<string, int> pair1 in description.DataSet)
                //{
                //    Console.WriteLine($"{pair1.Key} -> {pair1.Value}");
                //    Console.WriteLine("\n");
                //}
                //Console.WriteLine("\n");
                //Console.WriteLine("HISTORICAL PROPERTY");
                //foreach (KeyValuePair<string, double> pair2 in HistoricalProperty)
                //{
                //    Console.WriteLine($"{pair2.Key} -> {pair2.Value}");
                //    Console.WriteLine("\n");
                //}
                //Console.WriteLine("\n");
                //Console.WriteLine("LIST OF HISTORICAL PROPERTY");
                //foreach (Dictionary<string, double> pair1 in description.ListHistoricalPropertys)
                //{
                //    foreach (KeyValuePair<string, double> item in pair1)
                //    {
                //        Console.WriteLine($"{item.Key} -> {item.Value}");
                //        Console.WriteLine("\n");
                //    }

                //}

                Console.WriteLine("\n");
                Console.WriteLine("LIST OF DESCRIPTIONS");
                foreach (Description d in listDescriptions)
                {
                    Console.WriteLine("\n");

                    Console.WriteLine($"DESCRIPTION ID -> {d.Id}");
                    Console.WriteLine("\n");
                    foreach (KeyValuePair<string, int> pair1 in d.DataSet)
                    {
                        Console.WriteLine($"{pair1.Key} -> {pair1.Value}");
                        Console.WriteLine("\n");
                    }


                    Console.WriteLine("LIST OF HISTORICAL PROPERTY");
                    foreach (Dictionary<string, double> pair1 in d.ListHistoricalPropertys)
                    {
                        foreach (KeyValuePair<string, double> item in pair1)
                        {
                            Console.WriteLine($"{item.Key} -> {item.Value}");
                            Console.WriteLine("\n");
                        }

                    }

                }



                ProveraPodataka();
               
            }
            else
            {
                description.Id = dc.TransactionId;
                description.DataSet = dc.Update.Dataset;
                foreach (KeyValuePair<string, double> pair in dc.Update.DumpingPropertyCollection)
                {
                    HistoricalProperty.Add(pair.Key, pair.Value);

                }
                description.ListHistoricalPropertys.Add(HistoricalProperty);
                listDescriptions.Add(description);

                ProveraPodataka();
               
            }
                
            
           
        }

        public void ProveraPodataka()
        {

            foreach(KeyValuePair<string,int> pair in description.DataSet)
            {
                if((pair.Key.Equals("CODE_ANALOG") || pair.Key.Equals("CODE_DIGITAL")) && pair.Value.Equals(1))
                {
                    ispravanPodatak1 = true;
                }
                if ((pair.Key.Equals("CODE_CUSTOM") || pair.Key.Equals("CODE_LIMITSET")) && pair.Value.Equals(2))
                {
                    ispravanPodatak2 = true;
                }
                if ((pair.Key.Equals("CODE_SINGLENODE") || pair.Key.Equals("CODE_MULTIPLENODE")) && pair.Value.Equals(3))
                {
                    ispravanPodatak3 = true;
                }
                if ((pair.Key.Equals("CODE_CONSUMER") || pair.Key.Equals("CODE_SOURCE")) && pair.Value.Equals(4))
                {
                    ispravanPodatak4 = true;
                }

                if ((pair.Key.Equals("CODE_MOTION") || pair.Key.Equals("CODE_SENSOR")) && pair.Value.Equals(5))
                {
                    ispravanPodatak5 = true;
                }

            }
            if(ispravanPodatak1==true && ispravanPodatak2==true && ispravanPodatak3==true && ispravanPodatak4==true && ispravanPodatak5)
                 Console.WriteLine("Podatak ispravan!");
            else
                Console.WriteLine("Podatak nije ispravan i nemoguce ga je snimiti u bazu!");
        }
    }
}
