using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Filtr
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = $@"{Directory.GetCurrentDirectory()}\input.txt";
            string outputPath = $@"{Directory.GetCurrentDirectory()}\output.txt";

            string numberPattern = @"^[+-]?\d+(:?[.,]\d+)?$";
            Regex numRegEx = new Regex(numberPattern);

            if(File.Exists(inputPath))
            {

                if (File.Exists(outputPath))
                {
                    using (StreamWriter sw = new StreamWriter(outputPath))
                    {
                        using (StreamReader sr = new StreamReader(inputPath))
                        {
                            string row;
                            do
                            {
                                row = sr.ReadLine();
                                if (row != null && numRegEx.IsMatch(row))
                                    sw.WriteLine(row);

                            } while (row != null);
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Plik {Path.GetFileName(outputPath)} nie istnieje\nAby wyjść naciśnij dowolny klawisz...");
                    return;
                }
            }
            else
            {
                Console.WriteLine($"Plik {Path.GetFileName(inputPath)} nie istnieje\nAby wyjść naciśnij dowolny klawisz...");
                Console.ReadKey();
                return;
            }

            

            


        }
    }
}
