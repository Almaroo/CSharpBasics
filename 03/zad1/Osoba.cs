using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_3
{
    class Osoba
    {
        private string _imie; //Ładnie jest prywatne zmienne nazwyać sobie _nazwaZmiennej co się przyda przy konstruktorze
        public string Nazwisko { get; set; }
        private DateTime _dataUrodzenia;
        private string _PESEL;
        private Plcie _plec;

        public string Imie
        {
            get { return _imie; }
            set { _imie = value; }
        }

        public DateTime DataUrodzenia
        {
            get => _dataUrodzenia;
            set => _dataUrodzenia = value;
        }

        public Osoba()
        {
            _imie = null;
            Nazwisko = null;
            _dataUrodzenia = new DateTime();
            _PESEL = "00000000000";
        }

        public Osoba(string imie, string nazwisko)
        {
            _imie = imie; //dlatego warto nazwyać sobie prywatne _nazwaZmiennej żeby nam się nie myliło w konstruktorze
            Nazwisko = nazwisko;
            _dataUrodzenia = new DateTime();
            _PESEL = "00000000000";
        }

        public Osoba(string imie, string nazwisko, string dataUrodzenia, string PESEL, Plcie plec)
        {
            _imie = imie;
            Nazwisko = nazwisko;
            DateTime.TryParseExact(dataUrodzenia, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MMM-yy" }, null, System.Globalization.DateTimeStyles.None, out _dataUrodzenia);
            _PESEL = PESEL;
            _plec = plec;
        }

        private static bool poprawnyPesel()
        {
            return true;
        }

        public int Wiek()
        {
            return DateTime.Now.Year - _dataUrodzenia.Year;
        }

        public override string ToString()
        {
            /* 
             * $ przed stringiem pozwala na interpolację stringa. To znaczy że:
             *  w przypadku $"{_imie} {Nazwisko}" najpierw zostaną pobrane wartości _imie i Nazwisko, a następnie wsadzone do stringa
             *  jest to równoważne:
             * _imie + " " + Nazwisko
             * a zdecydowanie ładniejsze c: miłe, fajne, wygodne i intuicyjne
             */
            return $"{_imie} {Nazwisko} {_dataUrodzenia.Year}-{_dataUrodzenia.Month}-{_dataUrodzenia.Day} {_PESEL} {_plec}"; 
        }
    }
}
