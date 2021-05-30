using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class DeltaCD
    {
        private int transactionId;
        CollectionDescription add = new CollectionDescription();
        CollectionDescription update = new CollectionDescription();
        CollectionDescription remove= new CollectionDescription();

        public DeltaCD()
        {

           

        }

        public int TransactionId { get => transactionId; set => transactionId = value; }
        public CollectionDescription Add { get => add; set => add = value; }
        public CollectionDescription Update { get => update; set => update = value; }
        public CollectionDescription Remove { get => remove; set => remove = value; }
    }
}
