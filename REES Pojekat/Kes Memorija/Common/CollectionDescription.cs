using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [DataContract]
    public class CollectionDescription
    {
        private int id;
        Dictionary<string, double> dumpingPropertyCollection = new Dictionary<string, double>();
        Dictionary<string, int> dataset = new Dictionary<string, int>();

        public CollectionDescription() {}
        
        [DataMember]
        public int Id { get => id; set => id = value; }

        [DataMember]
        public Dictionary<string, double> DumpingPropertyCollection { get => dumpingPropertyCollection; set => dumpingPropertyCollection = value; }
        [DataMember]
        public Dictionary<string, int> Dataset { get => dataset; set => dataset = value; }
    }
}
