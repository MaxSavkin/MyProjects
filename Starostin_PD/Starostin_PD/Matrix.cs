using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Starostin_PD
{
    class Matrix: AMatrix
    {
        public Matrix(int rows, int cols, IPainter imp)
        {
            create(rows, cols, new Vector(rows * cols), imp);
        }

        public override void Paint()
        {
            DrawBoundary(this);

            for (int i = 0; i < get_rowCount(); i++)
                for (int j = 0; j < get_colCount(); j++)
                    DrawBox(i, j, this);

        }
    }
}
