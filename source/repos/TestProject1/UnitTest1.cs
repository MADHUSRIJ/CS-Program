using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Security.Cryptography.X509Certificates;
using Testing;
namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void calcCGPATest()

        {
            int subjectsCount = 3;
            List<int> marks = new List<int>() { 98, 87, 67 };
            Testing.Program obj = new Testing.Program();
            obj.calcCGPA(marks, subjectsCount);
            if (obj.grade == "B")
                Assert.Fail();
        }
    }
}