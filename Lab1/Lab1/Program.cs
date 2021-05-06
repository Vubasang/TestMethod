using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static int n;
        static double x, x1, x2, step;
        static double a, b;
        static string path = @"output.txt";

        static void Main(string[] args)
        {
            input();
            x = x1;
            step = (x2 - x1) / n;
            if (ODZ())
            {
                Print(Ar());
            }
            else
            {
                File.WriteAllText(path, "incorect input");
            }
        }
        static void input()
        {
            n = Convert.ToInt32(Console.ReadLine());
            x1 = Convert.ToDouble(Console.ReadLine());
            x2 = Convert.ToDouble(Console.ReadLine());
            a = Convert.ToDouble(Console.ReadLine());
            b = Convert.ToDouble(Console.ReadLine());
        }
        static double FX(double x)
        {
            return (10 / (Math.Pow(b, 3) - 27)) * Math.Log10(Math.Sqrt(Math.Pow(a, 2) - 9 * a + 20)) * 3 * x;
        }

        static bool ODZ()
        {
            if (Math.Pow(b, 3) - 27 != 0 && (Math.Pow(a, 2) - 9 * a + 20) >= 0)
            {
                return true;
            }
            else return false;
        }

        static List<double> Ar()
        {
            List<double> list = new List<double>();
            for (int i = 0; i < n; i++)
            {
                list.Add(FX(x));
                x += step;
            }
            return list;
        }
        static void Print(List<double> list)
        {
            double[] array = list.ToArray();
            string text = "";

            for (int i = 0; i < array.Length; i++)
            {
                text += Convert.ToString(array[i]) + "\n";
            }
            File.WriteAllText(path, text);
        }
    }
}