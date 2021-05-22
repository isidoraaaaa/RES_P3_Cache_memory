using Common;
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
         
        [Test]
        [TestCase("CODE_ANALOG",22.5)]
        [TestCase("CODE_DIGITAL",555.3)]
        [TestCase("cOdE_DiGITal",22.893)]
        public void PodatakSaDobrimParametrimaBezDatuma(string kod,double vrijednost)
        {
            Podatak p = new Podatak(kod, vrijednost);
            Assert.AreEqual(p.Kod,kod);
            Assert.AreEqual(p.Vrijednost, vrijednost);
        }

        [Test]
        [TestCase("pera",123.234)]
        [ExpectedException(typeof(ArgumentException))]
        public void PodatakSaLosimParametrimaBezDatuma(string kod,double vrijednost)
        {
            Podatak p = new Podatak(kod, vrijednost);
        }

        [Test]
        [TestCase("CODE_ANALOG",2343.24,"2021/05/22")]
        [TestCase("CODE_DIGITAL",8473.2355,"1998/07/23")]

        public void PodatakSaDobrimParametrimaSaDatumom(string kod,double vrijednost,DateTime datum)
        {
            Podatak p = new Podatak(kod, vrijednost, datum);
            Assert.AreEqual(p.Kod, kod);
            Assert.AreEqual(p.Vrijednost, vrijednost);
            Assert.AreEqual(p.Vrijeme, datum.Date);
        }


        //ovaj test dole trenutno ne prolazi zato sto treba ubaciti logiku za provjeru datuma
        [Test]
        [TestCase("CODE_ANALOG",2354.23,"1231231/2323/23232")]
        [ExpectedException(typeof(ArgumentException))]
        public void PodatakSaLosimParametrimaSaDatumom(string kod, double vrijednost, DateTime datum)
        {
            Podatak p = new Podatak(kod, vrijednost, datum);

        }
    }
}
