using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_05
{
    class Program
    {
        static void Main(string[] args)
        {
            Paczka p1 = new Paczka("nadawcaA", 1);
            Paczka p2 = new Paczka("nadawcaB", 2);
            PaczkaPolecona pp1 = new PaczkaPolecona("nadawcaC", 3);
            PaczkaPolecona pp2 = new PaczkaPolecona("nadawcaD", 4);

            Console.WriteLine("Wprowadź:\n1-LIFO\n2-FIFO\n3-List\n4-Array");
            int s = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            switch(s)
            {
                case 1:
                    {
                        MagazynLIFO mStos = new MagazynLIFO("mStos");

                        mStos.Umiesc(p1);
                        mStos.Umiesc(p2);
                        mStos.Umiesc(pp1);
                        mStos.Umiesc(pp2);

                        Console.WriteLine(mStos.ToString());

                        Console.WriteLine($"Paczka pobrana z magazynu:\n{mStos.Pobierz().ToString()}");

                        Console.WriteLine(mStos.ToString());

                        mStos.Wyczysc();

                        Console.WriteLine(mStos.ToString());

                        break;
                    }

                case 2:
                    {
                        MagazynFIFO mKolejka = new MagazynFIFO("mKolejka");

                        mKolejka.Umiesc(p1);
                        mKolejka.Umiesc(p2);
                        mKolejka.Umiesc(pp1);
                        mKolejka.Umiesc(pp2);

                        Console.WriteLine(mKolejka.ToString());

                        Console.WriteLine($"Paczka pobrana z magazynu:\n{mKolejka.Pobierz().ToString()}");

                        Console.WriteLine(mKolejka.ToString());

                        mKolejka.Wyczysc();

                        Console.WriteLine(mKolejka.ToString());

                        break;
                    }
                case 3:
                    {
                        MagazynList mList = new MagazynList("mLista");

                        mList.Umiesc(p1);
                        mList.Umiesc(p2);
                        mList.Umiesc(pp1);
                        mList.Umiesc(pp2);

                        Console.WriteLine(mList.ToString());

                        //Pobiera ostatnią w łatwy sposób można zmodyfikować by pobierało pierwszą
                        Console.WriteLine($"Paczka pobrana z magazynu:\n{mList.Pobierz().ToString()}");

                        Console.WriteLine(mList.ToString());

                        mList.Wyczysc();

                        Console.WriteLine(mList.ToString());

                        break;
                    }
                case 4:
                    {
                        MagazynArray mArray = new MagazynArray("mTablica");

                        mArray.Umiesc(p1);
                        mArray.Umiesc(p2);
                        mArray.Umiesc(pp1);
                        mArray.Umiesc(pp2);

                        Console.WriteLine(mArray.ToString());

                        //Pobiera ostatnią w łatwy sposób można zmodyfikować by pobierało pierwszą
                        Console.WriteLine($"Paczka pobrana z magazynu:\n{mArray.Pobierz().ToString()}");

                        Console.WriteLine(mArray.ToString());

                        mArray.Wyczysc();

                        Console.WriteLine(mArray.ToString());

                        break;
                    }
                default:
                    {
                        Console.WriteLine("Nie ma takiej opcji...");
                        break;
                    }
            }

            
            
            Console.ReadKey();
        }

    }
}
