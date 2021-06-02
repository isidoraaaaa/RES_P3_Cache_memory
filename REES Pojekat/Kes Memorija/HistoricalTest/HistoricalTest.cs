using Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricalTest
{
    [TestFixture]
    class HistoricalTest
    {
        Historical.Historical historical;

        [Test]
        public void citanjeizBazeNeuspjesno()
        {
            historical = new Historical.Historical();
            List<double> lista = new List<double>();
            Assert.Throws<LosKodArgumentException>(
                () =>lista = historical.CitanjePodatakaIzBaze("neki kod")
                ); 
        }
        
    

        //[Test]
        //public void upisPodatakaUBazuLose()
        //{
        //    historical = new Historical.Historical();
        //    KeyValuePair<string, double> k = new KeyValuePair<string, double>("neki string",22.2);
        //    Assert.Throws<LosKodArgumentException>(
        //        () => historical.UpisPodatakaUBazu(k)
        //        ); ;         
        //}

        [Test]
        public void provjeraPodatakaUspjesna()
        {
            historical = new Historical.Historical();
            Dictionary<string, int> proba = new Dictionary<string, int>();
            proba.Add("CODE_ANALOG", 1);
            historical.ProveraPodataka(proba);
        }

        //[Test]
        //public void provjeraPodatakaNeuspjesna()
        //{
        //    historical = new Historical.Historical();
        //    Dictionary<string, int> proba = new Dictionary<string, int>();
        //    proba.Add("neki string", 1);
        //    Assert.Throws<ArgumentException>(
        //        () => historical.ProveraPodataka(proba)
        //        );
        //}
    }
}
