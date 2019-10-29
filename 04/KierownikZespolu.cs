using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_04
{
    class KierownikZespolu : Osoba
    {
        private int _doswiadczenie;


        //base(imie, nazwisko, dataUrodzenia, PESEL, plec) znaczy tyle że wołamy konstruktor dziedziczonej klasy z podanymi argumentami
        //w tym wypadku Osoba(imie, nazwisko, dataUrodzenia, PESEL, plec)
        public KierownikZespolu(string imie, string nazwisko, string dataUrodzenia, string PESEL, Plcie plec, int doswiadczenie) : base(imie, nazwisko, dataUrodzenia, PESEL, plec)
        {
            _doswiadczenie = doswiadczenie;
        }

        public override string ToString() //bez tej metody dostaniemy błąd mówiący że KierownikZespolu nie implementuje metod dziedziczonych po Osoba 
        {
            //base.ToString() -> zawoła funkcję ToString() z poziomu klasy dziedziczonej (Osoba)
            return $"{base.ToString()} {_doswiadczenie}";
        }
    }
}