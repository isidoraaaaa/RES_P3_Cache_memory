using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [DataContract]
    public class Podatak
    {
        string kod;
        double vrijednost;
        DateTime vrijeme;

        [DataMember]
        public string Kod { get { return kod; } set { kod = value; } }
        [DataMember]
        public double Vrijednost { get { return vrijednost; } set { vrijednost = value; } }
        [DataMember]
        public DateTime Vrijeme { get { return vrijeme; } set { vrijeme = value; } }

        public Podatak()
        {
            Kod = "";
            Vrijednost = 0;
            Vrijeme = DateTime.Now;
        }

        public Podatak(string kod,double vrijednost,DateTime vrijeme)
        {
            Kod = kod;
            Vrijednost = vrijednost;
            Vrijeme = vrijeme;
        }

        public override string ToString()
        {
            return "Kod " + Kod + " sa vriejdnoscu " + Vrijednost.ToString() + " je poslata " + Vrijeme; 
        }
    }
}
