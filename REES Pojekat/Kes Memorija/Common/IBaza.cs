using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
   
    public interface IBaza
    {
       
        void UpisPodatakaUBazu(string tabela, string code,double value);
        List<double> CitanjePodatakaIzBaze(string tabela, string code);

    }
}
