using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Moq;
using DumpingBufferKomponenta;

namespace DumpingBufferTest
{
    [TestFixture]
    class DumpingBufferTest
    {
        //******************NAPOEMENA***********************
        //OVAJ KOMPONENTA NE MOZE DA SE TESTIRA TAKO DA JE ISKLJUCENA IZ CODE CEVERAGA


        //DumpingBuffer db;
        //IPodatak p;
        //IPodatak pp;

        //[SetUp]
        //public void SetUp()
        //{
        //    var moq = new Mock<IPodatak>();
        //    var moq2 = new Mock<IPodatak>();
        //    moq.Setup(p => p.Kod).Returns("pogresan kod");
        //    p = moq.Object;

        //    moq2.Setup(p => p.Kod).Returns("CODE_ANALOG");
        //    pp = moq2.Object;
        //}

        ////Lose parametre za automatsko slanje ne mogu da testiram posto switch uzima broj koji se random generise i intervalu 1-10 i nikad nece biti los broj
        ////Pokrivensot koda za autoamtsko ce biti losa zato sto onda uzima random vrijednsot od 1 do 10 i onda ce izgledati
        ////kao da je samo 1 slucaj pokriven, ali zapravo su pokriveni svi
        //[Test]
        //public void automatskoSlanjeDobarParametar()
        //{
        //    db = new DumpingBuffer();
        //    db.automatskiUDumpingBuffer();
        //}

        //[Test]
        //public void manuelnoSlanjeDobarKod1()
        //{
        //    db = new DumpingBuffer();
        //    db.manuelnoUDumpingBuffer(new Podatak(pp.Kod, 222.333, DateTime.Now));
        //}

        //[Test]
        //public void manuelnoSlanjeDobarKod2()
        //{
        //    db = new DumpingBuffer();
        //    db.manuelnoUDumpingBuffer(new Podatak("CODE_DIGITAL", 222.333, DateTime.Now));
        //}

        //[Test]
        //public void manuelnoSlanjeDobarKod3()
        //{
        //    db = new DumpingBuffer();
        //    db.manuelnoUDumpingBuffer(new Podatak("CODE_CUSTOM", 222.333, DateTime.Now));
        //}

        //[Test]
        //public void manuelnoSlanjeDobarKod4()
        //{
        //    db = new DumpingBuffer();
        //    db.manuelnoUDumpingBuffer(new Podatak("CODE_LIMITSET", 222.333, DateTime.Now));
        //}

        //[Test]
        //public void manuelnoSlanjeDobarKod5()
        //{
        //    db = new DumpingBuffer();
        //    db.manuelnoUDumpingBuffer(new Podatak("CODE_SINGLENODE", 222.333, DateTime.Now));
        //}

        //[Test]
        //public void manuelnoSlanjeDobarKod6()
        //{
        //    db = new DumpingBuffer();
        //    db.manuelnoUDumpingBuffer(new Podatak("CODE_MULTIPLENODE", 222.333, DateTime.Now));
        //}

        //[Test]
        //public void manuelnoSlanjeDobarKod7()
        //{
        //    db = new DumpingBuffer();
        //    db.manuelnoUDumpingBuffer(new Podatak("CODE_CONSUMER", 222.333, DateTime.Now));
        //}

        //[Test]
        //public void manuelnoSlanjeDobarKod8()
        //{
        //    db = new DumpingBuffer();
        //    db.manuelnoUDumpingBuffer(new Podatak("CODE_SOURCE", 222.333, DateTime.Now));
        //}

        //[Test]
        //public void manuelnoSlanjeDobarKod9()
        //{
        //    db = new DumpingBuffer();
        //    db.manuelnoUDumpingBuffer(new Podatak("CODE_MOTION", 222.333, DateTime.Now));
        //}


        //[Test]
        //public void manuelnoSlanjeDobarKod10()
        //{
        //    db = new DumpingBuffer();
        //    db.manuelnoUDumpingBuffer(new Podatak("CODE_SENSOR", 222.333, DateTime.Now));
        //}

        //[Test]
        //public void manuelnoSlanjeLosKod()
        //{
        //    db = new DumpingBuffer();
            
        //    Assert.Throws<LosKodArgumentException>(             
        //        () => db.manuelnoUDumpingBuffer(new Podatak(p.Kod, 22.33, DateTime.Now))
        //        );
        //}

    }
}
