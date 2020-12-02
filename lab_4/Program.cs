using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4
{
    delegate double Function(double x);
    delegate double[] Method(double[] range1, double e, Function F);
    class Program
    {
        static string ToString(Method M, double[] range, double e, Function F)
        {
            long time = DateTime.Now.Ticks;
            double[] range_ = new double[2];
            Array.Copy(range, range_, 2);
            double[] res = M(range_, e, F);
            return (DateTime.Now.Ticks - time).ToString() + "\t" + res[0] + "\t" + res[1];
        }
        static void Main(string[] args)
        {
            double[] range = new double[2] { 1, 2 };
            double e = Math.Pow(10, -4);
            Function F = x => Math.Pow(x, 4) + 4 * Math.Pow(x, 3) - 3 * Math.Pow(x, 2) - 36 * x + 45;
            Console.WriteLine(ToString(LibraryOfMethods.Local, new double[2] { -100, 100 }, e, F));
            Console.WriteLine(ToString(LibraryOfMethods.Duhot, range, e, F));
            Console.WriteLine(ToString(LibraryOfMethods.Gold, range, e, F));
            Console.WriteLine(ToString(LibraryOfMethods.Fibonacci, range, e, F));
            Console.WriteLine(ToString(LibraryOfMethods.Parabola, range, e, F));
            Console.ReadKey();
        }
    }
}
