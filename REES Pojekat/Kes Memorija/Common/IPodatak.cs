using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface IPodatak
    {
        string Kod { get; set; }
        double Vrijednost { get; set; }
        DateTime Vrijeme { get; set; }
    }
}
