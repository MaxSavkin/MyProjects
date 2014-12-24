using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Starostin_PD
{
    class HorMatrix: ACompMatrix
    {
        public HorMatrix(IPainter imp) :
            base(imp) { }

        public override int read(int row, int col) 
        {
            int sum = 0;
            IMatrix m=l[0];

            foreach (IMatrix i in l)
            {
                sum += i.get_colCount();
                if (sum > col)
                {
                    m = i;
                    break;
                }
            }

            if (row > m.get_rowCount() - 1)
                return 0;
            else
                return m.read(row, col + m.get_colCount() - sum);
        }
        
        public override void write(int row, int col, int val) 
        {
            int sum = 0;
            IMatrix m = l[0];

            foreach (IMatrix i in l)
            {
                sum += i.get_colCount();
                if (sum > col)
                {
                    m = i;
                    break;
                }
            }

            if (row < m.get_rowCount())
                m.write(row, col + m.get_colCount() - sum, val);
        }
        
        public override int get_rowCount() 
        {
            int max = 0;

            foreach (IMatrix i in l)
                if (i.get_rowCount() > max)
                    max = i.get_rowCount();

            return max;
        }

        public override int get_colCount() 
        {
            int sum=0;

            foreach (IMatrix i in l)
                sum += i.get_colCount();

            return sum;
        }
    }
}
