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
            Osoba beata = new Osoba("Beata", "Nowak", "1992/10/22", "92102201347", Plcie.K); //tworzymy instancje klasy osoba poprzez wywołanie jednego z konstruktorów
            Osoba jan = new Osoba("Jan", "Janowski", "1992/03/15", "92031507772", Plcie.M);

            Console.WriteLine(beata.ToString());
            Console.WriteLine(jan.ToString());

            Console.ReadKey();
        }
    }
}
