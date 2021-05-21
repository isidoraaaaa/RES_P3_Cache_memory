using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
namespace DumpingBufferKomponenta
{
    public class DumpingBuffer : IDumpingBuffer
    {
        int brojac = 0;
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
        double vrijednost = 0.0;
        Random random = new Random();

        public void automatskiUDumpingBuffer()
        {
            brojac++;
            switch (brojac)
            {
                case 1:
                    Console.WriteLine(kodAnalog);
                    vrijednost = random.NextDouble()*(1000.0 - 0.1) + 0.1;
                    vrijednost = (double)System.Math.Round(vrijednost, 2);
                    Console.WriteLine($"Vrijednost signala = {vrijednost}");
                    break;
                case 2:
                    Console.WriteLine(kodDigital);
                    vrijednost = random.NextDouble() * (1000.0 - 0.1) + 0.1;
                    vrijednost = (double)System.Math.Round(vrijednost, 2);
                    Console.WriteLine($"Vrijednost signala = {vrijednost}");
                    break;
                case 3:
                    Console.WriteLine(kodCustom);
                    vrijednost = random.NextDouble() * (1000.0 - 0.1) + 0.1;
                    vrijednost = (double)System.Math.Round(vrijednost, 2);
                    Console.WriteLine($"Vrijednost signala = {vrijednost}");
                    break;
                case 4:
                    Console.WriteLine(kodLimitset);
                    vrijednost = random.NextDouble() * (1000.0 - 0.1) + 0.1;
                    vrijednost = (double)System.Math.Round(vrijednost, 2);
                    Console.WriteLine($"Vrijednost signala = {vrijednost}");
                    break;
                case 5:
                    Console.WriteLine(kodSinglenoe);
                    vrijednost = random.NextDouble() * (1000.0 - 0.1) + 0.1;
                    vrijednost = (double)System.Math.Round(vrijednost, 2);
                    Console.WriteLine($"Vrijednost signala = {vrijednost}");
                    break;
                case 6:
                    Console.WriteLine(kodMultiplenode);
                    vrijednost = random.NextDouble() * (1000.0 - 0.1) + 0.1;
                    vrijednost = (double)System.Math.Round(vrijednost, 2);
                    Console.WriteLine($"Vrijednost signala = {vrijednost}");
                    break;
                case 7:
                    Console.WriteLine(kodConsumer);
                    vrijednost = random.NextDouble() * (1000.0 - 0.1) + 0.1;
                    vrijednost = (double)System.Math.Round(vrijednost, 2);
                    Console.WriteLine($"Vrijednost signala = {vrijednost}");
                    break;
                case 8:
                    Console.WriteLine(kodSource);
                    vrijednost = random.NextDouble() * (1000.0 - 0.1) + 0.1;
                    vrijednost = (double)System.Math.Round(vrijednost, 2);
                    Console.WriteLine($"Vrijednost signala = {vrijednost}");
                    break;
                case 9:
                    Console.WriteLine(kodMotion);
                    vrijednost = random.NextDouble() * (1000.0 - 0.1) + 0.1;
                    vrijednost = (double)System.Math.Round(vrijednost, 2);
                    Console.WriteLine($"Vrijednost signala = {vrijednost}");
                    break;
                case 10:
                    Console.WriteLine(kodSensor);
                    vrijednost = random.NextDouble() * (1000.0 - 0.1) + 0.1;
                    vrijednost = (double)System.Math.Round(vrijednost, 2);
                    Console.WriteLine($"Vrijednost signala = {vrijednost}");
                    break;
                case 11:
                    brojac = 0;
                    break;
                default:
                    brojac = 0;
                    break;
            }

        }

        public void manuelnoUDumpingBuffer(Podatak p)
        {
            Console.WriteLine(p);
        }
    }
}
