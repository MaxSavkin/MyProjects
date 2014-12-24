using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Starostin_PD
{
    class Vector: IVector
    {
         private int[] data;
        private int size;

        public Vector(int size)
        {
            this.size = size;
            data = new int[size];
            for (int i = 0; i < size; i++)
                data[i] = 0;
        }

        public int read(int num)
        {
            return data[num];
        }

        public void write(int num, int val)
        {
            data[num] = val;
        }

        public int getSize()
        {
            return size;
        }
    }
}
