using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PO_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj numer zadania...");
            int n = Int32.Parse(Console.ReadLine());
            switch (n)
            {
                case 1:
                    Console.WriteLine("Podaj tekst do odwrócenia...");
                    Console.WriteLine($"{OdwrocTekst(Console.ReadLine())}"); //Du¿o siê da zrobiæ w jednej linii, trochê jak matematyka: od œrodka do zewn¹trz
                    break;
                case 2:
                    Console.WriteLine("Podaj zdanie do odwrócenia");
                    Console.WriteLine($"{OdwrocZdanie(Console.ReadLine())}");
                    break;
                case 3:
                    Dni();
                    break;
                default:
                    Console.WriteLine("Nie ma takiego zadania");
                    break;
            }
            Console.ReadKey();
        }

        static string OdwrocTekst(string tekst)
        {
            string ret = "";
            for(int i = 0; i < tekst.Length; i++)
            {
                ret += tekst[tekst.Length - 1 - i];
            }

            return ret;
        }

        static string OdwrocZdanie(string zdanie)
        {
            string ret = "";

            var zdaniePodzielone = zdanie.Split(' ');

            for(int i = zdaniePodzielone.Length - 1; i >= 0; i--) //lecimy od ostatniego do pierwszego
            {
                ret += zdaniePodzielone[i];
                if(i > 0) //po ostatnim nie chcemy spacji
                {
                    ret += " ";
                }
            }


            return ret;
        }

        static void Dni()
        {
            bool read = false;
            //Wyra¿enie regularne które dopasuje siê tylko do formatu  YYYY-MM-DD
            string datePattern1 = @"^\d{4}-\d{2}-\d{2}$";
            Regex dateRegEx1 = new Regex(datePattern1);
            //Wyra¿enie regularne które dopasuje siê tylko do formatu DD/MM/YYYY
            string datePattern2 = @"^\d{2}\/\d{2}\/\d{4}$";
            Regex dateRegEx2 = new Regex(datePattern2);

            int ileDni = 0;

            DateTime dataUrodzenia = new DateTime();

            do
            {
                Console.WriteLine("Podaj datê urodzenia w formacie YYYY-MM-DD lub DD/MM/YYYY");
                string input = Console.ReadLine();
                if (dateRegEx1.IsMatch(input) || dateRegEx2.IsMatch(input)) //testujemy wejœcie przeciwko naszym formatom ¿eby nic nam nie bruŸdzi³o
                {
                    dataUrodzenia = DateTime.Parse(input);
                    if(dataUrodzenia.Year < DateTime.Now.Year || (dataUrodzenia.Year == DateTime.Now.Year && dataUrodzenia.DayOfYear < DateTime.Now.DayOfYear)) //Nie tolerujemy podró¿ników w czasie
                        read = true;
                    else
                    {
                        Console.WriteLine("Data z przysz³oœci");
                    }

                }
                else
                {
                    Console.WriteLine("Z³y format daty lub data z przysz³oœci");
                }

            } while (!read);

            //DWA PRZYPADKI
            //Urodzony w innym roku:
            //Podliczamy dni od urodzenia do koñca roku narodzin, w tym sprawdzamy czy rok by³ rokiem przestêpnym
            //DateTime.IsLeapYear(int) zwraca true je¿eli rok wyra¿ony parametrem jest przestêpny
            //dataUrodzenia.DayOfYear zwraca którym dniem roku by³a data urodzenia
            if(dataUrodzenia.Year != DateTime.Now.Year)
            {
                ileDni += (DateTime.IsLeapYear(dataUrodzenia.Year) ? 366 : 365) - dataUrodzenia.DayOfYear;
            }
            else //Urodzony w tym samym roku
            {
                ileDni += DateTime.Now.DayOfYear - dataUrodzenia.DayOfYear;
            }

            for(int rok = dataUrodzenia.Year + 1; rok < DateTime.Now.Year; rok++) //skazczemy po latach ¿ycia od rokUrodzenia + 1 do teraz - 1 
            {
                for(int msc = 1; msc <= 12; msc++) //Dla ka¿dego z tych lat skaczemy po miesi¹cu
                {
                    ileDni += DateTime.DaysInMonth(rok, msc); //Funkcja, która zwraca iloœæ dni w miesi¹cu w zale¿noœci od roku
                }
            }

            ileDni += (dataUrodzenia.Year != DateTime.Now.Year ? DateTime.Now.DayOfYear : 0); //Analogicznie jak w roku urodzenia

            Console.WriteLine($"Marnujesz tlen ju¿: {ileDni} {(ileDni > 1 ? "dni" : "dzieñ")}"); //odmienimy sobie s³owo dzieñ przez liczbê bo czemu kurka nie
        }

    }
}
