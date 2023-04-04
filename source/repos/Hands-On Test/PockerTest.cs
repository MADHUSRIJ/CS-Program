using Hands_On;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hands_On_Test
{
    [TestClass]
    public class PockerTest
    {
        Pocker pocker = new Pocker();
        [TestMethod]
        public void TestPockerRoyalFlush()
        {
           
            string[] deck = { "10h", "Jh", "Qh", "Ah", "Kh" };
            string actual = pocker.PockerHandRanking(deck);
            Assert.AreEqual("Royal Flush",actual);
        }

        [TestMethod]
        public void TestPockerStraightFlush()
        {
          
            string[] deck = { "Js", "10s", "9s", "8s", "7s" };
            string actual = pocker.PockerHandRanking(deck);
            Assert.AreEqual("Straight Flush", actual);
        }

        [TestMethod]
        public void TestPockerFourOfAKind()
        {
            
            string[] deck = { "5s", "5d", "5h", "5c", "2d" };
            string actual = pocker.PockerHandRanking(deck);
            Assert.AreEqual("Four of a Kind", actual);
        }

        [TestMethod]
        public void TestPockerFullHouse()
        {
           
            string[] deck = { "6c", "6h", "6d", "Ks", "Kh" };
            string actual = pocker.PockerHandRanking(deck);
            Assert.AreEqual("Full House", actual);
        }

        [TestMethod]
        public void TestPockerFlush()
        {
         
            string[] deck = { "Jd", "9d", "8d", "4d", "3d" };
            string actual = pocker.PockerHandRanking(deck);
            Assert.AreEqual("Flush", actual);
        }

        [TestMethod]
        public void TestPockerStraight()
        {
         
            string[] deck = { "10d", "9c", "8h", "7d", "6s" };
            string actual = pocker.PockerHandRanking(deck);
            Assert.AreEqual("Straight", actual);
        }

        [TestMethod]
        public void TestPockerThreeOfAKind()
        {
        
            string[] deck = { "Qs", "Qc", "Qh", "9h", "2c" };
            string actual = pocker.PockerHandRanking(deck);
            Assert.AreEqual("Three of a Kind", actual);
        }

        [TestMethod]
        public void TestPockerTwoPair()
        {
           
            string[] deck = { "Js", "Jh", "3s", "3c", "2h" };
            string actual = pocker.PockerHandRanking(deck);
            Assert.AreEqual("Two Pair", actual);
        }

        [TestMethod]
        public void TestPockerOnePair()
        {
           
            string[] deck = { "10c", "10h", "8c", "7h", "4s" };
            string actual = pocker.PockerHandRanking(deck);
            Assert.AreEqual("Pair", actual);
        }

        [TestMethod]
        public void TestPockerHighCard()
        {
            
            string[] deck = { "Kd", "Qd", "8c", "4c", "3h" };
            string actual = pocker.PockerHandRanking(deck);
            Assert.AreEqual("High Card", actual);
        }
    }
}
