using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4
{
    delegate double Function(double x);
    class Program
    {      
        static void Main(string[] args)
        {
            Function F = x => Math.Pow(x, 4) + 4 * Math.Pow(x, 3) - 3 * Math.Pow(x, 2) - 36 * x + 45;
            Class1 Method = new Class1(F, new double[2] {1, 2}, Math.Pow(10, -2));
            Method.Duhot();
            Console.WriteLine(Method.ToString());
            Method.Lokal();
            Console.WriteLine(Method.ToString());
            Method.Golt();
            Console.WriteLine(Method.ToString());
            Method.Fibonacci();
            Console.WriteLine(Method.ToString());
            Console.ReadKey();
        }
    }
}
