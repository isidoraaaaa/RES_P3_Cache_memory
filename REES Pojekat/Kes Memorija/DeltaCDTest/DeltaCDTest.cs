using Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeltaCDTest
{
    [TestFixture]
    class DeltaCDTest
    {
        [Test]
        public void RemoveGeterISerter()
        {
            DeltaCD deltaCD = new DeltaCD();
            CollectionDescription cd = new CollectionDescription();
            deltaCD.Remove = cd;
            Assert.AreEqual(deltaCD.Remove, cd);
        }
    }
}
