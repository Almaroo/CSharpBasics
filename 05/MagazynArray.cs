using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_05
{
    class MagazynArray : IMagazynuje
    {
        private string _nazwa;
        private int _liczbaPaczek;
        private ArrayList _listaPaczek;

        public int LiczbaPaczek
        {
            get { return _liczbaPaczek; }
        }

        public string Nazwa
        {
            get { return _nazwa; }
        }

        public MagazynArray()
        {
            _listaPaczek = new ArrayList();
            _nazwa = null;
        }

        public MagazynArray(string nazwa)
        {
            _listaPaczek = new ArrayList();
            _nazwa = nazwa;
        }

        public void Umiesc(Paczka t)
        {
            _listaPaczek.Add(t);
            _liczbaPaczek = _listaPaczek.Count;
        }

        public Paczka Pobierz()
        {
            Paczka ret = (Paczka)_listaPaczek[_listaPaczek.Count - 1];
            _listaPaczek.RemoveAt(_listaPaczek.Count - 1);
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
            return (Paczka)_listaPaczek[_listaPaczek.Count - 1];
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"=== Magazyn typu: {this.GetType().Name} ===");
            sb.AppendLine($"Nazwa: {_nazwa}");
            sb.AppendLine($"Ilość paczek: {PodajIlosc()}");
            sb.AppendLine("Przechowywane paczki:");
            int idx = 0;
            foreach (Paczka p in _listaPaczek)
            {
                sb.AppendLine($"--- {++idx} ---");
                sb.AppendLine(p.ToString());
            }

            return sb.ToString();
        }
    }
}
