using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Common
{
    [ServiceContract]
    public interface IHistorical
    {
        [OperationContract]
        void WriteToHistory(DeltaCD cd);
        [OperationContract]
        List<double> CitanjePodatakaIzBaze(string code);

        void konverzijaULD(DeltaCD dc);
        bool ProveraPodataka(Dictionary<string, int> dataset);
        bool ProveraDeadband(KeyValuePair<string, double> pair);
        void UpisPodatakaUBazu(KeyValuePair<string, double> pair);




    }
}
