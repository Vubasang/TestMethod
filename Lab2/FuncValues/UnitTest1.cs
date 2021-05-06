using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab2;
using System.Collections.Generic;

namespace FuncValues
{
    [TestClass]
    public class UnitTest1
    {
        double delta = 0.000001;
        [TestMethod]
        public void TestMethod1()
        {
            int n = 2;
            double x1 = 4;
            double x2 = 10;
            double a = 6;
            double b = 4;
            List<double> result = Program.FuncValues(n, x1, x2, a, b);
            Assert.AreEqual(1.9378175680, result[0], delta, "Не подходит к ожидаемому результату");
            Assert.AreEqual(2.6523732949, result[1], delta, "Не подходит к ожидаемому результату");
        }

        [TestMethod]
        public void TestMethod2()
        {
            int n = 3;
            double x1 = 3;
            double x2 = 9;
            double a = 3;
            double b = 5;
            List<double> result = Program.FuncValues(n, x1, x2, a, b);
            Assert.AreEqual(0.646923469682105, result[0], delta, "Не подходит к ожидаемому результату");
            Assert.AreEqual(0.851005102335166, result[1], delta, "Не подходит к ожидаемому результату");
            Assert.AreEqual(0.970385204523157, result[2], delta, "Не подходит к ожидаемому результату");
        }

        //Граничные значения
        [TestMethod]
        public void TestMethod3()
        {
            int n = 1;
            double x1 = 0.0001;
            double x2 = 0.0002;
            double a = 5.0001;
            double b = 3.0001;
            List<double> result = Program.FuncValues(n, x1, x2, a, b);
            Assert.AreEqual(6523.7028981414, result[0], delta, "Не подходит к ожидаемому результату");
        }

        [TestMethod]
        public void TestMethod4()
        {
            int n = 1;
            double x1 = 0.9999;
            double x2 = 1.0000;
            double a = 3.9999;
            double b = 2.9999;
            List<double> result = Program.FuncValues(n, x1, x2, a, b);
            Assert.AreEqual(883.5164922665, result[0], delta, "Не подходит к ожидаемому результату");
        }

        [TestMethod]
        public void TestMethod5()
        {
            int n = 1;
            double x1 = 1;
            double x2 = 2;
            double a = 3.3820;
            double b = 4;
            List<double> result = Program.FuncValues(n, x1, x2, a, b);
            Assert.AreEqual(-7813.4462366452, result[0], delta, "Не подходит к ожидаемому результату");
        }

        [TestMethod]
        public void TestMethod6()
        {
            int n = 1;
            double x1 = 1;
            double x2 = 2;
            double a = 5.6180;
            double b = 4;
            List<double> result = Program.FuncValues(n, x1, x2, a, b);
            Assert.AreEqual(-7813.4462366452, result[0], delta, "Не подходит к ожидаемому результату");
        }

        [TestMethod]
        public void TestMethod7()
        {
            int n = 2;
            double x1 = 1.0000;
            double x2 = 1.0001;
            double a = 3.9999;
            double b = 2.9999;
            List<double> result = Program.FuncValues(n, x1, x2, a, b);
            Assert.AreEqual(883.5969247464, result[0], delta, "Не подходит к ожидаемому результату");
            Assert.AreEqual(883.6773491833, result[1], delta, "Не подходит к ожидаемому результату");
        }

        [TestMethod]
        public void TestMethod8()
        {
            int n = 3;
            double x1 = 0.0001;
            double x2 = 0.0002;
            double a = 5.0001;
            double b = 3.0001;
            List<double> result = Program.FuncValues(n, x1, x2, a, b);
            Assert.AreEqual(6523.7028981414, result[0], delta, "Не подходит к ожидаемому результату");
            Assert.AreEqual(6197.6153032794, result[1], delta, "Не подходит к ожидаемому результату");
            Assert.AreEqual(5966.2524727551, result[2], delta, "Не подходит к ожидаемому результату");
        }

        [TestMethod]
        public void TestMethod9()
        {
            int n = 3;
            double x1 = 0.9999;
            double x2 = 1.0000;
            double a = 3.9999;
            double b = 2.9999;
            List<double> result = Program.FuncValues(n, x1, x2, a, b);
            Assert.AreEqual(883.5164922665, result[0], delta, "Не подходит к ожидаемому результату");
            Assert.AreEqual(883.5567095119, result[1], delta, "Не подходит к ожидаемому результату");
            Assert.AreEqual(883.5969247464, result[2], delta, "Не подходит к ожидаемому результату");
        }

        [TestMethod]
        public void TestMethod10()
        {
            int n = 3;
            double x1 = 1;
            double x2 = 2;
            double a = 5.6180;
            double b = 4;
            List<double> result = Program.FuncValues(n, x1, x2, a, b);
            Assert.AreEqual(-7813.4462366452, result[0], delta, "Не подходит к ожидаемому результату");
            Assert.AreEqual(-10697.1567646601, result[1], delta, "Не подходит к ожидаемому результату");
            Assert.AreEqual(-12743.1819452757, result[2], delta, "Не подходит к ожидаемому результату");
        }

        // Неправильные классы
        [TestMethod]
        public void TestMethod11()
        {
            int n = 3;
            double x1 = 1;
            double x2 = 2;
            double a = 4.5;
            double b = 4;
            List<double> result = Program.FuncValues(n, x1, x2, a, b);
            Assert.AreEqual("Входные данные не лежат в ОДЗ", result);
        }

        [TestMethod]
        public void TestMethod12()
        {
            int n = 3;
            double x1 = 1;
            double x2 = 2;
            double a = (9 + Math.Sqrt(5)) / 2;
            double b = 4;
            List<double> result = Program.FuncValues(n, x1, x2, a, b);
            Assert.AreEqual("Входные данные не лежат в ОДЗ", result);
        }

        [TestMethod]
        public void TestMethod13()
        {
            int n = 3;
            double x1 = 1;
            double x2 = 2;
            double a = (9 - Math.Sqrt(5)) / 2;
            double b = 4;
            List<double> result = Program.FuncValues(n, x1, x2, a, b);
            Assert.AreEqual("Входные данные не лежат в ОДЗ", result);
        }

        [TestMethod]
        public void TestMethod14()
        {
            int n = 3;
            double x1 = 1;
            double x2 = 2;
            double a = 4.5;
            double b = 3;
            List<double> result = Program.FuncValues(n, x1, x2, a, b);
            Assert.AreEqual("Входные данные не лежат в ОДЗ", result);
        }
    }
}
