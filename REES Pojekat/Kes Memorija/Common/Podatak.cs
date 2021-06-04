using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public enum NazivKoda { CODE_ANALOG, CODE_DIGITAL, CODE_CUSTOM, CODE_LIMITSET, CODE_SINGLENODE, CODE_MULTIPLENODE, CODE_CONSUMER, CODE_SOURCE, CODE_MOTION, CODE_SENSOR }
    [DataContract]
    public class Podatak : IPodatak
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

        public Podatak(string kod, double vrijednost, DateTime vrijeme)
        {
            if (kod.ToUpper() != NazivKoda.CODE_ANALOG.ToString()       &&
                kod.ToUpper() != NazivKoda.CODE_DIGITAL.ToString()      &&
                kod.ToUpper() != NazivKoda.CODE_CUSTOM.ToString()       &&
                kod.ToUpper() != NazivKoda.CODE_LIMITSET.ToString()     &&
                kod.ToUpper() != NazivKoda.CODE_SINGLENODE.ToString()    &&
                kod.ToUpper() != NazivKoda.CODE_MULTIPLENODE.ToString() &&
                kod.ToUpper() != NazivKoda.CODE_CONSUMER.ToString()     &&
                kod.ToUpper() != NazivKoda.CODE_SOURCE.ToString()       &&
                kod.ToUpper() != NazivKoda.CODE_MOTION.ToString()       &&
                kod.ToUpper() != NazivKoda.CODE_SENSOR.ToString())
            {
                throw new LosKodArgumentException();
            }
            else
            {
                Kod = kod;
            }
            //ZA DATUM I VRIJEDNOST NISAM PRAVIO PROVJERE JER NE MOZES UNIJETI STRING ZA BROJ,A DATUM SVAKAKO AUTOMATSKI KUPI TRENUTNI DATUM
            //TAKO DA NI TU NE MOZE BITI GRESKE TIPA NE MOZES POGRESAN FORMAT UNIJETI JER TO DATETIME OBAVLJA UMJESTO TEBE
            Vrijednost = vrijednost;
            Vrijeme = vrijeme;
        }
        public override string ToString()
        {
            return "Kod " + Kod + " sa vriejdnoscu " + Vrijednost.ToString() + " je poslata " + Vrijeme;
        }
    }
}
