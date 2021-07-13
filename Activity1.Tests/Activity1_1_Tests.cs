using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharp.Activity.Profile;

namespace Activity1.Tests
{
    [TestClass]
    public class GetZodiacSignTests
    {
        [TestMethod]
        public void TestZodiacVirgo()
        {
            Assert.AreEqual(Zodiac.VIRGO, Zodiac.GetZodiacSign(new DateTime(1977, 9, 13)));
        }

        [TestMethod]
        public void TestZodiacLeo()
        {
            Assert.AreEqual(Zodiac.LEO, Zodiac.GetZodiacSign(new DateTime(1981, 8, 11)));
        }

        [TestMethod]
        public void TestZodiacTaurus()
        {
            Assert.AreEqual(Zodiac.LEO, Zodiac.GetZodiacSign(new DateTime(1981, 8, 11)));
        }

        [TestMethod]
        public void TestZodiacAries()
        {
            Assert.AreEqual(Zodiac.ARIES, Zodiac.GetZodiacSign(new DateTime(1923, 4, 1)));
        }

        [TestMethod]
        public void TestZodiacGemini()
        {
            Assert.AreEqual(Zodiac.GEMINI, Zodiac.GetZodiacSign(new DateTime(1982, 5, 21)));
        }

        [TestMethod]
        public void TestZodiacCancer()
        {
            Assert.AreEqual(Zodiac.CANCER, Zodiac.GetZodiacSign(new DateTime(1642, 7, 20)));
        }

        [TestMethod]
        public void TestZodiacLibra()
        {
            Assert.AreEqual(Zodiac.LIBRA, Zodiac.GetZodiacSign(new DateTime(1776, 9, 26)));
        }

        [TestMethod]
        public void TestZodiacScorpio()
        {
            Assert.AreEqual(Zodiac.SCORPIO, Zodiac.GetZodiacSign(new DateTime(1021, 11, 21)));
        }

        [TestMethod]
        public void TestZodiacSagittarius()
        {
            Assert.AreEqual(Zodiac.SAGITTARIUS, Zodiac.GetZodiacSign(new DateTime(1, 12, 1)));
        }

        [TestMethod]
        public void TestZodiacCapricorn()
        {
            Assert.AreEqual(Zodiac.CAPRICORN, Zodiac.GetZodiacSign(new DateTime(100, 1, 1)));
        }

        [TestMethod]
        public void TestZodiacAquarius()
        {
            Assert.AreEqual(Zodiac.AQUARIUS, Zodiac.GetZodiacSign(new DateTime(100, 2, 14)));
        }

        [TestMethod]
        public void TestZodiacPisces()
        {
            Assert.AreEqual(Zodiac.PISCES, Zodiac.GetZodiacSign(new DateTime(100, 2, 24)));
        }
    }
}
