using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Starostin_PD
{
    interface IPainter
    {
        void DrawBox(int row, int col, IMatrix m);
        void DrawCellBox(int row, int col);
        void DrawBoundary(IMatrix m);
    }
}
