using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSoftware
{
    class BituachLeomiANDmasAchnasa
    {
        static private double _mas;
        static private double _bituach;
        //static private double EXpenssMas = BMSoftware3.expenss;
        static internal void Mas()
        {
            //מס הכנסה מהרווח ברוטו
            _mas = BMSoftware3.incomes * 0.83 - BMSoftware3.expenss * 0.83;

            if (_mas <= 4590)
                BMSoftware3.mas = _mas * 0.1;

            if (_mas > 4590 && _mas <= 8160)
                BMSoftware3.mas = ((_mas - 4590) * 0.15) + 459;

            if (_mas > 8160 && _mas <= 12250)
                BMSoftware3.mas = (((_mas - 8160) * 0.23) + 535.5 + 459);

            if (_mas > 12250 && _mas <= 17600)
                BMSoftware3.mas = (((_mas - 12250) * 0.30) + 940.7 + 535.5 + 459);

            if (_mas > 17600 && _mas <= 37890)
                BMSoftware3.mas = (((_mas - 17600) * 0.34) + 1605 + 940.7 + 535.5 + 459);

            if (_mas > 37890)
                BMSoftware3.mas = (((_mas - 37890) * 0.46) + 6898.6 + 1605 + 940.7 + 535.5 + 459);

        }

        static internal void Bituach()
        {
            //ביטוח לאומי מהרווח ברוטו
            _bituach = BMSoftware3.incomes * 0.83 - BMSoftware3.expenss * 0.83;

            if (_bituach <= 4598)
                BMSoftware3.bituach = _bituach * 0.0982;

            if (_bituach > 4598 && _bituach <= 36750)
                BMSoftware3.bituach = ((_bituach - 4598) * 0.1623) + 451.5236;

            if (_bituach > 36750)
                BMSoftware3.bituach = 5218.2696 + 451.5236;
        }

    }
}
