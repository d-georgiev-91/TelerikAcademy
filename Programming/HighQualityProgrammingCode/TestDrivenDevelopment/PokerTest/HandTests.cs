using Poker;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PokerTest
{
    [TestClass()]
    public class HandTests
    {
        [TestMethod()]
        public void HandToStringTest1()
        {
            Hand hand = new Hand(new Card[] {
                new Card(CardFace.Ace, CardSuit.Clubs),            
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Hearts),
            });
            string expected = "A♣ 7♠ 6♦ 9♣ Q♥";
            string actual = hand.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void HandToStringTest2()
        {
            Hand hand = new Hand(new Card[] {
                new Card(CardFace.Two, CardSuit.Clubs),            
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Clubs),
            });
            string expected = "2♣ 3♦ 4♠ K♦ 5♣";
            string actual = hand.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}