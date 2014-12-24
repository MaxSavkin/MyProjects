using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Starostin_PD
{
    public partial class Form1 : Form
    {
        private IMatrix matr1, matr2;

        private DecPainter pn;
        private APainter p;

        private Decorator_renumbRows Drowa, Drowb;
        private Decorator_renumbCols Dcola, Dcolb;
        private Decorator_Transpose Dtrna, Dtrnb;

        private int t1 = 0, t2 = 0, t3 = 0, t4 = 0;
        private int flag = 0;
        private int Max = 100;

        private ACompMatrix v1, v2;

        ICommand command;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            pictureBox1.CreateGraphics().Clear(Form1.DefaultBackColor);
            pictureBox2.CreateGraphics().Clear(Form1.DefaultBackColor);

            Random rand = new Random();
            flag = 0;

            do
            {
                t1 = rand.Next(v1.get_rowCount());
                t2 = rand.Next(v1.get_rowCount());
                t3 = rand.Next(v2.get_rowCount());
                t4 = rand.Next(v2.get_rowCount());
            } while ((t1 == t2) || (t3 == t4));

            Drowa.renumb(t1, t2);
            Drowb.renumb(t3, t4);

            pn.setGraphics(pictureBox1.CreateGraphics());
            Drowa.Paint();
            pn.setGraphics(pictureBox2.CreateGraphics());
            Drowb.Paint();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.CreateGraphics().Clear(Form1.DefaultBackColor);
            pictureBox2.CreateGraphics().Clear(Form1.DefaultBackColor);

            Random rand = new Random();
            flag = 1;

            do
            {
                t1 = rand.Next(v1.get_colCount());
                t2 = rand.Next(v1.get_colCount());
                t3 = rand.Next(v2.get_colCount());
                t4 = rand.Next(v2.get_colCount());
            } while ((t1 == t2) || (t3 == t4));

            Dcola.renumb(t1, t2);
            Dcolb.renumb(t3, t4);

            pn.setGraphics(pictureBox1.CreateGraphics());
            Dcola.Paint();
            pn.setGraphics(pictureBox2.CreateGraphics());
            Dcolb.Paint();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            flag = 2;

            pictureBox1.CreateGraphics().Clear(Form1.DefaultBackColor);
            pictureBox2.CreateGraphics().Clear(Form1.DefaultBackColor);

            Dtrna.transpose();
            Dtrnb.transpose();

            pn.setGraphics(pictureBox1.CreateGraphics());
            Dtrna.Paint();
            pn.setGraphics(pictureBox2.CreateGraphics());
            Dtrnb.Paint();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.CreateGraphics().Clear(Form1.DefaultBackColor);
            pictureBox2.CreateGraphics().Clear(Form1.DefaultBackColor);

            if (flag == 0)
            {
                Drowa.renumb(t1, t2);
                Drowb.renumb(t3, t4);

                pn.setGraphics(pictureBox1.CreateGraphics());
                Drowa.Paint();
                pn.setGraphics(pictureBox2.CreateGraphics());
                Drowb.Paint();

            }
            else if (flag == 1)
            {
                Dcola.renumb(t1, t2);
                Dcolb.renumb(t3, t4);

                pn.setGraphics(pictureBox1.CreateGraphics());
                Dcola.Paint();
                pn.setGraphics(pictureBox2.CreateGraphics());
                Dcolb.Paint();
            }
            else if (flag == 2)
            {
                Dtrna.transpose();
                Dtrnb.transpose();

                pn.setGraphics(pictureBox1.CreateGraphics());
                Dtrna.Paint();
                pn.setGraphics(pictureBox2.CreateGraphics());
                Dtrnb.Paint();
            }
            else if (flag == 3)
            {
                pn.setGraphics(pictureBox1.CreateGraphics());
                v1.Paint();
                pn.setGraphics(pictureBox2.CreateGraphics());
                v2.Paint();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            flag = 3;

            Drowa = new Decorator_renumbRows(v1);
            Drowb = new Decorator_renumbRows(v2);

            Dcola = new Decorator_renumbCols(v1);
            Dcolb = new Decorator_renumbCols(v2);

            Dtrna = new Decorator_Transpose(v1);
            Dtrnb = new Decorator_Transpose(v2);

            pn.setGraphics(pictureBox1.CreateGraphics());
            v1.Paint();
            pn.setGraphics(pictureBox2.CreateGraphics());
            v2.Paint();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            init();

            pn.setGraphics(pictureBox1.CreateGraphics());
            v1.Paint();
            pn.setGraphics(pictureBox2.CreateGraphics());
            v2.Paint();

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                pictureBox1.CreateGraphics().Clear(Form1.DefaultBackColor);
                pictureBox2.CreateGraphics().Clear(Form1.DefaultBackColor);

                p = new CSPainter();
                p.setDefaultColors();
                pn.changePainter(p);

                _Paint();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                pictureBox1.CreateGraphics().Clear(Form1.DefaultBackColor);
                pictureBox2.CreateGraphics().Clear(Form1.DefaultBackColor);

                p = new C_Painter();
                p.setDefaultColors();
                pn.changePainter(p);

                _Paint();
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                pictureBox1.CreateGraphics().Clear(Form1.DefaultBackColor);
                pictureBox2.CreateGraphics().Clear(Form1.DefaultBackColor);

                p = new _SPainter();
                p.setDefaultColors();
                pn.changePainter(p);

                _Paint();
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                pictureBox1.CreateGraphics().Clear(Form1.DefaultBackColor);
                pictureBox2.CreateGraphics().Clear(Form1.DefaultBackColor);

                p = new __Painter();
                p.setDefaultColors();
                pn.changePainter(p);

                _Paint();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //command = new writeValtoMatrix(v2);
            //Manager_command.Instance.registerCommand(command);
            Manager_command.Instance.registerCommand(new writeValtoMatrix(v2));
            _Paint();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Manager_command.Instance.cancelLastCommand();
            _Paint();
        }

        private void init()
        {
            IMatrix q1, q2, q3, q4, q5, q6;
            ACompMatrix h1, h2, h3;

            p = new CSPainter();
            p.setDefaultColors();
            pn = new DecPainter(p);

            q1 = new Matrix(2, 2, pn);
            q2 = new Matrix(4, 3, pn);
            q3 = new Matrix(1, 3, pn);
            q4 = new Matrix(2, 4, pn);
            q5 = new Matrix(2, 3, pn);
            q6 = new Matrix(1, 1, pn);

            initMatrix.fill(q1, 4, Max);
            initMatrix.fill(q2, 12, Max);
            initMatrix.fill(q3, 3, Max);
            initMatrix.fill(q4, 8, Max);
            initMatrix.fill(q5, 6, Max);
            initMatrix.fill(q6, 1, Max);

            h1 = new HorMatrix(pn);
            h2 = new HorMatrix(pn);
            h3 = new HorMatrix(pn);
            v1 = new VerMatrix(pn);

            h1.add(q1);
            h1.add(q2);
            h1.add(q3);

            h2.add(q4);
            h2.add(q5);

            h3.add(q6);

            v1.add(h1);
            v1.add(h2);
            v1.add(h3);

            q1 = new Sp_Matrix(2, 2, pn);
            q2 = new Sp_Matrix(4, 3, pn);
            q3 = new Sp_Matrix(1, 3, pn);
            q4 = new Sp_Matrix(2, 4, pn);
            q5 = new Sp_Matrix(2, 3, pn);
            q6 = new Sp_Matrix(1, 1, pn);

            initMatrix.fill(q1, 4, Max);
            initMatrix.fill(q2, 12, Max);
            initMatrix.fill(q3, 3, Max);
            initMatrix.fill(q4, 8, Max);
            initMatrix.fill(q5, 6, Max);
            initMatrix.fill(q6, 1, Max);

            h1 = new HorMatrix(pn);
            h2 = new HorMatrix(pn);
            h3 = new HorMatrix(pn);
            v2 = new VerMatrix(pn);

            h1.add(q1);
            h1.add(q2);
            h1.add(q3);

            h2.add(q4);
            h2.add(q5);

            h3.add(q6);

            v2.add(h1);
            v2.add(h2);
            v2.add(h3);

            Drowa = new Decorator_renumbRows(v1);
            Drowb = new Decorator_renumbRows(v2);

            Dcola = new Decorator_renumbCols(v1);
            Dcolb = new Decorator_renumbCols(v2);

            Dtrna = new Decorator_Transpose(v1);
            Dtrnb = new Decorator_Transpose(v2);

            Drowa.setPainter(pn);
            Drowb.setPainter(pn);
            Dcola.setPainter(pn);
            Dcolb.setPainter(pn);
            Dtrna.setPainter(pn);
            Dtrnb.setPainter(pn);

            Manager_command.Instance.registerCommand(new Init_app(v2));
        }

        void _Paint()
        {
            if (flag == 0)
            {
                pn.setGraphics(pictureBox1.CreateGraphics());
                Drowa.Paint();
                pn.setGraphics(pictureBox2.CreateGraphics());
                Drowb.Paint();
            }
            else if (flag == 1)
            {
                pn.setGraphics(pictureBox1.CreateGraphics());
                Dcola.Paint();
                pn.setGraphics(pictureBox2.CreateGraphics());
                Dcolb.Paint();
            }
            else if (flag == 2)
            {
                pn.setGraphics(pictureBox1.CreateGraphics());
                Dtrna.Paint();
                pn.setGraphics(pictureBox2.CreateGraphics());
                Dtrnb.Paint();
            }
        }
    }
}
