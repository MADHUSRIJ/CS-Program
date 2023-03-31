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
    }
}