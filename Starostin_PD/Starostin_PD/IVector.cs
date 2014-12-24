using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Starostin_PD
{
    interface IVector
    {
        int read(int num);
        void write(int num, int val);
        int getSize();
    }
}
