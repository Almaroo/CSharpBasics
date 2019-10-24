using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_3
{
    //Analogicznie do kierownik zespołu
    class CzlonekZespolu : Osoba
    {
        public string Stanowisko { get; set; }

        public CzlonekZespolu(string imie, string nazwisko, string dataUrodzenia, string PESEL, Plcie plec, string stanowisko) : base(imie, nazwisko, dataUrodzenia, PESEL, plec)
        {
            Stanowisko = stanowisko;
        }

        public override string ToString() //bez tej metody dostaniemy błąd mówiący że KierownikZespolu nie implementuje metod dziedziczonych po Osoba 
        {
            //base.ToString() -> zawoła funkcję ToString() z poziomu klasy dziedziczonej (Osoba)
            return $"{base.ToString()} {Stanowisko}";
        }

    }
}
