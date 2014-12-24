using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Starostin_PD
{
    class Decorator_Transpose: Decorator
    {
        private bool flag;

        public Decorator_Transpose(IMatrix matr)
            : base(matr)
        {
            flag = true;
        }

        public override int read(int row, int col)
        {
            if (flag)
                return base.read(row, col);
            else
                return base.read(col, row);
        }

        public override void write(int row, int col, int val)
        {
            if (flag)
                base.write(row, col,val);
            else
                 base.write(col, row,val);
        }

        public override int get_rowCount()
        {
            if (flag)
                return base.get_rowCount();
            else 
                return base.get_colCount();
        }

        public override int get_colCount()
        {
            if (flag)
                return base.get_colCount();
            else
                return base.get_rowCount();
        }

        public void transpose()
        {
            if (flag)
                flag = false;
            else
                flag = true;
        }
    }
}
