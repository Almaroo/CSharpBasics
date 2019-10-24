using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Ksiazka
{
    class Program
    {
        static void Main(string[] args)
        {
            string wybranaKsiazka = "";
            bool wybranoKsiazke = false;
            ConsoleKeyInfo cKI;
            

            DisplayMenu(wybranoKsiazke, wybranaKsiazka);

            while (true)
            {
                cKI = Console.ReadKey(true); //podajemy true jako argument żeby się nie wyświetlały klawisze które wcisnęliśmy;


                if (cKI.Key == ConsoleKey.D0)
                    return;
                if (cKI.Key == ConsoleKey.D1)
                {
                    WybierzKsiazke(out wybranoKsiazke, out wybranaKsiazka);

                    DisplayMenu(wybranoKsiazke, wybranaKsiazka);
                }

                if(cKI.Key == ConsoleKey.D2)
                {
                    //Wyszukaj kontakt
                    if(wybranoKsiazke)
                        WyszukajKontakt(wybranaKsiazka);
                    else
                        Console.WriteLine("Nie wybrabno książki!!!");
                }
                if(cKI.Key == ConsoleKey.D3)
                {
                    //Dodaj kontakt
                    if (wybranoKsiazke)
                        DodajKontakt(wybranaKsiazka);
                    else
                        Console.WriteLine("Nie wybrabno książki!!!");
                }
                if(cKI.Key == ConsoleKey.D4)
                {
                    //Zapisz
                }
                if(cKI.Key == ConsoleKey.C)
                {
                    DisplayMenu(wybranoKsiazke, wybranaKsiazka);
                }
            }

        }

        static void DisplayMenu(bool wybranoKsiazke, string nazwaKsiazki)
        {
            Console.Clear();
            Console.WriteLine("=====Menu=====");
            Console.WriteLine($"Wybrana książka: {(wybranoKsiazke ? nazwaKsiazki : "brak")}");
            Console.WriteLine("(1) Wybierz książkę");
            Console.WriteLine("(2) Szukaj numeru po nazwie użytkownika");
            Console.WriteLine("(3) Dodaj użytkownika");
            Console.WriteLine("(c) Wyczyść konsole");
            Console.WriteLine("(0) Wyjdź");
        }

        static void WybierzKsiazke(out bool wczytano, out string nazwaKsiazki)
        {
            Console.Clear();
            wczytano = false;
            nazwaKsiazki = "";
            int ileProb = 3;

            do
            {
                Console.WriteLine("Podaj nazwę pliku w którym znajduje się książka");
                Console.WriteLine($"{(ileProb > 1 ? "Pozostało" : "Pozostała")}: {ileProb} {(ileProb > 1 ? "prób" : "próba")}");
                string nazwaPliku = Console.ReadLine();
                string sciezka = $@"{Directory.GetCurrentDirectory()}\{nazwaPliku}.txt";

                if(File.Exists(sciezka))
                {
                    nazwaKsiazki = nazwaPliku;
                    wczytano = true;
                }
                else
                {
                    Console.WriteLine($"Plik {Path.GetFileName(sciezka)} nie istnieje");
                }

                ileProb--;

            } while (!wczytano && ileProb > 0);
            
        }

        static void WyszukajKontakt(string wybranaKsiazka)
        {

            Console.WriteLine("Podaj kontakt, którego szukasz");
            string imie = Console.ReadLine();
            bool znaleziono = false;

            string sciezkaDoPliku = $@"{Directory.GetCurrentDirectory()}\{wybranaKsiazka}.txt";

            if (File.Exists(sciezkaDoPliku))
            {
                using (StreamReader sr = new StreamReader(sciezkaDoPliku))
                {
                    string row;

                    do
                    {
                        row = sr.ReadLine();
                        if (row != null)
                        {
                            try
                            {
                                var rowInput = row.Split(',');
                                if(rowInput[0] == imie)
                                {
                                    Console.WriteLine(row);
                                    znaleziono = true;
                                }
                            
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine($"{e.GetType()}: {e.Message}");
                            }
                        } 
                        else
                        {
                            if(!znaleziono)
                            {
                                Console.WriteLine($"Nie znaleziono dopasowania dla: {imie}");
                            }
                            break;
                        }
                            
                    } while (true);

                }


            }
            else
            {
                Console.WriteLine($"Plik {wybranaKsiazka} nie istnieje");
            }

        }

        static void DodajKontakt(string wybranaKsiazka)
        {
            string wzorNumeru = @"^\d{3}-\d{3}-\d{3}$";
            Regex reNumer = new Regex(wzorNumeru);
            bool wczytano = false;
            int ileProb = 3;

            string sciezkaDoPliku = $@"{Directory.GetCurrentDirectory()}\{wybranaKsiazka}.txt";

            if(!File.Exists(sciezkaDoPliku))
            {
                Console.WriteLine($"Plik {wybranaKsiazka} nie istnieje");
                return;
            }

            Console.WriteLine("Podaj nazwę dla nowego kontaktu");
            string imie = Console.ReadLine();

            do
            {
                Console.WriteLine("Podaj numer telefonu w formacie 000-000-000");
                string numer = Console.ReadLine();

                if (reNumer.IsMatch(numer))
                {

                    string newRow = $"{imie}, {numer}";

                    using(StreamWriter sw = new StreamWriter(sciezkaDoPliku, true)) //-> true bo chcemy dopisywać do pliku, nie nadpisywać go
                    {
                        sw.WriteLine(newRow);
                    }


                    Console.WriteLine("Pomyślnie dodano numer");
                    wczytano = true;

                }
                else
                {
                    Console.WriteLine($"Nie prawidłowy format numeru.");
                    Console.WriteLine($"{(ileProb > 1 ? "Pozostało" : "Pozostała")}: {ileProb} {(ileProb > 1 ? "prób" : "próba")}");
                }
                
                ileProb--;
            } while (!wczytano && ileProb > 0);
            

            
        }

    }
}
