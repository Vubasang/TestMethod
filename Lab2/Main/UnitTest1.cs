using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab2;
using System.IO;
using System.Text;

namespace Main
{
    [TestClass]
    public class Main
    {
        [TestMethod]
        public void TestMethod1()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "lab2.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardError = true;
            p.Start();

            p.StandardInput.WriteLine("6"); // значение a
            p.StandardInput.WriteLine("4"); // значение b
            p.StandardInput.WriteLine("2"); // значение n
            p.StandardInput.WriteLine("4"); // значение x1
            p.StandardInput.WriteLine("10"); // значение x2

            var result = File.ReadAllLines("test.txt");
            p.Close();
            Assert.AreEqual("1,937817568\n2,6523732949",
                Math.Round(Convert.ToDouble(result[0]), 10).ToString() + "\n" +
                Math.Round(Convert.ToDouble(result[1]), 10).ToString());
        }

        [TestMethod]
        public void TestMethod2()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "lab2.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardError = true;
            p.Start();

            p.StandardInput.WriteLine("3"); // значение a
            p.StandardInput.WriteLine("5"); // значение b
            p.StandardInput.WriteLine("3"); // значение n
            p.StandardInput.WriteLine("3"); // значение x1
            p.StandardInput.WriteLine("9"); // значение x2

