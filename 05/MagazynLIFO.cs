using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_05
{
    class MagazynLIFO : IMagazynuje
    {
        private string _nazwa;
        private int _liczbaPaczek;
        private Stack<Paczka> _listaPaczek;

        public int LiczbaPaczke
        {
            get { return _liczbaPaczek; }
        }

        public string Nazwa
        {
            get { return _nazwa; }
        }

        public MagazynLIFO()
        {
            _listaPaczek = new Stack<Paczka>();
            _nazwa = null;
        }

        public MagazynLIFO(string nazwa)
        {
            _listaPaczek = new Stack<Paczka>();
            _nazwa = nazwa;
        }

        public void Umiesc(Paczka t)
        {
            _listaPaczek.Push(t);
            _liczbaPaczek = _listaPaczek.Count;
        }

        public Paczka Pobierz()
        {
            Paczka ret = _listaPaczek.Peek();
            _listaPaczek.Pop();
            _liczbaPaczek = _listaPaczek.Count;

            return ret;
        }

        public void Wyczysc()
        {
            _listaPaczek.Clear();
            Console.WriteLine($"Magazyn: {this.GetType().Name} wyczyszczony");
        }

        public int PodajIlosc()
        {
            return _listaPaczek.Count;
        }

        public Paczka PodajBiezacy()
        {
            return _listaPaczek.Peek();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"=== Magazyn typu: {this.GetType().Name} ===");
            sb.AppendLine($"Nazwa: {_nazwa}");
            sb.AppendLine($"Ilość paczek: {PodajIlosc()}");
            sb.AppendLine("Przechowywane paczki:");
            int idx = 0;
            foreach(Paczka p in _listaPaczek)
            {
                sb.AppendLine($"--- {++idx} ---");
                sb.AppendLine(p.ToString());
            }

            return sb.ToString();
        }
    }
}
