using Hands_On;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hands_On_Test
{
    [TestClass]
    public class NicoCipherTest
    {
        [TestMethod]
        public void TestNicoCipherWithCrazy()
        {
            NicoCipher nicoCipher = new NicoCipher();
            string actual = nicoCipher.Encryption("mubashirhassan","crazy");
            Assert.AreEqual(actual, "bmusarhiahass n");
        }
        [TestMethod]
        public void TestNicoCipherWithMatt()
        {
            NicoCipher nicoCipher = new NicoCipher();
            string actual = nicoCipher.Encryption("edabitisamazing", "matt");
            Assert.AreEqual(actual, "deabtiismaaznig ");
        }
        [TestMethod]
        public void TestNicoCipherWith612345()
        {
            NicoCipher nicoCipher = new NicoCipher();
            string actual = nicoCipher.Encryption("iloveher", "612345");
            Assert.AreEqual(actual, "lovehir    e");
        }
    }
}
