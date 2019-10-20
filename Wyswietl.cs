using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // Będziemy korzystać z klasy Path i Directory

namespace Wyswietl
{
    class Program
    {
        static void Main(string[] args)
        {
            //ABY ZADZIAŁAŁO PROGRAM MUSI ZOSTAĆ URUCHOMIONY Z CommandLine'a !!!
            //$ -> zezwala na interpolację
            //@ -> wymusza dosłowne interpretowanie stringa
            string pathToFile = $@"{Directory.GetCurrentDirectory()}\{(args.Length > 0 ? args[0] : "test")}.txt"; //Zwraca scieżkę do katalogu w którym znajduje się nasz plik .exe            

            if(File.Exists(pathToFile))
            {
                bool wyswietlonoCalosc = false;
                string[] inputRows = File.ReadAllLines(pathToFile);
                int strona = 0;
                int i;
                ConsoleKeyInfo cKI;

                Console.WindowHeight = Console.LargestWindowHeight;
                Console.WindowTop = 0;
                Console.WindowLeft = 0;

                do
                {
                    Console.WriteLine($"Zawartość pliku o nazwie: {Path.GetFileName(pathToFile)}, strona {strona + 1}");
                    for(i = 0; i < Console.LargestWindowHeight - 3; i++)
                    {
                        if (i + (Console.LargestWindowHeight - 3) * strona < inputRows.Length)
                            Console.WriteLine($"{i + (Console.LargestWindowHeight - 2) * strona + 1}: {inputRows[i + (Console.LargestWindowHeight - 3) * strona]}");
                    }

                    if (i + (Console.LargestWindowHeight - 3) * strona < inputRows.Length)
                    {
                        Console.WriteLine("Aby wyświetlić więcej wciśnij spację...");
                        do
                        {
                            cKI = Console.ReadKey();
                        } while (cKI.Key != ConsoleKey.Spacebar);
                        strona++;
                        Console.Clear();
                    }
                    else
                    {
                        wyswietlonoCalosc = true;
                        Console.WriteLine("Koniec pliku...");
                    }
                } while (!wyswietlonoCalosc);
                

            }
            else
            {
                Console.WriteLine($"Plik o nazwie {Path.GetFileName(pathToFile)} nie istnieje");
            }
            Console.ReadKey();
        }
    }
}
