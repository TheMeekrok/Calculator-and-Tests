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
            Calc.AddComma();
            Calc.AddDigit("3");
            Calc.AddComma();
            Calc.AddDigit("4");
            Calc.AddDigit("5");
            Calc.AddComma();
            Calc.AddDigit("7");
            Calc.RemoveDigit();

            Assert.AreEqual("640,345", Calc.ActiveVariable);
        }
        [TestMethod]
        public void AdditionTest1()
        {
            CalcHandle Calc = new CalcHandle();
            Calc.AddDigit("6");
            Calc.AddDigit("4");
            Calc.AddDigit("0");
            Calc.AddDigit("2");
            Calc.AddComma();
            Calc.AddDigit("3");

            Calc.Addition();

            Calc.AddDigit("3");
            Calc.AddComma();
            Calc.AddDigit("4");
            Calc.AddDigit("5");
            Calc.AddDigit("7");

            Calc.Equals();
            Assert.AreEqual("6405,757", Calc.ActiveVariable);
        }
        [TestMethod]
        public void SubtractionTest1()
        {
            CalcHandle Calc = new CalcHandle();
            Calc.AddDigit("6");
            Calc.AddDigit("4");
            Calc.AddDigit("0");
            Calc.AddDigit("2");
            Calc.AddComma();
            Calc.AddDigit("3");

            Calc.Subtraction();

            Calc.AddDigit("9");
            Calc.AddDigit("3");
            Calc.AddDigit("3");
            Calc.AddDigit("3");
            Calc.AddComma();
            Calc.AddDigit("4");
            Calc.AddDigit("5");
            Calc.AddDigit("7");

            Calc.Equals();
            Assert.AreEqual("-2931,157", Calc.ActiveVariable);
        }
        [TestMethod]
        public void MultiplicationTest1()
        {
            CalcHandle Calc = new CalcHandle();
            Calc.AddDigit("6");
            Calc.AddDigit("4");
            Calc.AddDigit("0");
            Calc.AddDigit("2");
            Calc.AddComma();
            Calc.AddDigit("3");

            Calc.Multiplication();

            Calc.AddDigit("9");
            Calc.AddDigit("3");
            Calc.AddDigit("3");
            Calc.AddDigit("3");
            Calc.AddComma();
            Calc.AddDigit("4");
            Calc.AddDigit("5");
            Calc.AddDigit("7");

            Calc.Equals();
            Assert.AreEqual("59755591,7511", Calc.ActiveVariable);
        }
        [TestMethod]
        public void MultiplicationTest2()
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
        [TestMethod]
        public void RemovalTest1()
        {
            CalcHandle Calc = new CalcHandle();

            Calc.AddDigit("0");
            Calc.AddDigit("0");
            Calc.AddDigit("0");
            Calc.RemoveDigit();
            Calc.RemoveDigit();
            Calc.RemoveDigit();
            Calc.AddDigit("6");
            Calc.AddDigit("4");

            Assert.AreEqual("64", Calc.ActiveVariable);
        }
        [TestMethod]
        public void SqrtTest1()
        {
            CalcHandle Calc = new CalcHandle();

            Calc.AddDigit("0");
            Calc.AddDigit("0");
            Calc.AddDigit("0");
            Calc.RemoveDigit();
            Calc.RemoveDigit();
            Calc.RemoveDigit();
            Calc.AddDigit("6");
            Calc.AddDigit("4");
            Calc.AddDigit("0");
            Calc.Sqrt();

            Assert.AreEqual("25,298221281", Calc.ActiveVariable);
        }
        [TestMethod]
        public void ReverseTest1()
        {
            CalcHandle Calc = new CalcHandle();

            Calc.AddDigit("0");
            Calc.Reverse();
            Calc.Reverse();

            Assert.AreEqual("0", Calc.ActiveVariable);
        }
        [TestMethod]
        public void SignSwitchTest()
        {
            CalcHandle Calc = new CalcHandle();

            Calc.AddDigit("0");
            Calc.SignSwitch();
            Calc.AddDigit("9");
            Calc.AddComma();
            Calc.AddDigit("4");
            Calc.AddDigit("5");
            Calc.AddDigit("7");

            Calc.SignSwitch();

            Assert.AreEqual("-9,457", Calc.ActiveVariable);
        }
        [TestMethod]
        public void SqrtTest2()
        {
            CalcHandle Calc = new CalcHandle();

            Calc.AddDigit("9");
            Calc.AddComma();
            Calc.AddDigit("4");
            Calc.SignSwitch();
            Calc.AddDigit("5");
            Calc.AddDigit("7");

            Calc.Sqrt();

            Assert.AreEqual("0", Calc.ActiveVariable);
        }
        [TestMethod]
        public void RemovalTest2()
        {
            CalcHandle Calc = new CalcHandle();

            Calc.AddDigit("9");
            Calc.AddComma();
            Calc.AddDigit("4");
            Calc.SignSwitch();
            Calc.AddDigit("5");
            Calc.AddDigit("7");

            Calc.Remove_C();

            Assert.AreEqual("0", Calc.ActiveVariable);
        }
        [TestMethod]
        public void MemoryCellTest1()
        {
            CalcHandle Calc = new CalcHandle();

            Calc.AddDigit("9");
            Calc.AddComma();
            Calc.AddDigit("4");
            Calc.SignSwitch();
            Calc.AddDigit("5");
            Calc.AddDigit("7");

            Calc.MemoryWrite();
            Calc.Remove_CE();

            Calc.AddDigit("1");
            Calc.MemoryPlus();
            Calc.MemoryPlus();
            Calc.MemoryPlus();
            Calc.AddDigit("3");

            Calc.MemoryMinus();
            Calc.MemoryRead();

            Assert.AreEqual("-19,457", Calc.ActiveVariable);
        }
        [TestMethod]
        public void MemoryCellTest2()
        {
            CalcHandle Calc = new CalcHandle();

            Calc.AddDigit("9");
            Calc.AddComma();
            Calc.AddDigit("4");
            Calc.SignSwitch();
            Calc.AddDigit("5");
            Calc.AddDigit("7");
            Calc.AddDigit("6");
            Calc.AddDigit("1");

            Calc.MemoryWrite();
            Calc.Remove_CE();
            Calc.MemoryClear();

            Calc.MemoryMinus();
            Calc.MemoryRead();

            Assert.AreEqual("0", Calc.ActiveVariable);
        }
        [TestMethod]
        public void PercentTest1()
        {
            CalcHandle Calc = new CalcHandle();

            Calc.AddDigit("9");
            Calc.AddComma();
            Calc.AddDigit("4");
            Calc.SignSwitch();
            Calc.AddDigit("5");
            Calc.AddDigit("7");

            Calc.Addition();

            Calc.AddDigit("9");
            Calc.AddComma();
            Calc.AddDigit("4");
            Calc.AddDigit("5");
            Calc.AddDigit("7");

            Calc.Percent();
            Calc.Equals();

            Assert.AreEqual("-10,35134849", Calc.ActiveVariable);
        }
        [TestMethod]
        public void PercentTest2()
        {
            CalcHandle Calc = new CalcHandle();

            Calc.AddDigit("9");
            Calc.AddComma();
            Calc.AddDigit("9");
            Calc.AddDigit("9");
            Calc.AddDigit("9");
            Calc.AddDigit("9");
            Calc.AddDigit("9");
            Calc.AddDigit("9");
            Calc.AddDigit("9");
            Calc.AddDigit("9");

            Calc.Subtraction();

            Calc.AddDigit("9");
            Calc.AddComma();
            Calc.AddDigit("4");
            Calc.AddDigit("5");
            Calc.AddDigit("7");

            Calc.Percent();
            Calc.Equals();

            Assert.AreEqual("9,054299991", Calc.ActiveVariable);
        }
        [TestMethod]
        public void PercentTest3()
        {
            CalcHandle Calc = new CalcHandle();

            Calc.AddDigit("9");
            Calc.AddComma();
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
            Calc.AddComma();
            Calc.AddDigit("4");
            Calc.AddDigit("5");
            Calc.AddDigit("7");

            Calc.Percent();
            Calc.Equals();

            Calc.Division();

            Calc.AddDigit("9");
            Calc.AddDigit("4");

            Calc.Percent();
            Calc.Equals();

            Assert.AreEqual("100", Calc.ActiveVariable);
        }
    }
}