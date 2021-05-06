using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab2;

namespace PrintToFile
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var n = 1;
            var array = new double[] { 0 };

            //Lab2.Program.PrintToFile(array, n);

            string[] expected = { "0" };
            string[] result = File.ReadAllLines("test.txt").ToArray();
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(System.IndexOutOfRangeException))]
        public void TestMethod2()
        {
            var n = 3;
            var array = new double[] { 0, 1 };

            //Lab2.Write(array, n);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void TestMethod3()
        {
            var n = 0;
            var array = new double[] { };

            //Lab2.Write(array, n);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var n = 2;
            var array = new double[] { 0, 1 };

            //Lab2.Write(array, n);

            string[] expected = { "0", "1" };
            string[] result = File.ReadAllLines("output.txt").ToArray();
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
