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
                    Console.WriteLine("Podaj tekst do odwr�cenia...");
                    Console.WriteLine($"{OdwrocTekst(Console.ReadLine())}"); //Du�o si� da zrobi� w jednej linii, troch� jak matematyka: od �rodka do zewn�trz
                    break;
                case 2:
                    Console.WriteLine("Podaj zdanie do odwr�cenia");
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
            //Wyra�enie regularne kt�re dopasuje si� tylko do formatu  YYYY-MM-DD
            string datePattern1 = @"^\d{4}-\d{2}-\d{2}$";
            Regex dateRegEx1 = new Regex(datePattern1);
            //Wyra�enie regularne kt�re dopasuje si� tylko do formatu DD/MM/YYYY
            string datePattern2 = @"^\d{2}\/\d{2}\/\d{4}$";
            Regex dateRegEx2 = new Regex(datePattern2);

            int ileDni = 0;

            DateTime dataUrodzenia = new DateTime();

            do
            {
                Console.WriteLine("Podaj dat� urodzenia w formacie YYYY-MM-DD lub DD/MM/YYYY");
                string input = Console.ReadLine();
                if (dateRegEx1.IsMatch(input) || dateRegEx2.IsMatch(input)) //testujemy wej�cie przeciwko naszym formatom �eby nic nam nie bru�dzi�o
                {
                    dataUrodzenia = DateTime.Parse(input);
                    if(dataUrodzenia.Year < DateTime.Now.Year || (dataUrodzenia.Year == DateTime.Now.Year && dataUrodzenia.DayOfYear < DateTime.Now.DayOfYear)) //Nie tolerujemy podr�nik�w w czasie
                        read = true;
                    else
                    {
                        Console.WriteLine("Data z przysz�o�ci");
                    }

                }
                else
                {
                    Console.WriteLine("Z�y format daty lub data z przysz�o�ci");
                }

            } while (!read);

            //DWA PRZYPADKI
            //Urodzony w innym roku:
            //Podliczamy dni od urodzenia do ko�ca roku narodzin, w tym sprawdzamy czy rok by� rokiem przest�pnym
            //DateTime.IsLeapYear(int) zwraca true je�eli rok wyra�ony parametrem jest przest�pny
            //dataUrodzenia.DayOfYear zwraca kt�rym dniem roku by�a data urodzenia
            if(dataUrodzenia.Year != DateTime.Now.Year)
            {
                ileDni += (DateTime.IsLeapYear(dataUrodzenia.Year) ? 366 : 365) - dataUrodzenia.DayOfYear;
            }
            else //Urodzony w tym samym roku
            {
                ileDni += DateTime.Now.DayOfYear - dataUrodzenia.DayOfYear;
            }

            for(int rok = dataUrodzenia.Year + 1; rok < DateTime.Now.Year; rok++) //skazczemy po latach �ycia od rokUrodzenia + 1 do teraz - 1 
            {
                for(int msc = 1; msc <= 12; msc++) //Dla ka�dego z tych lat skaczemy po miesi�cu
                {
                    ileDni += DateTime.DaysInMonth(rok, msc); //Funkcja, kt�ra zwraca ilo�� dni w miesi�cu w zale�no�ci od roku
                }
            }

            ileDni += (dataUrodzenia.Year != DateTime.Now.Year ? DateTime.Now.DayOfYear : 0); //Analogicznie jak w roku urodzenia

            Console.WriteLine($"Marnujesz tlen ju�: {ileDni} {(ileDni > 1 ? "dni" : "dzie�")}"); //odmienimy sobie s�owo dzie� przez liczb� bo czemu kurka nie
        }

    }
}
