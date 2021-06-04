using Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DescriptionTest
{
    [TestFixture]
    class DescriptionTest
    {
        [Test]
        public void DescriptionID()
        {
            Description d = new Description();
            d.Id = 5;
            int x = d.Id;
            Assert.AreEqual(d.Id, 5);
        }

        [Test]
        public void Lista()
        {
            Description d = new Description();
            List<Dictionary<string, double>> lista = new List<Dictionary<string, double>>();
            Dictionary<string, double> x = new Dictionary<string, double>();
            x.Add("pero", 2.3);
            lista.Add(x);
            d.ListHistoricalPropertys = lista;
            Assert.AreEqual(d.ListHistoricalPropertys, lista);
        }
    }
}
