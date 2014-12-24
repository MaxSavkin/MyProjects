using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Starostin_PD
{
    class initMatrix
    {
         public static void fill(IMatrix matr, int notZero_num, int maxVal)
        {
            int k = 0;
            int[] pos = new int[notZero_num];
            int f;
            int size = matr.get_colCount() * matr.get_rowCount();
            int val;
            Random rand = new Random();

            for (int j = 0; j < notZero_num; j++)
            {
                do
                {
                    pos[j] = rand.Next(size);
                    f = 0;
                    for (k = 0; k < j; k++)
                        if (pos[j] == pos[k])
                            f = 1;
                }
                while (f == 1);

                val = rand.Next(1, maxVal);
                matr.write(pos[j] / matr.get_colCount(), pos[j] % matr.get_colCount(), val);
            }


        }
    }
}
