using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Starostin_PD
{
    class Sp_Matrix: AMatrix
    {
        public Sp_Matrix(int rows, int cols, IPainter imp)
        {
            create(rows, cols, new Sp_Vector(rows * cols), imp);
        }

        public override void Paint()
        {
            DrawBoundary(this);
            for (int i = 0; i < get_rowCount(); i++)
                for (int j = 0; j < get_colCount(); j++)
                    if (read(i, j) > 0)
                        DrawBox(i, j, this);
                    else
                        DrawCellBox(i, j);

        }
    }
}
