using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Starostin_PD
{
    abstract class ACompMatrix : IMatrix
    {
        protected List<IMatrix> l;
        private IPainter imp;

        public ACompMatrix(IPainter imp)
        {
            l = new List<IMatrix>();
            this.imp = imp;
        }

        public abstract int read(int row, int col);
        public abstract void write(int row, int col, int val);
        public abstract int get_rowCount();
        public abstract int get_colCount();

        public void Paint()
        {
            imp.DrawBoundary(this);

            if (getType() is Sp_Matrix)
                for (int i = 0; i < get_rowCount(); i++)
                    for (int j = 0; j < get_colCount(); j++)
                        if (read(i, j) > 0)
                            imp.DrawBox(i, j, this);
                        else
                            imp.DrawCellBox(i, j);
            else
                for (int i = 0; i < get_rowCount(); i++)
                    for (int j = 0; j < get_colCount(); j++)
                        imp.DrawBox(i, j, this);
        }

        public void add(IMatrix comp)
        {
            l.Add(comp);
        }

        protected IMatrix getChild()
        {
            return l[0];
        }

        public IMatrix getType()
        {
            ACompMatrix a = this;
            IMatrix b;

            while (!((a.getChild().GetType() == (new Matrix(0, 0, imp).GetType())) || (a.getChild().GetType() == (new Sp_Matrix(0, 0, imp).GetType()))))
            {
                b = a.getChild();

                a = (ACompMatrix)b;
            }

            return a.getChild();

        }
    }
}
