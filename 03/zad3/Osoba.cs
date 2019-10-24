using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PO_3
{
    //dodajemy słowo kluczowe abstract, jest to swego rodzaju szablon dla dziedziczących klas
    //tj każda z dziedziczących klas będzie miała dostęp do pól i metod
    abstract class Osoba 
    {
        protected string _imie; //Ładnie jest prywatne zmienne nazwyać sobie _nazwaZmiennej co się przyda przy konstruktorze
        public string Nazwisko { get; set; }
        protected DateTime _dataUrodzenia;
        protected string _PESEL;
        protected Plcie _plec;

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
            _plec = plec;
            try
            {
                SetPesel(PESEL);
            }
            catch (Exception e)
            {

                Console.WriteLine($"{e.GetType()}: {e.Message}");
            }
            
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
            return $"{_imie} {Nazwisko} {_dataUrodzenia.Year:0000}-{_dataUrodzenia.Month:00}-{_dataUrodzenia.Day:00} {_PESEL} {_plec}";
        }

        private void SetPesel(string PESEL)
        {
            Regex peselRegEx = new Regex(@"^\d{11}$");
            
            if(peselRegEx.IsMatch(PESEL)) //sprawdzamy ogólną postać PESELu
            {
                int tmpData = ((_dataUrodzenia.Year / 10) % 10) * 10 + _dataUrodzenia.Year % 10; //dwie ostatnie cyfry roku urodzenia w postaci cyfry
                int tmpPESEL = ((int)PESEL[0] - 48) * 10 + ((int)PESEL[1] - 48); //dwie pierwsze liczby PESELU

                if (tmpData == tmpPESEL) // dwie pierwsze cyfry -> ROK
                {
                    tmpData = _dataUrodzenia.Month;
                    tmpPESEL = ((int)PESEL[2] - 48) * 10 + ((int)PESEL[3] - 48); //trzecia i czwarta liczba PESELU -> MIESIĄC

                    if (tmpData == tmpPESEL) //trzecia i czwarta cyfra
                    {
                        tmpData = _dataUrodzenia.Day;
                        tmpPESEL = ((int)PESEL[4] - 48) * 10 + ((int)PESEL[5] - 48); //piąta i szósta liczba PESELU -> DZIEŃ

                        if(tmpData == tmpPESEL) //piąta i szósta cyfra
                        {

                            if((_plec == Plcie.K && ((int)PESEL[9] - 48) % 2 == 0) || (_plec == Plcie.M && ((int)PESEL[9] - 48) % 2 != 0)) // dziesiąta cyfra -> PŁEĆ
                            {
                                tmpPESEL = 9 * ((int)PESEL[0] - 48) + 7 * ((int)PESEL[1] - 48) + 3 * ((int)PESEL[2] - 48) + 1 * ((int)PESEL[3] - 48) + 9 * ((int)PESEL[4] - 48) + 7 * ((int)PESEL[5] - 48) + 3 * ((int)PESEL[6] - 48) + 1 * ((int)PESEL[7] - 48) + 9 * ((int)PESEL[8] - 48) + 7 * ((int)PESEL[9] - 48);

                                if(tmpPESEL % 10 == ((int)PESEL[10] - 48)) // jedenasta cyfra -> KONTROLNA
                                {
                                    _PESEL = PESEL;
                                }
                                else
                                {
                                    throw new WrongPESELException("Jedenasta cyfra PESELU jest błędna");
                                }
                            }
                            else
                            {
                                throw new WrongPESELException("Dziesiąta cyfra PESELU jest błędna");
                            }

                        }
                        else
                        {
                            throw new WrongPESELException("Piąta i szósta cyfra PESELU są błędne");
                        }
                    }
                    else
                    {
                        throw new WrongPESELException("Trzecia i czwarta cyfra PESELU są błędne");
                    }
                }
                else
                {
                    throw new WrongPESELException("Dwie pierwsze cyfry PESELU są błędne");
                }
                
            }
            else
            {
                throw new WrongPESELException("Podany pesel nie składa się tylko z 11 cyfr");
            }
        }

    }
}
