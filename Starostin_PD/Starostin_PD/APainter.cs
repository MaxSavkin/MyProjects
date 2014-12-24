using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Starostin_PD
{
    abstract class APainter: IPainter
    {
        protected Graphics g;

        public int width;
        public int height;
        public Color bordColor;
        public Color boxColor;
        public Color bordBoxColor;
        public Color emptyBoxColor;
        public Color BGColor;

        public virtual void DrawBoundary(IMatrix m)
        {
            g.DrawRectangle(new Pen(bordColor), 0, 0, width * m.get_colCount(), height * m.get_rowCount());
        }

        public virtual void DrawCellBox(int row, int col)
        {
            g.FillRectangle(new SolidBrush(emptyBoxColor), col * width + 2, row * height + 2, width, height);
        }

        public abstract void setDefaultColors();
        public abstract void DrawBox(int row, int col, IMatrix m);

        public virtual void setGraphics(Graphics g)
        {
            this.g = g;
        }
    }
}
