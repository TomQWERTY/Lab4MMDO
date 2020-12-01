using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4
{
    delegate double Function(double x);
    delegate double Method(double[] range1, double e, Function F);
    class Program
    {
        static string ToString(Method M, double[] range1, double e, Function F)
        {
            long t = DateTime.Now.Ticks;
            double x = M(range1, e, F);
            return (DateTime.Now.Ticks - t).ToString() + "\t" + x.ToString() + "\t" + F(x);
        }
        static void Main(string[] args)
        {
            double[] range = new double[2] { 1, 2 };
            double e = Math.Pow(10, -4);
            Function F = x => Math.Pow(x, 4) + 4 * Math.Pow(x, 3) - 3 * Math.Pow(x, 2) - 36 * x + 45;
            Console.WriteLine(ToString(LibraryOfMethods.Duhot, range, e, F));
            Console.WriteLine(ToString(LibraryOfMethods.Lokal, range, e, F));
            Console.WriteLine(ToString(LibraryOfMethods.Golt, range, e, F));
            Console.WriteLine(ToString(LibraryOfMethods.Fibonacci, range, e, F));
            Console.ReadKey();
        }
    }
}
