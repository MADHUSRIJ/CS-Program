using Assessment2;

namespace LicenseTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestTotalTimeToGetNewLicense()
        {
            Assessment2.Program program = new Assessment2.Program();
            program.totalTimeToGetNewLicense("Eric", 2, "Adam Caroline Rebecca Frank");
            int time = program.totalTime;
            if(time == 40)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestTotalTimeToGetNewLicense1()
        {
            Assessment2.Program program = new Assessment2.Program();
            program.totalTimeToGetNewLicense("Zebediah", 1, "Bob Jim Becky Pat");
            int time = program.totalTime;
            if (time == 100)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestTotalTimeToGetNewLicense2()
        {
            Assessment2.Program program = new Assessment2.Program();
            program.totalTimeToGetNewLicense("Aaron", 3, "Jane Max Olivia Sam");
            int time = program.totalTime;
            if (time == 20)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.Fail();
            }
        }
    }
}