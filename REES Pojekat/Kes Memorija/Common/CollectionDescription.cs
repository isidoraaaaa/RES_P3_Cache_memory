using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class CollectionDescription
    {
        private int id;
        Dictionary<string, double> dumpingPropertyCollection = new Dictionary<string, double>();
        Dictionary<string, int> dataset = new Dictionary<string, int>();

        public CollectionDescription()
        {

        }

        
        public int Id { get => id; set => id = value; }
        public Dictionary<string, double> DumpingPropertyCollection { get => dumpingPropertyCollection; set => dumpingPropertyCollection = value; }
        public Dictionary<string, int> Dataset { get => dataset; set => dataset = value; }
    }
}
