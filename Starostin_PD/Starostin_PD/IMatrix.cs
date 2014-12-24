using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Starostin_PD
{
    interface IMatrix
    {
        int read(int row, int col);
        void write(int row, int col, int val);
        int get_rowCount();
        int get_colCount();
        void Paint();
    }
}
