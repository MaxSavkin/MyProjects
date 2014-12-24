using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using System.IO;

namespace Soliton
{
    public partial class Form1 : Form
    {
        private int N = 100;
        private osc[] _osc;
        private double[] phi0;
        private double[] dphi0;
        private double[] gamma;
        private double[] lamda;
        private double x0 = 6;
        private double y0 = 6;
        private double R = 5;
        private double[,] xy;
        private double[,] Dphi;
        private double[,] _phi;
        private int iMax = 50000;
        private string pFileName1, pFileName2, FileName2, FileName3, FileName, FileName1;
        int count = 0;

        private double d = 100;
        private double gam = 0;
        private double lam = 0;
        private double dt = 0.005;

        private double gamn = 1.05;
        private double lamn = 0;

        private void init()
        {
            pFileName1 = gam + "_" + lam + "_phi.txt";
            pFileName2 = gam + "_" + lam + "_dphi.txt";
            FileName2 = gam + "_" + lam + "_phi.txt";
            FileName3 = gam + "_" + lam + "_dphi.txt";
            FileName = gam + "_" + lam + ".txt";
            FileName1 = "_" + gam + "_" + lam + ".txt";

            _osc = new osc[N];
            phi0 = new double[N];
            dphi0 = new double[N];
            gamma = new double[N];
            lamda = new double[N];
            xy = new double[2, N];
            Dphi = new double[iMax, N];
            _phi = new double[iMax, N];

            for (int i = 0; i < N; i++)
            {

                phi0[i] = 4 * Math.Atan(Math.Exp(i - N / 2) * 1);
                //dphi0[i] = 0;
                dphi0[i] = 4 * Math.Exp(i - N / 2) / (1 + Math.Exp(2 * i - N));
                gamma[i] = gam;
                lamda[i] = lam;
            }

            //readFile();

            for (int i = 0; i < N; i++)
                _osc[i] = new osc(phi0[i], dphi0[i], gamma[i], lamda[i], dt, d);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            init();
        }

        private void calc()
        {
            count++;

            for (int i = 0; i < N; i++)
            {
                if (i == 0)
                {
                    _osc[i].Prev_phi = _osc[i].phi;
                    _osc[i].Next_phi = _osc[i + 1].phi;
                }
                else if (i == (N - 1))
                {
                    _osc[i].Prev_phi = _osc[i - 1].phi;
                    _osc[i].Next_phi = _osc[i].phi;
                }
                else
                {
                    _osc[i].Prev_phi = _osc[i - 1].phi;
                    _osc[i].Next_phi = _osc[i + 1].phi;
                }

                _osc[i].next();
            }

            for (int i = 0; i < N; i++)
                angle(_osc[i].phi, ref xy[0, i], ref xy[1, i]);
        }

        private void angle(double phi, ref double x, ref double y)
        {
            x = x0 + R * Math.Cos(phi);
            y = y0 - R * Math.Sin(phi);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            calc();
            zedGraphControl1.Invalidate();
        }

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    for (int i = 0; i < iMax; i++)
        //    {
        //        calc();
        //        for (int j = 0; j < N; j++)
        //        {
        //            Dphi[i, j] = _osc[j].dphi;
        //            _phi[i, j] = _osc[j].phi;
        //        }
        //    }
        //    timer1.Enabled = false;
        //    writeFile();
        //    writeFile1();
        //    writeFile2();
        //    label1.Text = "";
        //    label1.Text = label1.Text + "Ok   ";

        //    this.Close();
        //}

        //private void timer1_Tick(object sender, EventArgs e)
        //{

        //    for (; gam <= gamn; gam += 0.01)
        //    {
        //        for (int j = 0; j < N; j++)
        //            _osc[j].gamma = gam;

        //        for (int i = 0; i < iMax; i++)
        //        {
        //            calc();
        //            for (int j = 0; j < N; j++)
        //                Dphi[i, j] = _osc[j].dphi;
        //        }

