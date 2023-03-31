namespace LicensePlateTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LicensePlate()
        {
            Travel.Program program = new Travel.Program();
            program.LicensePlate("5F3Z-2e-9-w", 4);
            String actual = program.newDmv;
            if(actual.Equals("5F3Z-2E9W")) 
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void LicensePlate1()
        {
            Travel.Program program = new Travel.Program();
            program.LicensePlate("2-5g-3-J", 2);
            String actual = program.newDmv;
            if (actual.Equals("2-5G-3J"))
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void LicensePlate2()
        {
            Travel.Program program = new Travel.Program();
            program.LicensePlate("nlj-206-fv", 3);
            String actual = program.newDmv;
            if (actual.Equals("NL-J20-6FV"))
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void LicensePlate3()
        {
            Travel.Program program = new Travel.Program();
            program.LicensePlate("2-4A0r7-4k", 3);
            String actual = program.newDmv;
            if (actual.Equals("24-A0R-74K"))
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