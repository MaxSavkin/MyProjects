using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Starostin_PD
{
    class DecPainter : APainter
    {
        private APainter comp;

        public DecPainter(APainter comp)
        {
            this.comp = comp;
        }

        public override void DrawBox(int row, int col, IMatrix m)
        {
            comp.DrawBox(row, col, m);
        }

        public override void DrawCellBox(int row, int col)
        {
            comp.DrawCellBox(row, col);
        }

        public override void DrawBoundary(IMatrix m)
        {
            comp.DrawBoundary(m);
        }

        public void changePainter(APainter comp)
        {
            this.comp = comp;
        }

        public override void setGraphics(System.Drawing.Graphics g)
        {
            comp.setGraphics(g);
        }

        public override void setDefaultColors()
        {
            comp.setDefaultColors();
        }


    }
}
