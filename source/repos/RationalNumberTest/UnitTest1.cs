using RationalNumber;

namespace RationalNumberTest
{
    [TestClass]
    public class UnitTest1
    {
        Rational r1 = new Rational(1, 2);
        Rational r2 = new Rational(10, 8);
        Rational r3 = new Rational(2, -1);
        Rational r4 = new Rational(0, -1);

        [TestMethod]
        public void TestOperatorAdd()
        {
            
            Assert.AreEqual((r1+r2).ToString(),"7/4");
        }
        [TestMethod]
        public void TestOperatorSubract()
        {
            
            Assert.AreEqual((r2 - new Rational(-1, 4)).ToString(), "3/2");
        }
        [TestMethod]
        public void TestOperatorMultiply()
        {
            
            Assert.AreEqual((r1 * r3).ToString(), "-1");
        }
        [TestMethod]
        public void TestOperatorDivide()
        {
            
            Assert.AreEqual(((r1 + r2) / r3).ToString() , "-7/8");
        }
        [TestMethod]
        public void TestOperatorUnary()
        {
            
            Assert.AreEqual((-r1).ToString(), "-1/2");
            Assert.AreEqual((-r3).ToString(), "2");
            Assert.AreEqual((r1 - -r2).ToString(), "7/4");
           
        }

        [TestMethod]
        public void TestSign()
        {
            Assert.AreEqual(r3.Sign(), -1);
            Assert.AreEqual(r1.Sign(), 1);
            Assert.AreEqual(r4.Sign(), 0);
        }

        [TestMethod]
        public void TestComparators()
        {
            Assert.AreEqual((r1==r1),true);
            Assert.AreEqual((r1 == r2), false);
            Assert.AreEqual((r1 < r2), true);
            Assert.AreEqual((r1 > r2), false);
        }
    }
}