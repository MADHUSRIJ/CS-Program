using Hands_On;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hands_On_Test
{
    [TestClass]
    public class TranslateTest
    {
        [TestMethod]
        public void SentenceTest1()
        {
            Translate translate = new Translate();
            String actual = translate.TranslateSentence("I like to eat honey waffles.");
            Assert.AreEqual(actual, "Iyay ikelay otay eatyay oneyhay afflesway.");
        }

        [TestMethod]
        public void SentenceTest2()
        {
            Translate translate = new Translate();
            String actual = translate.TranslateSentence("Do you think it is going to rain today?");
            Assert.AreEqual(actual, "Oday ouyay inkthay ityay isyay oinggay otay ainray odaytay?");
        }

        [TestMethod]
        public void SentenceTest3()
        {
            Translate translate = new Translate();
            String actual = translate.TranslateWord("flag");
            Assert.AreEqual(actual, "agflay");
        }

        [TestMethod]
        public void SentenceTest4()
        {
            Translate translate = new Translate();
            String actual = translate.TranslateWord("Apple");
            Assert.AreEqual(actual, "Appleyay");
        }

        [TestMethod]
        public void SentenceTest5()
        {
            Translate translate = new Translate();
            String actual = translate.TranslateSentence("button");
            Assert.AreEqual(actual, "uttonbay");
        }

        [TestMethod]
        public void SentenceTestEmpty()
        {
            Translate translate = new Translate();
            String actual = translate.TranslateSentence("");
            Assert.AreEqual(actual, "");
        }
    }
}
