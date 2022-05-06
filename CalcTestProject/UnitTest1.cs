using Microsoft.VisualStudio.TestTools.UnitTesting;
using Windows7_Calc;

namespace CalcTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            CalcHandle Calc = new CalcHandle();
            Calc.AddDigit("6");
            Calc.AddDigit("4");
            Calc.AddDigit("0");
            Calc.AddDigit("2");
            Calc.AddDigit("3");
            Calc.AddDigit("4");
            Calc.AddDigit("5");
            Calc.AddDigit("7");

            Assert.AreEqual("64023457", Calc.ActiveVariable);
        }
        [TestMethod]
        public void TestMethod2()
        {
            CalcHandle Calc = new CalcHandle();
            Calc.AddDigit("6");
            Calc.AddDigit("4");
            Calc.AddDigit("0");
            Calc.AddDigit("2");
            Calc.RemoveDigit();
            Calc.AddComma(",");
            Calc.AddDigit("3");
            Calc.AddComma(",");
            Calc.AddDigit("4");
            Calc.AddDigit("5");
            Calc.AddComma(",");
            Calc.AddDigit("7");
            Calc.RemoveDigit();

            Assert.AreEqual("640,345", Calc.ActiveVariable);
        }
        [TestMethod]
        public void TestMethod3()
        {
            CalcHandle Calc = new CalcHandle();
            Calc.AddDigit("6");
            Calc.AddDigit("4");
            Calc.AddDigit("0");
            Calc.AddDigit("2");
            Calc.AddComma(",");
            Calc.AddDigit("3");

            Calc.Addition();

            Calc.AddDigit("3");
            Calc.AddComma(",");
            Calc.AddDigit("4");
            Calc.AddDigit("5");
            Calc.AddDigit("7");

            Calc.Equals();
            Assert.AreEqual("6405,757", Calc.ActiveVariable);
        }
        [TestMethod]
        public void TestMethod4()
        {
            CalcHandle Calc = new CalcHandle();
            Calc.AddDigit("6");
            Calc.AddDigit("4");
            Calc.AddDigit("0");
            Calc.AddDigit("2");
            Calc.AddComma(",");
            Calc.AddDigit("3");

            Calc.Subtraction();

            Calc.AddDigit("9");
            Calc.AddDigit("3");
            Calc.AddDigit("3");
            Calc.AddDigit("3");
            Calc.AddComma(",");
            Calc.AddDigit("4");
            Calc.AddDigit("5");
            Calc.AddDigit("7");

            Calc.Equals();
            Assert.AreEqual("-2931,157", Calc.ActiveVariable);
        }
        [TestMethod]
        public void TestMethod5()
        {
            CalcHandle Calc = new CalcHandle();
            Calc.AddDigit("6");
            Calc.AddDigit("4");
            Calc.AddDigit("0");
            Calc.AddDigit("2");
            Calc.AddComma(",");
            Calc.AddDigit("3");

            Calc.Multiplication();

            Calc.AddDigit("9");
            Calc.AddDigit("3");
            Calc.AddDigit("3");
            Calc.AddDigit("3");
            Calc.AddComma(",");
            Calc.AddDigit("4");
            Calc.AddDigit("5");
            Calc.AddDigit("7");

            Calc.Equals();
            Assert.AreEqual("59755591,7511", Calc.ActiveVariable);
        }
        [TestMethod]
        public void TestMethod6()
        {
            CalcHandle Calc = new CalcHandle();
            Calc.AddDigit("9");
            Calc.AddDigit("9");
            Calc.AddDigit("9");
            Calc.AddDigit("9");
            Calc.AddDigit("9");
            Calc.AddDigit("9");
            Calc.AddDigit("9");
            Calc.AddDigit("9");
            Calc.AddDigit("9");
            Calc.AddDigit("9");
            Calc.AddDigit("9");
            Calc.AddDigit("9");
            Calc.AddDigit("9");
            Calc.AddDigit("9");
            Calc.AddDigit("9");

            Calc.Multiplication();

            Calc.AddDigit("9");
            Calc.AddDigit("9");
            Calc.AddDigit("9");
            Calc.AddDigit("9");
            Calc.AddDigit("9");
            Calc.AddDigit("9");
            Calc.AddDigit("9");
            Calc.AddDigit("9");
            Calc.AddDigit("9");
            Calc.AddDigit("9");
            Calc.AddDigit("9");
            Calc.AddDigit("9");
            Calc.AddDigit("9");
            Calc.AddDigit("9");
            Calc.AddDigit("9");

            Calc.Equals();
            Assert.AreEqual("9,99999999999998E+29", Calc.ActiveVariable);
        }
    }
}