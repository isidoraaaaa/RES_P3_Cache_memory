using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [DataContract]
    public class Podatak : IPodatak
    {
        string kod;
        double vrijednost;
        DateTime vrijeme;

        string kodAnalog = "CODE_ANALOG";
        string kodDigital = "CODE_DIGITAL";
        string kodCustom = "CODE_CUSTOM";
        string kodLimitset = "CODE_LIMITSET";
        string kodSinglenoe = "CODE_SINGLENOE";
        string kodMultiplenode = "CODE_MULTIPLENODE";
        string kodConsumer = "CODE_CONSUMER";
        string kodSource = "CODE_SOURCE";
        string kodMotion = "CODE_MOTION";
        string kodSensor = "CODE_SENSOR";

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
            if (kod.ToUpper() != kodAnalog && kod.ToUpper() != kodDigital && kod.ToUpper() != kodCustom && kod.ToUpper() != kodLimitset &&
              kod.ToUpper() != kodSinglenoe && kod.ToUpper() != kodMultiplenode && kod.ToUpper() != kodConsumer && kod.ToUpper() != kodSource && kod.ToUpper() != kodMotion && kod.ToUpper() != kodSensor)
            {
                throw new ArgumentException("Pogresan kod!");
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
