using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [ServiceContract]
   public interface IDumpingBuffer
    {
        [OperationContract]
        void automatskiUDumpingBuffer();
        [OperationContract]
        void manuelnoUDumpingBuffer(Podatak p);
        [OperationContract]
        void KonverzijaPodatakaUCollectionDescription(Podatak p);




    }
}