        //        FileName = gam + "_" + lam + ".txt";
        //        FileName2 = gam + "_" + lam + "_phi.txt";
        //        FileName3 = gam + "_" + lam + "_dphi.txt";

        //        writeFile();
        //        writeFile1();
        //        writeFile2();
        //    }

        //    timer1.Enabled = false;
        //    this.Close();
        //}

        //private void timer1_Tick(object sender, EventArgs e)
        //{

        //    for (; lam >= lamn; lam -= 0.01)
        //    {
        //        for (int j = 0; j < N; j++)
        //            osc[j].setLamda(lam);

        //        //label2.Text = "";
        //        //label4.Text = label4.Text + pgam;
        //        for (int i = 0; i < 10000; i++)
        //        {
        //            calc();
        //            for (int j = 0; j < N; j++)
        //                Dphi[i, j] = osc[j].getdPhi();
        //        }
        //        FileName = gam + "_" + lam + ".txt";
        //        FileName2 = gam + "_" + lam + "_phi.txt";
        //        FileName3 = gam + "_" + lam + "_dphi.txt";
        //        writeFile();
        //        writeFile1();
        //        writeFile2();
        //    }

        //    timer1.Enabled = false;
        //    label2.Text = "";
        //    label2.Text = label2.Text + "Ok   ";
        //}

        private void zedGraphControl1_Paint(object sender, PaintEventArgs e)
        {
            GraphPane pane = zedGraphControl1.GraphPane;
            pane.CurveList.Clear();

            //Прорисовка осцилляторов
            PointPairList[] Points = new PointPairList[N];
            for (int i = 0; i < N; i++)
            {
                Points[i] = new PointPairList();
                Points[i].Add(xy[0, i], xy[1, i]);
                pane.AddCurve("", Points[i], Color.Black, SymbolType.Circle);


            }



            pane.XAxis.Scale.Min = x0 - R - 1;
            pane.YAxis.Scale.Min = y0 - R - 1;
            pane.XAxis.Scale.Max = x0 + R + 1;
            pane.YAxis.Scale.Max = y0 + R + 1;
            //pane.XAxis.Scale.Min = 0;
            //pane.YAxis.Scale.Min = -6;
            //pane.XAxis.Scale.Max = 100;
            //pane.YAxis.Scale.Max = 20;
            pane.Title.Text = "Осцилляторы";
            pane.XAxis.Title.Text = "Phi";
            pane.YAxis.Title.Text = "";
            zedGraphControl1.AxisChange();
        }

        private void writeFile()
        {
            BinaryWriter STG = new BinaryWriter(File.Open(FileName, FileMode.Create));
            BinaryWriter STG2 = new BinaryWriter(File.Open(FileName1, FileMode.Create));
            for (int i = 0; i < N; i++)
                for (int j = 0; j < iMax; j++)
                    if (j % 5 == 0)
                    {
                        STG.Write(Dphi[j, i]);
                        STG2.Write(_phi[j, i]);
                    }
            STG.Close();
            STG2.Close();
        }

        private void writeFile1()
        {
            BinaryWriter STG = new BinaryWriter(File.Open(FileName2, FileMode.Create));
            for (int i = 0; i < N; i++)
                STG.Write(_osc[i].phi);
            STG.Close();
        }

        private void writeFile2()
        {
            BinaryWriter STG = new BinaryWriter(File.Open(FileName3, FileMode.Create));
            for (int i = 0; i < N; i++)
                STG.Write(_osc[i].dphi);
            STG.Close();
        }

        private void readFile()
        {
            BinaryReader STG1 = new BinaryReader(File.Open(pFileName1, FileMode.Open));
            BinaryReader STG2 = new BinaryReader(File.Open(pFileName2, FileMode.Open));
            for (int i = 0; i < N; i++)
            {
                phi0[i] = STG1.ReadDouble();
                dphi0[i] = STG2.ReadDouble();
            }
            STG1.Close();
            STG2.Close();
        }
    }
}
