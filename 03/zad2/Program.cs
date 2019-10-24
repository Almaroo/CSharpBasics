using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_3
{
    public enum Plcie //enum przechowujący płcie
    {
        K=0,
        M=1
    };

    class Program
    {
        static void Main(string[] args)
        {
            //Osoba osoba = new Osoba() -> wyrzuci błąd ponieważ NIE MOŻNA TWORZYĆ INSTANCJI KLASY ABSTRAKCYJNEJ!
            KierownikZespolu adam = new KierownikZespolu("Adam", "Kowalski", "1990/07/01", "90070100211", Plcie.M, 5);

            CzlonekZespolu beata = new CzlonekZespolu("Beata", "Nowak", "1992/10/22", "92102201347", Plcie.K, "projektant");
            CzlonekZespolu jan = new CzlonekZespolu("Jan", "Janowski", "1992/03/15", "92031507772", Plcie.M, "programista");

            Console.WriteLine(beata.ToString());
            Console.WriteLine(jan.ToString());
            Console.WriteLine(adam.ToString());

            Console.ReadKey();
        }
    }
}