            var result = File.ReadAllLines("test.txt");
            p.Close();
            Assert.AreEqual("0,6469234697\n0,8510051023\n0,9703852045",
                Math.Round(Convert.ToDouble(result[0]), 10).ToString() + "\n" +
                Math.Round(Convert.ToDouble(result[1]), 10).ToString() + "\n" +
                Math.Round(Convert.ToDouble(result[2]), 10).ToString());
        }

        // Граничные значения
        [TestMethod]
        public void TestMethod3()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "lab2.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardError = true;
            p.Start();

            p.StandardInput.WriteLine("5,0001"); // значение a
            p.StandardInput.WriteLine("3,0001"); // значение b
            p.StandardInput.WriteLine("1"); // значение n
            p.StandardInput.WriteLine("0,0001"); // значение x1
            p.StandardInput.WriteLine("0,0002"); // значение x2

            var result = File.ReadAllLines("test.txt");
            p.Close();
            Assert.AreEqual("6523,7028981", Math.Round(Convert.ToDouble(result[0]), 7).ToString());
        }

        [TestMethod]
        public void TestMethod4()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "lab2.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardError = true;
            p.Start();

            p.StandardInput.WriteLine("3,9999"); // значение a
            p.StandardInput.WriteLine("2,9999"); // значение b
            p.StandardInput.WriteLine("1"); // значение n
            p.StandardInput.WriteLine("0,9999"); // значение x1
            p.StandardInput.WriteLine("1,0000"); // значение x2

            var result = File.ReadAllLines("test.txt");
            p.Close();
            Assert.AreEqual("883,5164923", Math.Round(Convert.ToDouble(result[0]), 7).ToString());
        }

        [TestMethod]
        public void TestMethod5()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "lab2.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardError = true;
            p.Start();

            p.StandardInput.WriteLine("3,3820"); // значение a
            p.StandardInput.WriteLine("4"); // значение b
            p.StandardInput.WriteLine("1"); // значение n
            p.StandardInput.WriteLine("1"); // значение x1
            p.StandardInput.WriteLine("2"); // значение x2

            var result = File.ReadAllLines("test.txt");
            p.Close();
            Assert.AreEqual("-7813,4462366", Math.Round(Convert.ToDouble(result[0]), 7).ToString());
        }

        [TestMethod]
        public void TestMethod6()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "lab2.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardError = true;
            p.Start();

            p.StandardInput.WriteLine("5,6180"); // значение a
            p.StandardInput.WriteLine("4"); // значение b
            p.StandardInput.WriteLine("1"); // значение n
            p.StandardInput.WriteLine("1"); // значение x1
            p.StandardInput.WriteLine("2"); // значение x2

            var result = File.ReadAllLines("test.txt");
            p.Close();
            Assert.AreEqual("-7813,4462366", Math.Round(Convert.ToDouble(result[0]), 7).ToString());
        }

        // неправильные тесты
        [TestMethod]
        public void TestMethod7()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "lab2.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.StandardErrorEncoding = Encoding.UTF8;
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            p.Start();

            p.StandardInput.WriteLine("1"); // значение a
            p.StandardInput.WriteLine("4"); // значение b
            p.StandardInput.WriteLine("0"); // значение n
            p.StandardInput.WriteLine("4"); // значение x1
            p.StandardInput.WriteLine("108"); // значение x2

            string[] temp = p.StandardOutput.ReadLine().Split(':');
            string result = temp[temp.Length - 1].Trim();
            p.WaitForExit();
            p.Close();
            Assert.AreEqual("n не может быть меньше единицы", result);
        }

        [TestMethod]
        public void TestMethod8()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "lab2.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.StandardErrorEncoding = Encoding.UTF8;
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            p.Start();

            p.StandardInput.WriteLine("1"); // значение a
            p.StandardInput.WriteLine("4"); // значение b
            p.StandardInput.WriteLine("40"); // значение n
            p.StandardInput.WriteLine("-1"); // значение x1
            p.StandardInput.WriteLine("108"); // значение x2

            string[] temp = p.StandardOutput.ReadLine().Split(':');
            string result = temp[temp.Length - 1].Trim();
            p.WaitForExit();
            p.Close();
            Assert.AreEqual("x1 не может быть меньше нуля", result);
        }

        [TestMethod]
        public void TestMethod9()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "lab2.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.StandardErrorEncoding = Encoding.UTF8;
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            p.Start();

            p.StandardInput.WriteLine("1"); // значение a
            p.StandardInput.WriteLine("4"); // значение b
            p.StandardInput.WriteLine("40"); // значение n
            p.StandardInput.WriteLine("4"); // значение x1
            p.StandardInput.WriteLine("2"); // значение x2

            string[] temp = p.StandardOutput.ReadLine().Split(':');
            string result = temp[temp.Length - 1].Trim();
            p.WaitForExit();
            p.Close();
            Assert.AreEqual("x1 должен быть строго меньше x2", result);
        }

        [TestMethod]
        public void TestMethod10()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "lab2.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.StandardErrorEncoding = Encoding.UTF8;
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            p.Start();

            double a = (9 - Math.Sqrt(5)) / 2;
            
            p.StandardInput.WriteLine(a.ToString("F10")); // значение a
            p.StandardInput.WriteLine("8"); // значение b
            p.StandardInput.WriteLine("40"); // значение n
            p.StandardInput.WriteLine("4"); // значение x1
            p.StandardInput.WriteLine("108"); // значение x2

            string[] temp = p.StandardOutput.ReadLine().Split(':');
            string result = temp[temp.Length - 1].Trim();
            p.WaitForExit();
            p.Close();
            Assert.AreEqual("Значение a не входит в ОДЗ функции", result);
        }

        [TestMethod]
        public void TestMethod11()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "lab2.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.StandardErrorEncoding = Encoding.UTF8;
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            p.Start();

            // double a = (9 - Math.Sqrt(5)) / 2;
            p.StandardInput.WriteLine("6"); // значение a
            p.StandardInput.WriteLine("3"); // значение b
            p.StandardInput.WriteLine("40"); // значение n
            p.StandardInput.WriteLine("4"); // значение x1
            p.StandardInput.WriteLine("108"); // значение x2

            string[] temp = p.StandardOutput.ReadLine().Split(':');
            string result = temp[temp.Length - 1].Trim();
            p.WaitForExit();
            p.Close();
            Assert.AreEqual("Значение b не входит в ОДЗ функции", result);
        }

        [TestMethod]
        public void TestMethod12()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "lab2.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.StandardErrorEncoding = Encoding.UTF8;
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            p.Start();

            p.StandardInput.WriteLine("5,0000"); // значение a
            p.StandardInput.WriteLine("2,9999"); // значение b
            p.StandardInput.WriteLine("2"); // значение n
            p.StandardInput.WriteLine("0,9999"); // значение x1
            p.StandardInput.WriteLine("1,0001"); // значение x2

            string[] temp = p.StandardOutput.ReadLine().Split(':');
            string result = temp[temp.Length - 1].Trim();
            p.WaitForExit();
            p.Close();
            Assert.AreEqual("Значение a не входит в ОДЗ функции", result);
        }

        [TestMethod]
        public void TestMethod13()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "lab2.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.StandardErrorEncoding = Encoding.UTF8;
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            p.Start();

            p.StandardInput.WriteLine("3,9999"); // значение a
            p.StandardInput.WriteLine("3,0000"); // значение b
            p.StandardInput.WriteLine("1"); // значение n
            p.StandardInput.WriteLine("0,9999"); // значение x1
            p.StandardInput.WriteLine("1,0001"); // значение x2

            string[] temp = p.StandardOutput.ReadLine().Split(':');
            string result = temp[temp.Length - 1].Trim();
            p.WaitForExit();
            p.Close();
            Assert.AreEqual("Значение b не входит в ОДЗ функции", result);
        }

        [TestMethod]
        public void TestMethod14()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "lab2.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.StandardErrorEncoding = Encoding.UTF8;
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            p.Start();

            p.StandardInput.WriteLine("3,3820"); // значение a
            p.StandardInput.WriteLine("3,0001"); // значение b
            p.StandardInput.WriteLine("2"); // значение n
            p.StandardInput.WriteLine("1,0001"); // значение x1
            p.StandardInput.WriteLine("1,0000"); // значение x2

            string[] temp = p.StandardOutput.ReadLine().Split(':');
            string result = temp[temp.Length - 1].Trim();
            p.WaitForExit();
            p.Close();
            Assert.AreEqual("x1 должен быть строго меньше x2", result);
        }

        [TestMethod]
        public void TestMethod15()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "lab2.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.StandardErrorEncoding = Encoding.UTF8;
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            p.Start();

            p.StandardInput.WriteLine("6"); // значение a
            p.StandardInput.WriteLine("4"); // значение b
            p.StandardInput.WriteLine("0"); // значение n
            p.StandardInput.WriteLine("0,0001"); // значение x1
            p.StandardInput.WriteLine("1,0000"); // значение x2

            string[] temp = p.StandardOutput.ReadLine().Split(':');
            string result = temp[temp.Length - 1].Trim();
            p.WaitForExit();
            p.Close();
            Assert.AreEqual("n не может быть меньше единицы", result);
        }

        [TestMethod]
        public void TestMethod16()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "lab2.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.StandardErrorEncoding = Encoding.UTF8;
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            p.Start();

            p.StandardInput.WriteLine("4,0001"); // значение a
            p.StandardInput.WriteLine("4"); // значение b
            p.StandardInput.WriteLine("1"); // значение n
            p.StandardInput.WriteLine("1"); // значение x1
            p.StandardInput.WriteLine("2"); // значение x2

            string[] temp = p.StandardOutput.ReadLine().Split(':');
            string result = temp[temp.Length - 1].Trim();
            p.WaitForExit();
            p.Close();
            Assert.AreEqual("Значение a не входит в ОДЗ функции", result);
        }
    }
}
