using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_04
{
    public enum Plcie //enum przechowujący płcie
    {
        K = 0,
        M = 1
    };

    class Program
    {
        static void Main(string[] args)
        {
            //Osoba osoba = new Osoba() -> wyrzuci błąd ponieważ NIE MOŻNA TWORZYĆ INSTANCJI KLASY ABSTRAKCYJNEJ!

            KierownikZespolu adam = new KierownikZespolu("Adam", "Kowalski", "1990/07/01", "90070100211", Plcie.M, 5);
            CzlonekZespolu beata = new CzlonekZespolu("Beata", "Nowak", "1992/10/22", "92102201347", Plcie.K, "programista");
            CzlonekZespolu jan = new CzlonekZespolu("Jan", "Janowski", "1992/03/15", "92031507772", Plcie.M, "programista");

            Zespol zespolR = new Zespol("Zespół R", adam);
            zespolR.DodajCzlonka(beata);
            zespolR.DodajCzlonka(jan);

            /*Console.WriteLine(beata.ToString());
            Console.WriteLine(jan.ToString());
            Console.WriteLine(adam.ToString());*/
            Console.WriteLine(zespolR.ToString());

            List<CzlonekZespolu> lista = zespolR.WyszukajFunkcje("programista");

            Console.WriteLine("\n\n\nCzłonkowie zespołu o funkcji programista:");
            foreach(CzlonekZespolu cz in lista)
            {
                Console.WriteLine(cz.ToString());
            }

            Console.ReadKey();
        }
    }
}