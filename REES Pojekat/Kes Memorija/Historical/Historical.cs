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
        public void WriteToHistory(DeltaCD cd)
        {
            if (cd.Add != null)
            {
                Console.WriteLine("\n");
                Console.WriteLine("ADD\n");
                Console.WriteLine("Transaction id -> " + cd.TransactionId + "\n");
                Console.WriteLine("PROPERTY COLECTION \n");
                foreach (KeyValuePair<string, double> i in cd.Add.DumpingPropertyCollection)
                {
                    Console.WriteLine($"{i.Key} ->  {i.Value}");
                }
                Console.WriteLine("\n");
                Console.WriteLine("DATASET \n");
                foreach (KeyValuePair<string, int> i in cd.Add.Dataset)
                {
                    Console.WriteLine($"{i.Key} ->  {i.Value}");
                }




            }
            else
            {
                Console.WriteLine("\n");
                Console.WriteLine("UPDATE\n");
                Console.WriteLine("Transaction id -> " + cd.TransactionId + "\n");
                foreach (KeyValuePair<string, double> i in cd.Update.DumpingPropertyCollection)
                {
                    Console.WriteLine($"{i.Key} ->  {i.Value}");
                }
                Console.WriteLine("\n");
                Console.WriteLine("DATASET\n");
                foreach (KeyValuePair<string, int> i in cd.Update.Dataset)
                {
                    Console.WriteLine($"{i.Key} ->  {i.Value}");
                }
            }
        }
    }
}
