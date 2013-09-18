using Poker;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace PokerTest
{
    [TestClass()]
    public class CardTests
    {
        [TestMethod()]
        public void ToStringClubs()
        {
            string cardSuit = "♣";
            TestNonFaceCardsConversiontoString(cardSuit, CardSuit.Clubs);
            TestFaceCardsConversionToString(cardSuit, CardSuit.Clubs);
        }

        [TestMethod()]
        public void ToStringDiamons()
        {
            string cardSuit = "♦";
            TestNonFaceCardsConversiontoString(cardSuit, CardSuit.Diamonds);
            TestFaceCardsConversionToString(cardSuit, CardSuit.Diamonds);
        }

        [TestMethod()]
        public void ToStringHearts()
        {
            string cardSuit = "♥";
            TestNonFaceCardsConversiontoString(cardSuit, CardSuit.Hearts);
            TestFaceCardsConversionToString(cardSuit, CardSuit.Hearts);
        }

        [TestMethod()]
        public void ToStringSpades()
        {
            string cardSuit = "♠";
            TestNonFaceCardsConversiontoString(cardSuit, CardSuit.Spades);
            TestFaceCardsConversionToString(cardSuit, CardSuit.Spades);
        }

        private void TestFaceCardsConversionToString(string cardSuitAsString, CardSuit cardSuitAsDefault)
        {
            List<string> FaceCards = new List<string>(new string[] { "J", "Q", "K", "A" });

            for (int cardFace = 11; cardFace <= 14; cardFace++)
            {
                Card card = new Card((CardFace)cardFace, cardSuitAsDefault);
                string expected = FaceCards[cardFace - 11] + cardSuitAsString;
                string actual = card.ToString();
                Assert.AreEqual(expected, actual, "Expected " + expected + ", but actual was " + actual);
            }
        }
  
        private void TestNonFaceCardsConversiontoString(string cardSuitAsString, CardSuit cardSuitAsDefault)
        {
            for (int cardFace = 2; cardFace <= 10; cardFace++)
            {
                Card card = new Card((CardFace)cardFace, cardSuitAsDefault);
                string expected = cardFace + cardSuitAsString;
                string actual = card.ToString();
                Assert.AreEqual(expected, actual, "Expected " + expected + ", but actual was " + actual);
            }
        }
    }
}