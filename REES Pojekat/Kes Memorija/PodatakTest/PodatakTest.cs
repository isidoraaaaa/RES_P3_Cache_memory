using Common;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodatakTest
{
    [TestFixture]
    class PodatakTest
    {
        IPodatak podatakDobar;
        IPodatak podatakLos;
        IPodatak prazan;
        [SetUp]
        public void SetUp()
        {
            var moq = new Mock<IPodatak>();
            var moq2 = new Mock<IPodatak>();
            var moq3 = new Mock<IPodatak>();
            moq.Setup(p => p.Kod).Returns("CODE_ANALOG");
            podatakDobar = moq.Object;

            moq2.Setup(p => p.Kod).Returns("neki kod");  
            podatakLos = moq2.Object;

            moq3.Setup(p => p.Kod).Returns("");
            moq.Setup(p => p.Vrijednost).Returns(0);
            moq.Setup(p => p.Vrijeme).Returns(DateTime.Now);
            prazan = moq3.Object;
        }


       

        [Test]
        public void PrazanKounstruktor()
        {
            Podatak p = new Podatak();
            Assert.AreEqual(prazan.Kod, p.Kod);
            Assert.AreEqual(prazan.Vrijednost, p.Vrijednost);
           //datum nisam poredio zato sto kod mokovanog objekta datum se postavi na 0001/01/01
           
        }

        [Test]
        [TestCase(22.3,"06/07/1998")]
        public void Proba(double a,DateTime dt)
        {
           Podatak p = new Podatak(podatakDobar.Kod, a, dt);
           Assert.AreEqual(p.Kod, podatakDobar.Kod);
           Assert.AreEqual(p.Vrijednost, a);
           Assert.AreEqual(p.Vrijeme, dt);
        }


       
      

        [Test]
        [TestCase("CODE_ANALOG", 22.5, "06/07/1998")]
        [TestCase("CODE_DIGITAL", 555.3, "06/08/1999")]
        [TestCase("cOdE_DiGITal", 22.893, "06/09/2000")]
        [TestCase("CODE_CUSTOM", 55.23, "06/10/2001")]
        [TestCase("CODE_LIMITSET", 44.1234, "06/11/2002")]
        [TestCase("CODE_SINGLENODE", 99.865, "06/12/2003")]
        [TestCase("CODE_MULTIPLENODE", 123.234, "07/07/2004")]
        [TestCase("CODE_CONSUMER", 876.239, "07/16/2005")]
        [TestCase("CODE_SOURCE", 54.23, "06/11/2006")]
        [TestCase("CODE_MOTION", 764.232, "09/11/2007")]
        [TestCase("CODE_SENSOR", 123.333, "03/09/2008")]
        [TestCase("CoDe_CuSTOm", 1222.345, "04/12/2009")]
        [TestCase("cODe_LIMITset", 123.3322, "09/13/2010")]
        [TestCase("CODE_singlenode", 77.23, "05/05/2011")]
        [TestCase("COde_MULTIpleNoDe", 2323.33344, "07/24/2012")]
        [TestCase("code_consumer", 22.33, "06/07/2013")]
        [TestCase("code_SOURCe", 1.23, "04/13/2014")]
        [TestCase("COdE_MOtioN", 2.33, "12/03/2015")]
        [TestCase("code_sensoR", 22.44444, "10/02/2016")]
        [TestCase("code_ANALog", 22.33333, "01/01/2017")]
        public void PodatakSaDobrimParametrima(string kod, double vrijednost, DateTime datum)
        {
            Podatak p = new Podatak(kod, vrijednost, datum);
            Assert.AreEqual(p.Kod, kod);
            Assert.AreEqual(p.Vrijednost, vrijednost);
            Assert.AreEqual(p.Vrijeme, datum.Date);
        }


        //NAPOENA ZA DATUM, POSTO GA PROSLEDJUJEMO KAO DATETIME NE MORAMO DA IMAMO PROVJERU DA LI SMO PRAVILNO UNIJELI DATUM JER
        //GA NE UNOSIMO KAO STRING
        //E SAD JEDINO JE TREBALO VODITI RACUNA PRILIKOM PISANJA TESTOVA JER DATUM MORA BITI OBLIKA MM//dd//yyyy

        [Test]
        [TestCase("hmmm", 222.22, "03/05/1995")]
        public void PodatakSaLosimParamterima(string kod, double vrijednost, DateTime datum)
        {
            Assert.Throws<LosKodArgumentException>(
               () =>
               {
                   Podatak p = new Podatak(kod, vrijednost, datum);
               }
               );
        }


       
    }
}
