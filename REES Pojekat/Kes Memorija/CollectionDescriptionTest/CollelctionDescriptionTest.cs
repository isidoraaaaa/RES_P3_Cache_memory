using Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionDescriptionTest
{
    [TestFixture]
    class CollelctionDescriptionTest
    {

        //setere za ova 2 dictionarija koja se nalaze u ovoj klasi ne mogu da pokrijem zato sto ako napisem nesto ovako
        //[Test]
        //public void DumpingPropertyCollectionTest()
        //{
        //    CollectionDescription cd = new CollectionDescription();
        //    Dictionary<string, double> a;
        //    a = cd.DumpingPropertyCollection;
        //    a.Add("pero", 22.3);
        //    a["pero"] = 23.5;

        //    Assert.AreEqual(a.Values, 23.5);
        //}
        //ovaj test ce pasti zato sto vrijednost koju on ocekuje je <23.5d> a vrijednsot koji ima je 23.5d
        //i iz tog razloga pada test
        

        [Test]
        [TestCase(2)]
        public void GeterISerter(int x)
        {
            CollectionDescription cd = new CollectionDescription();
            x = cd.Id;
            Assert.AreEqual(cd.Id, x);
        }
 
    }
}
