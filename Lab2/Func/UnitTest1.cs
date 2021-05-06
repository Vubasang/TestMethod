using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab2;
using System.Collections.Generic;

namespace Func
{
    [TestClass]
    public class UnitTest1
    {
        double delta = 0.000001;
        [TestMethod]
        public void TestMethod1()
        {
            double a = 6;
            double b = 4;
            double x = 1;
            double result = Program.Func(x, a, b);
            Assert.AreEqual(0.8567364869, delta, result, "Не подходит к ожидаемому результату");
        }

        [TestMethod]
        [ExpectedException(typeof(System.DivideByZeroException))]
        public void TestMethod2()
        {
            double a = 6;
            double b = 3;
            double x = 2;
            double result = Program.Func(x, a, b);

            if (result == double.PositiveInfinity) throw new DivideByZeroException("Деление на 0!");
        }

        [TestMethod]
        public void TestMethod3()
        {
            double a = 3;
            double b = 5;
            double x = 2;
            double result = Program.Func(x, a, b);
            Assert.AreEqual(0.5275433675, delta, result, "Не подходит к ожидаемому результату");
        }
        // Неправильные классы
        [TestMethod]
        public void TestMethod4()
        {
            double a = 4.5;
            double b = 4;
            double x = 1;
            double result = Program.Func(x, a, b);
            Assert.AreEqual("Значение a не входит в ОДЗ функции", result);
        }

        [TestMethod]
        public void TestMethod5()
        {
            double a = (9 + Math.Sqrt(5)) / 2;
            double b = 8;
            double x = 1;
            double result = Program.Func(x, a, b);
            Assert.AreEqual("Значение a не входит в ОДЗ функции", result);
        }

        [TestMethod]
        public void TestMethod6()
        {
            double a = (9 - Math.Sqrt(5)) / 2;
            double b = 8;
            double x = 1;
            double result = Program.Func(x, a, b);
            Assert.AreEqual("Значение a не входит в ОДЗ функции", result);
        }

        [TestMethod]
        public void TestMethod7()
        {
            double a = 6;
            double b = 3;
            double x = 2;
            double result = Program.Func(x, a, b);
            Assert.AreEqual("Значение b не входит в ОДЗ функции", result);
        }

        [TestMethod]
        public void TestMethod8()
        {
            double a = 1;
            double b = 4;
            double x = -1;
            double result = Program.Func(x, a, b);
            Assert.AreEqual("x должен быть строго больше 0", result);
        }

        //Граничные значения
        //a > 5 or a< 4 && a != (9 - sqrt5) / 2 && a != (9 + sqrt5) / 2
        // b != 3
        [TestMethod]
        public void TestMethod9()
        {
            double a = 5.0001;
            double b = 3.0001;
            double x = 1.0;
            double result = Program.Func(x, a, b);
            Assert.AreEqual(-883.5380202482, result, delta, "Не подходит к ожидаемому результату");
        }

        [TestMethod]
        public void TestMethod10()
        {
            double a = 5.0001;
            double b = 3.0001;
            double x = 0.0001;
            double result = Program.Func(x, a, b);
            Assert.AreEqual(6523.7028981414, result, delta, "Не подходит к ожидаемому результату");
        }

        [TestMethod]
        public void TestMethod11()
        {
            double a = 3.9999;
            double b = 2.9999;
            double x = 1.0001;
            double result = Program.Func(x, a, b);
            Assert.AreEqual(883.6773491833, result, delta, "Не подходит к ожидаемому результату");
        }

        [TestMethod]
        public void TestMethod12()
        {
            double a = 3.3820; // (9 - sqrt5) / 2 = 3.381966011
            double b = 3.0001;
            double x = 1.0;
            double result = Program.Func(x, a, b);
            Assert.AreEqual(-107069583.1058335, result, "Не подходит к ожидаемому результату");
        }

        [TestMethod]
        public void TestMethod13()
        {
            double a = 3.3820; // (9 - sqrt5) / 2 = 3.381966011
            double b = 4;
            double x = 1;
            double result = Program.Func(x, a, b);
            Assert.AreEqual(-7813.4462366452, result, delta, "Не подходит к ожидаемому результату");
        }

        [TestMethod]
        public void TestMethod14()
        {
            double a = 5.6180; // (9 + sqrt5) / 2 = 5.618033989
            double b = 2.9999;
            double x = 1.0;
            double result = Program.Func(x, a, b);
            Assert.AreEqual(1.07076721316005 * Math.Pow(10, 8), result, delta, "Не подходит к ожидаемому результату");
        }

        [TestMethod]
        public void TestMethod15()
        {
            double a = 5.6180; // (9 + sqrt5) / 2 = 5.618033989
            double b = 4;
            double x = 1;
            double result = Program.Func(x, a, b);
            Assert.AreEqual(-7813.4462366452, result, delta, "Не подходит к ожидаемому результату");
        }
    }
}
