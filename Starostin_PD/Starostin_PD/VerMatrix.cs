using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Starostin_PD
{
    class VerMatrix : ACompMatrix
    {
        public VerMatrix(IPainter imp) :
            base(imp) { }
        

        public override int read(int row, int col)
        {
            int sum = 0;
            IMatrix m = l[0];

            foreach (IMatrix i in l)
            {
                sum += i.get_rowCount();
                if (sum > row)
                {
                    m = i;
                    break;
                }
            }

            if (col > m.get_colCount() - 1)
                return 0;
            else
                return m.read(row + m.get_rowCount() - sum, col);
        }

        public override void write(int row, int col, int val)
        {
            int sum = 0;
            IMatrix m = l[0];

            foreach (IMatrix i in l)
            {
                sum += i.get_rowCount();
                if (sum > row)
                {
                    m = i;
                    break;
                }
            }

            if (col < m.get_colCount())
                m.write(row + m.get_rowCount() - sum, col,val);
        }

        public override int get_rowCount()
        {
            int sum = 0;

            foreach (IMatrix i in l)
                sum += i.get_rowCount();

            return sum;
        }

        public override int get_colCount()
        {
            int max = 0;

            foreach (IMatrix i in l)
                if (i.get_colCount() > max)
                    max = i.get_colCount();

            return max;
        }
    }
}
