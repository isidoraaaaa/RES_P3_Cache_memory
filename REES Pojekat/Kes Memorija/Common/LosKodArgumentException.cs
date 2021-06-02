using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
   public class LosKodArgumentException : Exception
    {
        public LosKodArgumentException(string poruka) : base(poruka) { }
        public LosKodArgumentException() : this("Nepostojeci kod!") { }
    }
}
