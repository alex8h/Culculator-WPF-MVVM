using CalculWPFMVVM.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculWPFMVVM.Test
{
    [TestClass]
    public class CalculWPFMVVMTest
    {
        [TestMethod]
        public void Function_linear()
        {
            // Arrange.
            string f = "Линейная";
            int a = 5;
            int b = 8;
            int c = 2;
            int[] x = new int[] { 1, 3};
            int[] y = new int[] { 2, 4};
            int n = 2;
            int[] expacted = new int[] { 15, 25 };
            // Act.
            CalculatorModel obj = new CalculatorModel(n);
            int[] actual = new int[n];
            actual = obj.Function(f, a, b, c, x, y, n);
            // Assert.
            CollectionAssert.AreEqual(expacted, actual);
        }
        [TestMethod]
        public void Function_quadratic()
        {
            // Arrange.
            string f = "Квадратичная";
            int a = 16;
            int b = 32;
            int c = 30;
            int[] x = new int[] { 3 };
            int[] y = new int[] { 4 };
            int n = 1;
            int[] expacted = new int[] { 302 };
            // Act.
            CalculatorModel obj = new CalculatorModel(n);
            int[] actual = new int[n];
            actual = obj.Function(f, a, b, c, x, y, n);
            // Assert.
            CollectionAssert.AreEqual(expacted, actual);
        }
        [TestMethod]
        public void Function_cubic()
        {
            // Arrange.
            string f = "Кубическая";
            int a = -14;
            int b = 250;
            int c = 400;
            int[] x = new int[] { 5, 103, 244, 21 };
            int[] y = new int[] { 6, 405, 1941, 87 };
            int n = 4;
            int[] expacted = new int[] { 7650, 25708472, 738495674, 1762996 };
            // Act.
            CalculatorModel obj = new CalculatorModel(n);
            int[] actual = new int[n];
            actual = obj.Function(f, a, b, c, x, y, n);
            // Assert.
            CollectionAssert.AreEqual(expacted, actual);
        }
        [TestMethod]
        public void Function_quatro()
        {
            // Arrange.
            string f = "4-ой степени";
            int a = 1;
            int b = -100;
            int c = 1000;
            int[] x = new int[] { 7, 22, 7 };
            int[] y = new int[] { 8, 32, 15 };
            int n = 3;
            int[] expacted = new int[] { -47799, -3041544, -334099 };
            // Act.
            CalculatorModel obj = new CalculatorModel(n);
            int[] actual = new int[n];
            actual = obj.Function(f, a, b, c, x, y, n);
            // Assert.
            CollectionAssert.AreEqual(expacted, actual);
        }
        [TestMethod]
        public void Function_five()
        {
            // Arrange.
            string f = "5-ой степени"; 
            int a = 20;
            int b = 58;
            int c = 50000;
            int[] x = new int[] { 9, 7, 12, 6, 21 };
            int[] y = new int[] { 10, 14, 15, 12, 9 };
            int n = 5;
            int[] expacted = new int[] { 1810980, 2614268, 7962890, 1408208, 82112558 };
            // Act.
            CalculatorModel obj = new CalculatorModel(n);
            int[] actual = new int[n];
            actual = obj.Function(f, a, b, c, x, y, n);
            // Assert.
            CollectionAssert.AreEqual(expacted, actual);
        }
    }
}
