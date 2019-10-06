using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PO_01
{
    class Program
    {
        static void Main(string[] args)
        {
            //Witaj();
            //Liczby();
            //Figura();
            //Kalkulator();
            //Tablica();

            //Konstrukcja try{}catch{} służy do tego, że gdy np: tablica ma n elementów, a my odwołamy się do n+1 to C# wyrzuci nam wyjątek, który (brzydko mówiąc) wyjebie program w kosmos.
            //Jeżeli fragment kodu, który wrzucał wyjątek znajdował się w try{} możemy OBSŁUŻYĆ WYJĄTEK, który łapiemuy w instrukcji catch(Exception e){}.
            //Za pomocą zmiennej e typu Exception mamy dostęp np. do typu, wiadomości i innych dotyczących wyjątku

            //Kilka bardzo podatnych na wyjątki sytuacji to NullPointer, FileNotFound i IndexOutOfBounds

            try
            {
                Console.WriteLine(Odwrotnosc(0.5));
                Console.WriteLine(Odwrotnosc(0));
            }
            catch(Exception e)
            {
                Console.WriteLine($"{e.GetType()}: {e.Message}");
                //W tym wypadku:
                //System.ArithmeticException: Błąd dzielenia przez zero
            }

            //sposób na podanie wartości do tablicy bezpośrednio przy tworzeniu jej
            int[] tablica = { 1, 1, 1, 1, 2, 3, 3 };
            Console.WriteLine($"IleRazy: {IleRazy(tablica, 1)}");

            int[] wynikOdwrocenia = Odwroc(tablica);
            foreach(int liczba in wynikOdwrocenia)
            {
                Console.WriteLine($"{liczba}");
            }

            Console.ReadKey();
        }

        //Wszystkie funkcje (ładniej metody klasy, bo jesteśmy w klasie Program) muszą mieć przed zwracanym typem słowo kluczowe STATIC. Bez tego nie jesteśmy w stanie ich wołać bez tworzenia instancji klasy
        
        //Przykład tworzenia instancji:
        //int[] mojaTablica = new int[dlugoscTablicy]; -> tworzymy tablice o dlugosci rownej dlugoscTablicy
        //jest to pewna instancja klasy Array, dzięki czemu mamy dostęp do metod typu mojaTablica.Reverse() czy mojaTablica.Sum()
        //Bez stworzenia instancji klasy nie mamy dostepu do tych metod
        
            
        //Przykład bez tworzenia instancji:
        //Bardzo popularne klasa metod statycznych to Math
        //np. Math.abs(), Math.sin(), Convert.ToInt32() etc
        //Metody te możemy wołać mimo że nie pisaliśmy nigdzie:
        //Math zmienna = new Math();


        static void Witaj()
        {
            Console.WriteLine("Podaj swoje imię...");
            string imie = Console.ReadLine();

            //Lepszy sposób do zapisania
            //Console.WriteLine("Witaj " + imie);
            //Jeżeli stworzymy string: $"" to wewnątrz za pomocą nawiasów: {} możemy ewaluować zmienne i wyrażenia np: {imie} w tym przypadku zwróci po prostu wartość zmiennej imie typu string, {2 + 2} zwróci 4 etc. 
            Console.WriteLine($"Witaj {imie}");
            
        }

        static void Liczby()
        {
            float srednia;
            int suma = 0;
            int min = Int32.MaxValue;
            int max = Int32.MinValue;
            int x;
            int n;

            //Fajny trik, który będzie kazał powtórzyć wprowadzenie liczby aż spełni ona wymagania

            Console.WriteLine("Podaj liczbę n ...");
            do
            {
                n = Convert.ToInt32(Console.ReadLine());
                if(n <= 0)
                    Console.WriteLine("n musi być większe od zera ...");
            } while (n <= 0);
            



            for(int i = 0; i < n; i++)
            {
                x = Convert.ToInt32(Console.ReadLine());
                suma += x;

                if (x < min)
                    min = x;
                if (x > max)
                    max = x;
            }

            srednia = (float)suma / (float)n;

            Console.WriteLine($"Suma: {suma}\nŚrednia: {srednia:0.00}\nMax: {max}\nMin: {min}");

        }

        static void Figura()
        {
            int n;

            Console.WriteLine("Podaj liczbe n większą lub równą 3 ...");
            do
            {
                n = Convert.ToInt32(Console.ReadLine());
                if (n < 3)
                    Console.WriteLine("n musi być większa lub równa 3 ...");
            } while (n < 3);

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    //i == 0 || i == n - 1 -> Warunki na obudowę poziomo
                    //j == 0 || j == n - 1 -> Warunki na obudowę pionowo
                    //i == j -> Warunek na przekątną lewa góra - prawy dół
                    //n - i - j - 1 == 0 -> Warunek na przekątną prawa góra - lewy dół
                    if (i == 0 || i == n - 1 || j == 0 || j == n - 1 || i == j || n - i - j - 1 == 0)
                    {
                        Console.Write(" # ");
                    }
                    else
                        Console.Write("   ");
                }
                Console.WriteLine('\n');
            }

        }

        static void Kalkulator()
        {
            double[] liczby = new double[2];
            char znak;
            string tmp;
            double wynik = 0;

            //Nie miałem lepszego pomysłu xddd
            string patternLiczba = @"[+-]?\d+(?:[,.]\d+)?";
            //Wzór:
            // [+-]? -> jedno lub brak wystąpień + albo -
            //\d+ -> minimum jedno wystąpienie cyfry
            //(?:    )? ->zero lub jedna grupa nieprzechwytująca (spoko też nie wiem po co to)
            //[,.] albo przecinek albo kropka
            //\d+ -> minimum jedna cyfra
            string patternZnak = @"[\+\-\*\/]";
            //tu łatwiej
            //+ albo - albo * albo / (przed każdym dałem \ bo nie wiedziałem czy nie mają jakiś specjalnych zastosowań, a znak '\' jest ZNAKIEM UCIECZKI, czyli wszystko jest traktowane dosłownie)

            //Tworzenie wyrażeń regularnych na podstawie wyżej określonych wzorów
            //WAŻNE żeby używać Regex trzeba dodać:
            //using System.Text.RegularExpressions;

            Regex rgxLiczba = new Regex(patternLiczba);
            Regex rgxZnak = new Regex(patternZnak);

            string input = Console.ReadLine();

            //metoda szukająca dopasowań do danego wzoru w zmiennej input

            //var znaczy tyle, że nie wiemy jakiego typu będzie zmienna
            //prawdopodobnie nie jest to najbardziej eleganckie i zasobooszczędne, ale działa
            var wynikZnak = rgxZnak.Match(input);
            var wynikLiczba = rgxLiczba.Matches(input);

            //W przypadku gdy pracujesz w VS gdy nie wiesz co robi dana funkcja, po prostu na nią najedź, a na 90% pojawi się opis działania
            //plus na pewno będzie powiedziane jakie parametry funkcja przyjmuje i jaka jest wartość zwracana

            //Funkcja zewnętrzna zmienia wartość zwracaną wewnętrznej do stringa
            //Funkcja wewnętrzna zwraca podciąg ciągu input o długości wynikZnak.Length zaczynając od wynikZnak.Index
            //wynikZnak jest obiektem, który ma różne metody(funkcje) i pola(zmienne). Najwięcej się można o nich dowiedzieć albo z docs.microsoft.com albo poprzez debugowanie i podejrzenie wartości zmiennej
            znak = Convert.ToChar(input.Substring(wynikZnak.Index, wynikZnak.Length));

            for(int i = 0; i < wynikLiczba.Count; i++)
            {
                tmp = input.Substring(wynikLiczba[i].Index, wynikLiczba[i].Length);
                //Sprawdzamy czy podciąg tmp zawiera '.'
                if(tmp.Contains('.'))
                {
                    //Jeżeli tak to wymieniamy go na ','
                    tmp = tmp.Replace('.', ',');
                }
                //Robimy to dlatego, że w tym miejscu metoda ToDouble() wyrzuca wyjątek, gdy dostanie stringa zawierającego '.'
                liczby[i] = Convert.ToDouble(tmp);
            }

            switch(znak)
            {
                case '+':
                    wynik = liczby[0] + liczby[1];
                    break;
                case '-':
                    wynik = liczby[0] - liczby[1]; 
                    break;
                case '*':
                    wynik = liczby[0] * liczby[1];
                    break;
                case '/':
                    //Nie było o tym mowy w zadaniu ale to eleganckie. Patrz zadanie 6
                    if (liczby[1] == 0)
                        throw new ArithmeticException("Dzielnik nie może być zerem");
                    else
                    {
                        wynik = liczby[0] / liczby[1];
                    }
                    break;
                default:
                    Console.WriteLine("Wprowadzono zły znak...");
                    break;
            }

         
            Console.WriteLine($"{liczby[0]:000.000}\n{znak}\n{liczby[1]:000.000}\n{'='}\n{wynik:000.000}");
        }

        static void Tablica()
        {
            int n;
            int parzyste = 0;
            int nieparzyste = 0;
            int dodatnie = 0;
            int ujemne = 0;

            //Tworzymy instancję klasy Random o nazwie rnd
            Random rnd = new Random();

            Console.WriteLine("Podaj liczbę n ...");
            do
            {
                n = Convert.ToInt32(Console.ReadLine());
                if (n <= 0)
                    Console.WriteLine("n musi być większe od zera ...");
            } while (n <= 0);

            int[] tablica = new int[n];

            for(int i = 0; i < n; i++)
            {
                //używamy metody .Next(dolnaWartość, górnaWartość)
                tablica[i] = rnd.Next(-100, 100);

                if (tablica[i] % 2 == 0)
                    parzyste++;
                else
                    nieparzyste++;

                if (tablica[i] < 0)
                    ujemne++;
                else if (tablica[i] > 0)
                    dodatnie++;

                Console.WriteLine($"{i + 1}: {tablica[i]}");
            }

            Console.WriteLine($"Parzyste: {parzyste}\tNieparzyste: {nieparzyste}\nDodatnie: {dodatnie}\tUjemne: {ujemne}");
        }


        static double Odwrotnosc(double x)
        {
            if (x == 0)
                throw new ArithmeticException("Błąd dzielenia przez zero");

            return (double) 1 / x;
        }

        static int IleRazy(int[] tab, int a)
        {
            int iloscWystapien = 0;

            //bardzo fajna sexi pętla, która wykona się raz dla każdego elementu liczba w tablicy tab
            foreach(int liczba in tab)
            {
                if (liczba == a)
                    iloscWystapien++;
            }

            //teoretycznie równoważne zapisowi:
            //for(int i = 0; i < tab.Length; i++)
            //{
            //  if(tab[i] == a)
            //      iloscWystapien++;
            //}

            return iloscWystapien;
        }

        static int[] Odwroc(int[] tab)
        {
            //Nie jest zakazane to jest dozwolone xdd
            Array.Reverse(tab);

            //A formalnie:
            /*int tmp;
            for(int i = 0; i < tab.Length/2; i++)
            {
                tmp = tab[tab.Length - i - 1];
                tab[tab.Length - i - 1] = tab[i];
                tab[i] = tmp;
            }*/

            return tab;
        }
    }

}
