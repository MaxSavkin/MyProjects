using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Soliton
{
    class osc
    {
        public double phi { set; get; }
        public double dphi { set; get; }
        public double gamma { set; get; }
        public double lamda { set; get; }

        private double d;
        private double dt;

        public double Prev_phi { set; get; }
        public double Next_phi { set; get; }

        public osc(double phi, double dphi, double gamma, double lamda, double dt, double d)
        {
            this.phi = phi;
            this.dphi = dphi;
            this.d = d;
            this.gamma = gamma;
            this.lamda = lamda;
            this.dt = dt;
        }

        private double dPhi(double _phi, double _dphi)
        {
            return _dphi;
        }

        private double ddPhi(double _phi, double _dphi)
        {
            return -lamda * _dphi - Math.Sin(_phi) + gamma + d * (Math.Sin(Prev_phi - _phi) + Math.Sin(Next_phi - _phi));
        }

        public void next()
        {
            double[] X = new double[4];
            double[] Y = new double[4];

            X[0] = dPhi(phi, dphi) * dt;
            Y[0] = ddPhi(phi, dphi) * dt;

            X[1] = dPhi(phi + X[0] / 2, dphi + Y[0] / 2) * dt;
            Y[1] = ddPhi(phi + X[0] / 2, dphi + Y[0] / 2) * dt;

            X[2] = dPhi(phi + X[1] / 2, dphi + Y[1] / 2) * dt;
            Y[2] = ddPhi(phi + X[1] / 2, dphi + Y[1] / 2) * dt;

            X[3] = dPhi(phi + X[2], dphi + Y[2]) * dt;
            Y[3] = ddPhi(phi + X[2], dphi + Y[2]) * dt;

            phi = phi + (X[0] + 2 * X[1] + 2 * X[2] + X[3]) / 6;
            dphi = dphi + (Y[0] + 2 * Y[1] + 2 * Y[2] + Y[3]) / 6;

        }
    }
}
