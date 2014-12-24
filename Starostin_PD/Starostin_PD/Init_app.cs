using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Starostin_PD
{
    class Init_app: ICommand
    {
        private IMatrix matr;
        private int[,] values;

        public Init_app(IMatrix matr)
        {
            this.matr = matr;
            values = new int[matr.get_rowCount(), matr.get_colCount()];

            for (int i = 0; i < matr.get_rowCount(); i++)
                for (int j = 0; j < matr.get_colCount(); j++)
                    values[i, j] = matr.read(i, j);
        }

        public void execute()
        {
            for (int i = 0; i < matr.get_rowCount(); i++)
                for (int j = 0; j < matr.get_colCount(); j++)
                    matr.write(i, j, values[i, j]);
        }
    }
}
