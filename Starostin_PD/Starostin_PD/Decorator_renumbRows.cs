using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Starostin_PD
{
    class Decorator_renumbRows: Decorator
    {
        private int[] _row;

        public Decorator_renumbRows(IMatrix matr)
            : base(matr)
        {
            _row = new int[get_rowCount()];

            for (int i = 0; i < get_rowCount(); i++)
                _row[i] = i;
        }

        public override int read(int row, int col)
        {
            return base.read(_row[row], col);
        }

        public override void write(int row, int col, int val)
        {
            base.write(_row[row], col,val);
        }

        public override int get_rowCount()
        {
            return base.get_rowCount();
        }

        public override int get_colCount()
        {
            return base.get_colCount();
        }

        public void renumb(int row1, int row2)
        {
            int temp;
            temp = _row[row1];
            _row[row1] = _row[row2];
            _row[row2] = temp;
        }
     }
 }
