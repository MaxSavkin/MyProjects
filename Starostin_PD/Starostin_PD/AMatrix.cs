using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Starostin_PD
{
    abstract class AMatrix : IMatrix
    {
        private IVector data;
        private int rows;
        private int cols;
        private IPainter imp;

        public void create(int rows, int cols, IVector vec, IPainter imp)
        {
            this.rows = rows;
            this.cols = cols;
            this.data = vec;
            this.imp = imp;
        }

        public int read(int row, int col)
        {
            return this.data.read(row * cols + col);
        }

        public void write(int row, int col, int val)
        {
            data.write(row * cols + col, val);
        }

        public int get_rowCount()
        {
            return rows;
        }

        public int get_colCount()
        {
            return cols;
        }

        protected void DrawBox(int row, int col, IMatrix matr)
        {
            imp.DrawBox(row, col, matr);
        }

        protected void DrawCellBox(int row, int col)
        {
            imp.DrawCellBox(row, col);
        }

        protected void DrawBoundary(IMatrix matr)
        {
            imp.DrawBoundary(matr);
        }

        public abstract void Paint();
    }
}
