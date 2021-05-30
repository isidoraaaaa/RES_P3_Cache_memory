using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [DataContract]
    public class DeltaCD
    {
        private int transactionId;
        CollectionDescription add = new CollectionDescription();
        CollectionDescription update = new CollectionDescription();
        CollectionDescription remove= new CollectionDescription();

        public DeltaCD()
        {

           

        }
        [DataMember]
        public int TransactionId { get => transactionId; set => transactionId = value; }

        [DataMember]
        public CollectionDescription Add { get => add; set => add = value; }

        [DataMember]
        public CollectionDescription Update { get => update; set => update = value; }

        [DataMember]
        public CollectionDescription Remove { get => remove; set => remove = value; }
    }
}
