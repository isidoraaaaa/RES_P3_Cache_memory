using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [DataContract]
   public class Description
    {
        private int id;
        List<Dictionary<string, double>> listHistoricalPropertys = new List<Dictionary<string, double>>();

        Dictionary<string, int> dataSet = new Dictionary<string, int>();

        [DataMember]
        public List<Dictionary<string, double>> ListHistoricalPropertys { get => listHistoricalPropertys; set => listHistoricalPropertys = value; }
        [DataMember]
        public Dictionary<string, int> DataSet { get => dataSet; set => dataSet = value; }
        [DataMember]
        public int Id { get => id; set => id = value; }
    }
}
