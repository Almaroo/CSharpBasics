using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_05
{
    class Paczka
    {
        string _nadawca;
        int _rozmiar;
        string _numerPaczki;
        double _oplataZaPaczke;

        static int _liczbaPaczek;
        static double _oplataZaKg;

        public string Nazwa
        {
            get { return _nadawca; }
        }

        public int Rozmiar
        {
            get { return _rozmiar; }
        }

        public string NumerPaczki
        {
            get { return _numerPaczki; }
        }

        public double OplataZaPaczke
        {
            get { return _oplataZaPaczke; }
        }

        static Paczka()
        {
            _liczbaPaczek = 0;
            _oplataZaKg = 5;
        }

        public Paczka()
        {
            _nadawca = null;
            _rozmiar = 0;
            _numerPaczki = $"{++_liczbaPaczek}/2019";
            _oplataZaPaczke = KosztWysyłki();

            Console.WriteLine($"=== Utworzono nową przesyłkę: ===\n{ToString()}");
        }

        public Paczka(string nadawca, int rozmiar)
        {
            _nadawca = nadawca;
            _rozmiar = rozmiar;
            _numerPaczki = $"{++_liczbaPaczek}/2019";
            _oplataZaPaczke = KosztWysyłki();

            Console.WriteLine($"=== Utworzono nową przesyłkę: ===\n{ToString()}");
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nadawca: {Nazwa}");
            sb.AppendLine($"Rozmiar: {Rozmiar}");
            sb.AppendLine($"Numer paczki: {NumerPaczki}");
            sb.AppendLine($"Typ paczki: {this.GetType().Name}");
            sb.AppendLine($"Opłata za paczkę: {OplataZaPaczke}");

            return sb.ToString();
        }

        public virtual double KosztWysyłki()
        {
            return (double)Rozmiar * _oplataZaKg;
        }
    }
}
