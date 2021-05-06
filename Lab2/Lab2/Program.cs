using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace Lab2
{
    public class Program
    {
        //Функция вычисления для заданного x.
        public static double Func(double x, double a, double b)
        {
            if ((Math.Pow(a, 2) - 9 * a + 20) <= 0 || (Math.Pow(a, 2) - 9 * a + 20) == 1)
            {
                Console.WriteLine("Значение a не входит в ОДЗ функции");
                Environment.Exit(0);
            }
            if (Math.Pow(b, 3) - 27 == 0)
            {
                Console.WriteLine("Значение b не входит в ОДЗ функции");
                Environment.Exit(0);
            }
            if (x <= 0)
            {
                Console.WriteLine("x должен быть строго больше 0");
                Environment.Exit(0);
            }
            return (10 / (Math.Pow(b, 3) - 27)) * (Math.Log(3 * x) / Math.Log(Math.Sqrt(Math.Pow(a, 2) - 9 * a + 20)));
        }

        //Функция вычисления массива значений функции для значений от x1 до x2
        public static List<double> FuncValues(int n, double x1, double x2, double a, double b)
        {
            var listOfValue = new List<double>();
            double[] mas = new double[n];
            if (n > 1)
            {
                for (int i = 0; i < n; i++)
                {
                    double d = (x2 - x1) / (n - 1);
                    mas[i] = x1 + d * i;
                    if (Math.Pow(b, 3) - 27 != 0 && (Math.Pow(a, 2) - 9 * a + 20) > 0 && (Math.Pow(a, 2) - 9 * a + 20) != 1)
                    {
                        try
                        {
                            listOfValue.Add(Func(mas[i], a, b));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            return null;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Входные данные не лежат в ОДЗ");
                        Environment.Exit(0);
                    }
                }
            }
            else if (n == 1)
            {
                listOfValue.Add(Func(x1, a, b));
            }
            return listOfValue;
        }

        //Функция сохранения заданного массива в заданный файл.
        public static void PrintToFile(List<double> listOfValue, string path)
        {
            FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate);
            var str = "";
            for (int i = 0; i < listOfValue.Count; i++)
            {
                str += Convert.ToString(listOfValue[i]) + "\n";
            }
            byte[] arr = Encoding.Default.GetBytes(str);
            fileStream.Write(arr, 0, arr.Length);
            fileStream.Close();
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Введите значение a: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Введите значение b: ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("Введите количество шагов n: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Введите значение x1: ");
            double x1 = double.Parse(Console.ReadLine());
            Console.Write("Введите значение x2: ");
            double x2 = double.Parse(Console.ReadLine());

            if (n < 1)
            {
                Console.WriteLine("n не может быть меньше единицы");
                Environment.Exit(0);
            }
            if (x1 < 0)
            {
                Console.WriteLine("x1 не может быть меньше нуля");
                Environment.Exit(0);
            }
            if (x1 >= x2)
            {
                Console.WriteLine("x1 должен быть строго меньше x2");
                Environment.Exit(0);
            }

            if ((Math.Pow(a, 2) - 9 * a + 20) <= 0 || (Math.Pow(a, 2) - 9 * a + 20) == 1)
            {
                Console.WriteLine("Значение a не входит в ОДЗ функции");
                Environment.Exit(0);
            }
            if (Math.Pow(b, 3) - 27 == 0)
            {
                Console.WriteLine("Значение b не входит в ОДЗ функции");
                Environment.Exit(0);
            }
            PrintToFile(FuncValues(n, x1, x2, a, b), "test.txt");
        }
    }
}
