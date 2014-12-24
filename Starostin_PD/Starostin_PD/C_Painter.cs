using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Starostin_PD
{
    class C_Painter : APainter
    {
        public override void DrawBox(int row, int col, IMatrix m)
        {
            g.FillRectangle(new SolidBrush(boxColor), col * width + 1, row * height + 1, width, height);
            g.DrawRectangle(new Pen(bordBoxColor), col * width + 1, row * height + 1, width, height);
        }

        public override void setDefaultColors()
        {
            width = 40;
            height = 40;
            bordColor = Color.Black;
            boxColor = Color.Red;
            bordBoxColor = Color.Blue;
            emptyBoxColor = Color.Yellow;
            BGColor = Color.White;
        } 
    }
}
