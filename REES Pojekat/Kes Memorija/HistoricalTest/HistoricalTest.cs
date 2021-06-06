using BazaPodataka;
using Common;
using Moq;
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
        IHistorical h;
        Historical.Historical historical;
        Mock<IBaza> moqBaza = new Mock<IBaza>();
      

        [SetUp]
        public void SetUp()
        {
            moqBaza = new Mock<IBaza>();
            h = new Historical.Historical();
        }

        [TearDown]
        public void TearDown()
        {
            moqBaza = null;
            h = null;
        }
      

        [Test]
        public void KonverzijaULDTrueTest1()
        {
            
            CollectionDescription cd = new CollectionDescription();
            cd.Id = 1;
            cd.DumpingPropertyCollection["CODE_ANALOG"] = 124;
            cd.Dataset["CODE_ANALOG"] = 1;
            DeltaCD dcd = new DeltaCD();
            dcd.Add = cd;
            dcd.Update = null;
            dcd.Update = null;
            dcd.TransactionId = 1;
            Assert.IsTrue(h.konverzijaULD(dcd));
        }

        [Test]
        public void KonverzijaULDTrueTest2()
        {

            CollectionDescription cd = new CollectionDescription();
            cd.Id = 1;
            cd.DumpingPropertyCollection["CODE_DIGITAL"] = 124;
            cd.Dataset["CODE_DIGITAL"] = 1;
            DeltaCD dcd = new DeltaCD();
            dcd.Add = cd;
            dcd.Update = null;
            dcd.Update = null;
            dcd.TransactionId = 1;
            Assert.IsTrue(h.konverzijaULD(dcd));
        }

        [Test]
        public void KonverzijaULDTrueTest3()
        {

            CollectionDescription cd = new CollectionDescription();
            cd.Id = 1;
            cd.DumpingPropertyCollection["CODE_CUSTOM"] = 124;
            cd.Dataset["CODE_CUSTOM"] = 2;
            DeltaCD dcd = new DeltaCD();
            dcd.Add = cd;
            dcd.Update = null;
            dcd.Update = null;
            dcd.TransactionId = 1;
            Assert.IsTrue(h.konverzijaULD(dcd));
        }

        [Test]
        public void KonverzijaULDTrueTest4()
        {
            CollectionDescription cd = new CollectionDescription();
            cd.Id = 1;
            cd.DumpingPropertyCollection["CODE_LIMITSET"] = 124;
            cd.Dataset["CODE_LIMITSET"] = 2;
            DeltaCD dcd = new DeltaCD();
            dcd.Add = cd;
            dcd.Update = null;
            dcd.Update = null;
            dcd.TransactionId = 1;
            Assert.IsTrue(h.konverzijaULD(dcd));
        }
        

       [Test]
        public void KonverzijaULDTrueTest5()
        {
            CollectionDescription cd = new CollectionDescription();
            cd.Id = 1;
            cd.DumpingPropertyCollection["CODE_SINGLENODE"] = 124;
            cd.Dataset["CODE_SINGLENODE"] = 3;
            DeltaCD dcd = new DeltaCD();
            dcd.Add = cd;
            dcd.Update = null;
            dcd.Update = null;
            dcd.TransactionId = 1;
            Assert.IsTrue(h.konverzijaULD(dcd));
        }


        [Test]
        public void KonverzijaULDTrueTest6()
        {
            CollectionDescription cd = new CollectionDescription();
            cd.Id = 1;
            cd.DumpingPropertyCollection["CODE_MULTIPLENODE"] = 124;
            cd.Dataset["CODE_MULTIPLENODE"] = 3;
            DeltaCD dcd = new DeltaCD();
            dcd.Add = cd;
            dcd.Update = null;
            dcd.Update = null;
            dcd.TransactionId = 1;
            Assert.IsTrue(h.konverzijaULD(dcd));
        }

        [Test]
        public void KonverzijaULDTrueTest7()
        {
            CollectionDescription cd = new CollectionDescription();
            cd.Id = 1;
            cd.DumpingPropertyCollection["CODE_CONSUMER"] = 124;
            cd.Dataset["CODE_CONSUMER"] = 4;
            DeltaCD dcd = new DeltaCD();
            dcd.Add = cd;
            dcd.Update = null;
            dcd.Update = null;
            dcd.TransactionId = 1;
            Assert.IsTrue(h.konverzijaULD(dcd));
        }

        [Test]
        public void KonverzijaULDTrueTest8()
        {
            CollectionDescription cd = new CollectionDescription();
            cd.Id = 1;
            cd.DumpingPropertyCollection["CODE_SOURCE"] = 124;
            cd.Dataset["CODE_SOURCE"] = 4;
            DeltaCD dcd = new DeltaCD();
            dcd.Add = cd;
            dcd.Update = null;
            dcd.Update = null;
            dcd.TransactionId = 1;
            Assert.IsTrue(h.konverzijaULD(dcd));
        }

        [Test]
        public void KonverzijaULDTrueTest9()
        {
            CollectionDescription cd = new CollectionDescription();
            cd.Id = 1;
            cd.DumpingPropertyCollection["CODE_MOTION"] = 124;
            cd.Dataset["CODE_MOTION"] = 5;
            DeltaCD dcd = new DeltaCD();
            dcd.Add = cd;
            dcd.Update = null;
            dcd.Update = null;
            dcd.TransactionId = 1;
            Assert.IsTrue(h.konverzijaULD(dcd));
        }

        [Test]
        public void KonverzijaULDTrueTest10()
        {
            CollectionDescription cd = new CollectionDescription();
            cd.Id = 1;
            cd.DumpingPropertyCollection["CODE_SENSOR"] = 124;
            cd.Dataset["CODE_SENSOR"] = 5;
            DeltaCD dcd = new DeltaCD();
            dcd.Add = cd;
            dcd.Update = null;
            dcd.Update = null;
            dcd.TransactionId = 1;
            Assert.IsTrue(h.konverzijaULD(dcd));
        }

        [Test]
        public void WriteToHistoryTrueTest()
        {
            CollectionDescription cd = new CollectionDescription();
            cd.Id = 1;
            cd.DumpingPropertyCollection["CODE_ANALOG"] = 124;
            cd.Dataset["CODE_ANALOG"] = 1;
            DeltaCD dcd = new DeltaCD();
            dcd.Add = cd;
            dcd.Update = null;
            dcd.Update = null;
            dcd.TransactionId = 1;
            Assert.IsTrue(h.WriteToHistory(dcd));
        }

        [Test]
        public void WriteToHistoryFalseTest()
        {
            CollectionDescription cd = new CollectionDescription();
            cd.Id = 1;
            cd.DumpingPropertyCollection["CODE_ANALOG"] = 124;
            cd.Dataset["CODE_ANALOG"] = 1;
            DeltaCD dcd = new DeltaCD();
            dcd.Add = null;
            dcd.Update = null;
            dcd.Update = cd;
            dcd.TransactionId = 1;
            Assert.IsFalse(h.WriteToHistory(dcd));
        }
        //[Test]
        //public void konverzijaULDDFalseTest()
        //{
        //    CollectionDescription cd = new CollectionDescription();
        //    cd.Id = 1;
        //    cd.DumpingPropertyCollection["CODE_ANALOG"] = 124;
        //    cd.Dataset["CODE_ANALOG"] = 1;
        //    DeltaCD dcd = new DeltaCD();
        //    dcd.Add = null;
        //    dcd.Update = null;
        //    dcd.Update = cd;
        //    dcd.TransactionId = 1;
        //    Assert.IsFalse(h.konverzijaULD(dcd));
        //}

        //ARGUMENT NULL/DOBAR, dodati custom excepton

        [Test]
        public void upisDatum1()
        {
            List<double> lista = new List<double>();
            lista = h.citanjeZaDatum("CODE_DIGITAL", "dataset_1", "2021-06-03", "2021-06-04");
            Assert.AreEqual(lista, h.citanjeZaDatum("CODE_DIGITAL", "dataset_1", "2021-06-03", "2021-06-04"));
        }

        [Test]
        public void upisDatum2()
        {
            List<double> lista = new List<double>();
            lista = h.citanjeZaDatum("CODE_ANALOG", "dataset_1", "2021-06-03", "2021-06-04");
            Assert.AreEqual(lista, h.citanjeZaDatum("CODE_ANALOG", "dataset_1", "2021-06-03", "2021-06-04"));
        }

        [Test]
        public void upisDatum3()
        {
            List<double> lista = new List<double>();
            lista = h.citanjeZaDatum("CODE_CUSTOM", "dataset_2", "2021-06-03", "2021-06-04");
            Assert.AreEqual(lista, h.citanjeZaDatum("CODE_CUSTOM", "dataset_2", "2021-06-03", "2021-06-04"));
        }

        [Test]
        public void upisDatum4()
        {
            List<double> lista = new List<double>();
            lista = h.citanjeZaDatum("CODE_LIMITSET", "dataset_2", "2021-06-03", "2021-06-04");
            Assert.AreEqual(lista, h.citanjeZaDatum("CODE_LIMITSET", "dataset_2", "2021-06-03", "2021-06-04"));
        }

        [Test]
        public void upisDatum5()
        {
            List<double> lista = new List<double>();
            lista = h.citanjeZaDatum("CODE_SINGLENODE", "dataset_3", "2021-06-03", "2021-06-04");
            Assert.AreEqual(lista, h.citanjeZaDatum("CODE_SINGLENODE", "dataset_3", "2021-06-03", "2021-06-04"));
        }

        [Test]
        public void upisDatum6()
        {
            List<double> lista = new List<double>();
            lista = h.citanjeZaDatum("CODE_MULTIPLENODE", "dataset_3", "2021-06-03", "2021-06-04");
            Assert.AreEqual(lista, h.citanjeZaDatum("CODE_MULTIPLENODE", "dataset_3", "2021-06-03", "2021-06-04"));
        }

        [Test]
        public void upisDatum7()
        {
            List<double> lista = new List<double>();
            lista = h.citanjeZaDatum("CODE_CONSUMER", "dataset_4", "2021-06-03", "2021-06-04");
            Assert.AreEqual(lista, h.citanjeZaDatum("CODE_CONSUMER", "dataset_4", "2021-06-03", "2021-06-04"));
        }

        [Test]
        public void upisDatum8()
        {
            List<double> lista = new List<double>();
            lista = h.citanjeZaDatum("CODE_SOURCE", "dataset_4", "2021-06-03", "2021-06-04");
            Assert.AreEqual(lista, h.citanjeZaDatum("CODE_SOURCE", "dataset_4", "2021-06-03", "2021-06-04"));
        }
        [Test]
        public void upisDatum9()
        {
            List<double> lista = new List<double>();
            lista = h.citanjeZaDatum("CODE_MOTION", "dataset_5", "2021-06-03", "2021-06-04");
            Assert.AreEqual(lista, h.citanjeZaDatum("CODE_MOTION", "dataset_5", "2021-06-03", "2021-06-04"));
        }
        [Test]
        public void upisDatum10()
        {
            List<double> lista = new List<double>();
            lista = h.citanjeZaDatum("CODE_SENSOR", "dataset_5", "2021-06-03", "2021-06-04");
            Assert.AreEqual(lista, h.citanjeZaDatum("CODE_SENSOR", "dataset_5", "2021-06-03", "2021-06-04"));
        }

        [Test]
        public void proveraPodatakaTrueTest()
        {
            Dictionary<string, int> dataset = new Dictionary<string, int>();
            dataset.Add("CODE_ANALOG", 1);
            foreach (var val in dataset)
                Assert.IsTrue(h.ProveraPodataka(dataset));
        }

        [Test]
        public void proveraPodatakaFalseTest()
        {
            Dictionary<string, int> dataset = new Dictionary<string, int>();
            dataset.Add("CODE_ANALOG", 0);
            Assert.IsFalse(h.ProveraPodataka(dataset));
        }

        [Test]
        public void provjeraPodatakaUspjesna1()
        {
            historical = new Historical.Historical();
            Dictionary<string, int> proba = new Dictionary<string, int>();
            proba.Add("CODE_ANALOG", 1);
            historical.ProveraPodataka(proba);
            Assert.IsTrue(historical.ProveraPodataka(proba));
        }

        [Test]
        public void provjeraPodatakaUspjesna2()
        {
            historical = new Historical.Historical();
            Dictionary<string, int> proba = new Dictionary<string, int>();
            proba.Add("CODE_DIGITAL", 1);
            historical.ProveraPodataka(proba);
            Assert.IsTrue(historical.ProveraPodataka(proba));
        }

        [Test]
        public void provjeraPodatakaUspjesna3()
        {
            historical = new Historical.Historical();
            Dictionary<string, int> proba = new Dictionary<string, int>();
            proba.Add("CODE_CUSTOM", 2);
            historical.ProveraPodataka(proba);
            Assert.IsTrue(historical.ProveraPodataka(proba));
        }


        [Test]
        public void provjeraPodatakaUspjesna4()
        {
            historical = new Historical.Historical();
            Dictionary<string, int> proba = new Dictionary<string, int>();
            proba.Add("CODE_LIMITSET", 2);
            historical.ProveraPodataka(proba);
            Assert.IsTrue(historical.ProveraPodataka(proba));
        }

        [Test]
        public void provjeraPodatakaUspjesna5()
        {
            historical = new Historical.Historical();
            Dictionary<string, int> proba = new Dictionary<string, int>();
            proba.Add("CODE_SINGLENODE", 3);
            historical.ProveraPodataka(proba);
            Assert.IsTrue(historical.ProveraPodataka(proba));
        }

        [Test]
        public void provjeraPodatakaUspjesna6()
        {
            historical = new Historical.Historical();
            Dictionary<string, int> proba = new Dictionary<string, int>();
            proba.Add("CODE_MULTIPLENODE", 3);
            historical.ProveraPodataka(proba);
            Assert.IsTrue(historical.ProveraPodataka(proba));
        }

        [Test]
        public void provjeraPodatakaUspjesna7()
        {
            historical = new Historical.Historical();
            Dictionary<string, int> proba = new Dictionary<string, int>();
            proba.Add("CODE_CONSUMER", 4);
            historical.ProveraPodataka(proba);
            Assert.IsTrue(historical.ProveraPodataka(proba));
        }

        [Test]
        public void provjeraPodatakaUspjesna8()
        {
            historical = new Historical.Historical();
            Dictionary<string, int> proba = new Dictionary<string, int>();
            proba.Add("CODE_SOURCE", 4);
            historical.ProveraPodataka(proba);
            Assert.IsTrue(historical.ProveraPodataka(proba));
        }

        [Test]
        public void provjeraPodatakaUspjesna9()
        {
            historical = new Historical.Historical();
            Dictionary<string, int> proba = new Dictionary<string, int>();
            proba.Add("CODE_MOTION", 5);
            historical.ProveraPodataka(proba);
            Assert.IsTrue(historical.ProveraPodataka(proba));
        }

        [Test]
        public void provjeraPodatakaUspjesna10()
        {
            historical = new Historical.Historical();
            Dictionary<string, int> proba = new Dictionary<string, int>();
            proba.Add("CODE_SENSOR", 5);
            historical.ProveraPodataka(proba);
            Assert.IsTrue(historical.ProveraPodataka(proba));
        }


        //[Test]
        //public void upisaPodakaUBazu1()
        //{
        //    KeyValuePair<string, double> pair = new KeyValuePair<string, double>("CODE_ANALOG",22.4) ;
        //    Baza baza = new Baza();
        //    baza.UpisPodatakaUBazu("dataset_1", pair.Key, pair.Value);
        //}


        //[Test]
        //public void provjeraPodatakaNeuspjesna()
        //{
        //   historical = new Historical.Historical();
        //   Dictionary<string, int> proba = new Dictionary<string, int>();
        //   proba.Add("neki string", 1);
        //   Assert.Throws<ArgumentException>(
        //       () => historical.ProveraPodataka(proba)
        //       );
        //}
    }
}
