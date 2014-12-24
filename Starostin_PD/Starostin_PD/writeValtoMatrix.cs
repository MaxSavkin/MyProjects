using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Starostin_PD
{
    class writeValtoMatrix: ICommand
    {
        private int newVal;
        private int row;
        private int col;
        private IMatrix state;
        private int i;


        public writeValtoMatrix(IMatrix state) 
        {
            this.state = state;
            i = 0;
        }

        public void execute()
        {
            if (i==0)
                getRandValue();
            
            state.write(row, col, newVal);
            i++;
        }

        private void getRandValue()
        {
            Random rand = new Random();
            newVal = rand.Next(2);
            row = rand.Next(state.get_rowCount());
            col = rand.Next(state.get_colCount());
        }
    }
}
