using BalancedParantheses;

namespace BalancedParanthesesTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void BalancedParanthesesWithOnePair()
        {
            BalancedParantheses.Program program = new BalancedParantheses.Program();
            List<string> ActualValidParantheses = program.ParanthesesBalance(1);
            List<string> ExpectedValidParantheses = new List<string> { "()" };
            ActualValidParantheses.Sort();
            ExpectedValidParantheses.Sort();
            CollectionAssert.AreEquivalent(ActualValidParantheses,ExpectedValidParantheses);

        }
        [TestMethod]
        public void BalancedParanthesesWithThreePair()
        {
            BalancedParantheses.Program program = new BalancedParantheses.Program();
            List<string> ActualValidParantheses = program.ParanthesesBalance(3);
            List<string> ExpectedValidParantheses = new List<string> { "((()))", "(()())", "(())()", "()(())", "()()()" };
            ActualValidParantheses.Sort();
            ExpectedValidParantheses.Sort();
            CollectionAssert.AreEquivalent(ActualValidParantheses, ExpectedValidParantheses);
        }


    }
}