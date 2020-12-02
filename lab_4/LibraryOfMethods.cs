using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4
{
    class LibraryOfMethods
    {                
        public static double[] Duhot(double[] range, double e, Function F)
        {
            double q = e / 3;
            do
            {
                double x1 = (range[1] + range[0] - q) / 2;
                double x2 = (range[1] + range[0] + q) / 2;
                if (F(x1) <= F(x2))
                {
                    range[1] = x2;
                }
                else
                {
                    range[0] = x1;
                }
            }
            while (range[1] - range[0] > e);
            double x = (range[0] + range[1]) / 2;
            return new double[2] { x, F(x) };
        }

        public static double[] Lokal(double[] range1, double e, Function F)
        {
            double[] res = LokalInside(range1, e, F);
            if (res[0] == 0)
            {
                return new double[2] { res[3], res[4] };
            }
            else
            {
                return new double[2] { res[1], F(res[1]) };
            }
        }

        private static double[] LokalInside(double[] range1, double e, Function F)
        {
            double[] res = new double[5];
            double h = (range1[1] - range1[0]) / 100;
            double x0 = range1[0] + h;
            double x1 = 0, x2 = 0;
            double f1 = F(x0);
            double f2;
            do
            {
                h /= 2;
                x2 = x0 + h;
                f2 = F(x2);
                if (f1 <= f2)
                {
                    h = -h;
                    x2 = x0 + h;
                    f2 = F(x2);
                }
            }
            while (f1 <= f2 && Math.Abs(h) >= e);
            if (Math.Abs(h) > e)
            {
                do
                {
                    x1 = x2;
                    f1 = f2;
                    x2 = x1 + h;
                    f2 = F(x2);
                } while (f1 >= f2);
                if (h > 0)
                {
                    range1[0] = x1 - h;
                    range1[1] = x2;
                }
                else
                {
                    range1[0] = x2;
                    range1[1] = x1 - h;
                }
                res[0] = 0;
            }
            else
            {
                res[0] = 1;
            }
            res[1] = x0;
            res[2] = x1;
            res[3] = range1[0];
            res[4] = range1[1];
            return res;
        }

        public static double[] Golt(double[] range1, double e, Function F)
        {
            double u = range1[0] + (3 - Math.Sqrt(5)) / 2 * (range1[1] - range1[0]);
            double v = range1[1] + range1[0] - u;
            double fu = F(u);
            double fv = F(v);
            do
            {
                if (fu <= fv)
                {
                    range1[1] = v;
                    v = u;
                    fv = fu;
                    u = range1[0] + range1[1] - v;
                    fu = F(u);
                }
                else
                {
                    range1[0] = u;
                    u = v;
                    fu = fv;
                    v = range1[0] + range1[1] - u;
                    fv = F(v);
                }
                if (u > v)
                {
                    u = range1[0] + (3 - Math.Sqrt(5)) / 2 * (range1[1] - range1[0]);
                    v = range1[1] + range1[0] - u;
                    fu = F(u);
                    fv = F(v);
                }
            }
            while (range1[1] - range1[0] >= e);
            double x = (range1[0] + range1[1]) / 2;
            return new double[2] { x, F(x) };
        }

        public static double[] Fibonacci(double[] range1, double e, Function F)
        {
            int n = Find_n(range1, e);
            double u = range1[0] + (FibonacciNumber(n) / FibonacciNumber(n + 2)) * (range1[1] - range1[0]);
            double v = range1[0] + range1[1] - u;
            double fu = F(u);
            double fv = F(v);
            for (int i = 1; i <= n; i++)
            {
                if (fu <= fv)
                {
                    range1[1] = v;
                    v = u;
                    fv = fu;
                    u = range1[0] + range1[1] - v;
                    fu = F(u);
                }
                else
                {
                    range1[0] = u;
                    u = v;
                    fu = fv;
                    v = range1[0] + range1[1] - u;
                    fv = F(v);
                }
                if (u > v)
                {
                    u = range1[0] + (FibonacciNumber(n - i + 1) / FibonacciNumber(n - i + 3)) * (range1[1] - range1[0]);
                    v = range1[0] + range1[1] - u;
                    fu = F(u);
                    fv = F(v);
                }
            }
            double x = (range1[0] + range1[1]) / 2;
            return new double[2] { x, F(x) };
        }

        private static double FibonacciNumber(int n)
        {
            double k5 = Math.Sqrt(5);
            return (Math.Pow((1 + k5) / 2, n) - Math.Pow((1 - k5) / 2, n)) / k5;
        }

        private static int Find_n(double[] range1, double e)
        {
            int f1 = 1;
            int f2 = 2;
            double temp = (range1[1] - range1[0]) / e;
            int n = 3;
            while (f2 < temp)
            {
                f2 += f1;
                f1 = f2 - f1;
                n++;
            }
            return n - 2;
        }

        public void Parabola(double[] range, double e, Function F)
        {

        }
    }
}
