using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO_05
{
    class PaczkaPolecona : Paczka
    {
        static double _oplataDodatkowa;

        static PaczkaPolecona()
        {
            _oplataDodatkowa = 10.0;
        }

        public PaczkaPolecona() : base()
        {

        }

        public PaczkaPolecona(string nadawca, int rozmiar) : base(nadawca, rozmiar)
        {

        }

        public override double KosztWysyłki()
        {
            return base.KosztWysyłki() + _oplataDodatkowa;
        }
    }
}
