using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Starostin_PD
{
    class Decorator: IMatrix
    {
        private IMatrix component;
        private IPainter imp;

        public Decorator(IMatrix component)
        {
            this.component = component;
        }

        public void setPainter(IPainter imp)
        {
            this.imp = imp;
        }

        public virtual int read(int row, int col)
        {
            return component.read(row, col);
        }

        public virtual void write(int row, int col, int val)
        {
            component.write(row, col, val);
        }

        public virtual int get_rowCount()
        {
            return component.get_rowCount();
        }

        public virtual int get_colCount()
        {
            return component.get_colCount();
        }

        public virtual void Paint() 
        {
            imp.DrawBoundary(this);

            if (component is Sp_Matrix)
                for (int i = 0; i < get_rowCount(); i++)
                    for (int j = 0; j < get_colCount(); j++)
                        if (read(i, j) > 0)
                            imp.DrawBox(i, j, component);
                        else
                            imp.DrawCellBox(i, j);
            else if (component is Matrix)
                for (int i = 0; i < get_rowCount(); i++)
                    for (int j = 0; j < get_colCount(); j++)
                        imp.DrawBox(i, j, component);
            else if (((ACompMatrix)component).getType() is Sp_Matrix)
                for (int i = 0; i < get_rowCount(); i++)
                    for (int j = 0; j < get_colCount(); j++)
                        if (read(i, j) > 0)
                            imp.DrawBox(i, j, component);
                        else
                            imp.DrawCellBox(i, j);
            else
                for (int i = 0; i < get_rowCount(); i++)
                    for (int j = 0; j < get_colCount(); j++)
                        imp.DrawBox(i, j, component);
            
 
        }
    }
}
