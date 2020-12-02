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
        static string ToString(Method M, double[] range1, double e, Function F)
        {
            long time = DateTime.Now.Ticks;
            double[] res = M(range1, e, F);
            return (DateTime.Now.Ticks - time).ToString() + "\t" + res[0] + "\t" + res[1];
        }
        static void Main(string[] args)
        {
            double[] range = new double[2] { 1, 2 },  range_ = new double[2];
            double e = Math.Pow(10, -4);
            Function F = x => Math.Pow(x, 4) + 4 * Math.Pow(x, 3) - 3 * Math.Pow(x, 2) - 36 * x + 45;
            Console.WriteLine(ToString(LibraryOfMethods.Local, new double[2] { -100, 100 }, e, F));
            Array.Copy(range, range_, 2);
            Console.WriteLine(ToString(LibraryOfMethods.Duhot, range_, e, F));
            Array.Copy(range, range_, 2);
            Console.WriteLine(ToString(LibraryOfMethods.Gold, range_, e, F));
            Array.Copy(range, range_, 2);
            Console.WriteLine(ToString(LibraryOfMethods.Fibonacci, range_, e, F));
            Array.Copy(range, range_, 2);
            Console.WriteLine(ToString(LibraryOfMethods.Parabola, range_, e, F));
            Console.ReadKey();
        }
    }
}
