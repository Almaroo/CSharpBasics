using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Totek
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] inputs = new int[6];
            int[] randoms = new int[6];
            int trafione = 0;

            Random rnd = new Random();

            Console.WriteLine("Podaj 6 liczb z zakresu 1-49");

            for(int i = 0; i < 6; i++)
            {
                bool read = false;
                do
                {
                    string input = Console.ReadLine();
                    if (Int32.TryParse(input, out inputs[i]))
                    {

                        do
                        {
                            int tmp = rnd.Next(1, 49);
                            if (!randoms.Contains(tmp))
                            {
                                randoms[i] = tmp;
                                read = true;
                            }
                                
                        } while (!read);
                       
                    }
                    else
                    {
                        Console.WriteLine("Podane wejście nie jest liczbą");
                    }
                } while (!read);
            }

            

            for(int i = 0; i < 6; i++)
            {
              
                for(int j = 0; j < 6; j++)
                {
                    if (inputs[i] == randoms[j])
                    {
                        trafione++;
                    }
                }
                Console.WriteLine($"| {inputs[i]:00}  {randoms[i]:00} |" );
            }

            Console.WriteLine("|========|");
            Console.WriteLine($"Trafiono: {trafione}");
            Console.WriteLine($"Skuteczność: {(double)trafione / 6.00f:n2}");
            Console.WriteLine("Nie róbcie hazardu dzieci");
            Console.ReadKey();


        }
    }
}
