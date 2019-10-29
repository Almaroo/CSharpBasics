using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_04
{
    class Zespol
    {
        private int _liczbaCzlonkow;
        private string _nazwa;
        private KierownikZespolu _kierownik;
        private List<CzlonekZespolu> _czlonkowie;

        public int LiczbaCzlonkow { get => _liczbaCzlonkow; set => _liczbaCzlonkow = value; }
        public string Nazwa { get => _nazwa; set => _nazwa = value; }
        public KierownikZespolu Kierownik { get => _kierownik; set => _kierownik = value; }

        public Zespol()
        {
            _liczbaCzlonkow = 0;
            _kierownik = null;
            _nazwa = null;
            _czlonkowie = new List<CzlonekZespolu>();
        }

        public Zespol(string nazwa, KierownikZespolu kierownik) : this()
        {
            _nazwa = nazwa;
            _kierownik = kierownik;
        }

        public void DodajCzlonka(CzlonekZespolu czlonek)
        {
            if(!_czlonkowie.Contains(czlonek))
                _czlonkowie.Add(czlonek);
            else
                Console.WriteLine("Ta osoba jest już członkiem zespołu");

            LiczbaCzlonkow = _czlonkowie.Count;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nazwa zespolu: {_nazwa}");
            sb.AppendLine($"Kierownik: {Kierownik.ToString()}");
            foreach(CzlonekZespolu czlonek in _czlonkowie)
            {
                sb.AppendLine($"Członek: {czlonek.ToString()}");
            }

            return sb.ToString();
        }

        public bool JestCzlonkiem(string pesel)
        {
            bool jestCzlonkiem = false;
            foreach(CzlonekZespolu czlonek in _czlonkowie)
            {
                if (czlonek.Pesel == pesel)
                    jestCzlonkiem = true;
            }

            return jestCzlonkiem;
        }

        public bool JestCzlonkiem(string imie, string nazwisko)
        {
            bool jestCzlonkiem = false;
            foreach (CzlonekZespolu czlonek in _czlonkowie)
            {
                if (czlonek.Imie == imie && czlonek.Nazwisko == nazwisko)
                    jestCzlonkiem = true;
            }

            return jestCzlonkiem;
        }

        public void UsunCzlonka(string pesel)
        {
            foreach(CzlonekZespolu czlonek in _czlonkowie)
            {
                if (czlonek.Pesel == pesel)
                    _czlonkowie.Remove(czlonek);
            }

            LiczbaCzlonkow = _czlonkowie.Count;
        }

        public void UsunCzlonka(string imie, string nazwisko)
        {
            foreach (CzlonekZespolu czlonek in _czlonkowie)
            {
                if (czlonek.Imie == imie && czlonek.Nazwisko == nazwisko)
                    _czlonkowie.Remove(czlonek);
            }

            LiczbaCzlonkow = _czlonkowie.Count;
        }

        public void UsunWszystkich()
        {
            _czlonkowie.Clear();
            LiczbaCzlonkow = _czlonkowie.Count;
        }

        public List<CzlonekZespolu> WyszukajFunkcje(string funkcja)
        {
            return _czlonkowie.FindAll(czlonek => czlonek.Stanowisko == funkcja);
        }
        
    }
}
