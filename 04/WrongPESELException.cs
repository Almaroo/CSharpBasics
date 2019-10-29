using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_04
{
    //Tworzymy nową klasę naszego wyjątku dziedziczącą po klasie Exception
    class WrongPESELException : Exception
    {
        //Przechwytujemy wiadomość podaną jako WrongPESELException(msg) i przekazujemy ją do klasy bazowej (Exception) za pomocą base(message)
        public WrongPESELException(string message) : base(message)
        {

        }
    }
}