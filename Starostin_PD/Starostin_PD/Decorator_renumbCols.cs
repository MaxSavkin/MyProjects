using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Starostin_PD
{
    class Decorator_renumbCols: Decorator
    {
         private int[] _col;

        public Decorator_renumbCols(IMatrix matr)
            : base(matr)
        {
            _col = new int[get_colCount()];

            for (int i = 0; i < get_colCount(); i++)
                _col[i] = i;
        }

        public override int read(int row, int col)
        {
            return base.read(row, _col[col]);
        }

        public override void write(int row, int col, int val)
        {
            base.write(row, _col[col],val);
        }

        public override int get_rowCount()
        {
            return base.get_rowCount();
        }

        public override int get_colCount()
        {
            return base.get_colCount();
        }

        public void renumb(int col1, int col2)
        {
            int temp;
            temp = _col[col1];
            _col[col1] = _col[col2];
            _col[col2] = temp;
        }
    }
}
