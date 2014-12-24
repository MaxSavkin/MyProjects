using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Starostin_PD
{
    class Sp_Vector: IVector
    {
        private List<int> data;
        private List<int> row;
        private int size;
        private int notZero;

        public Sp_Vector(int size)
        {
            this.size = size;
            this.notZero = 0;
            data = new List<int>();
            row = new List<int>();
        }

        public int read(int num)
        {
            int k=-1;
            for (int i=0;i<notZero;i++)
                if (row[i]==num)
                    k=i;
            if (k==-1)
                return 0;
            else
                return data[k];
        }

        public void write(int num, int val)
        {
            int k=-1;
            for (int i=0;i<notZero;i++)
                if (row[i]==num)
                    k=i;

            if (k==-1)
            {
                data.Add(val);
                row.Add(num);
                notZero++;
            }
            else
                data[k]=val;
        }

        public int getSize()
        {
            return size;
        }

    }
}
