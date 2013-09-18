using Poker;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PokerTest
{
    [TestClass()]
    public class PokerHandsCheckerTest
    {
        public void FiveCardsInHandTest()
        {
            //Това е доста тъпо имплементирано по дизайна... Би трябвало 
            //класа да е статичен и изобщо не да не създава инстанция от него
            //но, ако го направя статичен трябва да изтрия и интефейса...
            PokerHandsChecker pokerHandsChecker = new PokerHandsChecker();

            Hand hand = new Hand(new Card[] {
                new Card(CardFace.Ace, CardSuit.Clubs),            
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Hearts),
            });

            bool isValidHand = pokerHandsChecker.IsValidHand(hand);
            Assert.IsTrue(isValidHand);
        }

        [TestMethod()]
        public void MoreThanFiveCardsInHandTest()
        {
            PokerHandsChecker pokerHandsChecker = new PokerHandsChecker(); 

            Hand hand = new Hand(new Card[] {
                new Card(CardFace.Ace, CardSuit.Clubs),            
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts),
            });

            bool isValidHand = pokerHandsChecker.IsValidHand(hand);
            Assert.IsFalse(isValidHand);
        }

        [TestMethod()]
        public void LessThanFiveCardsInHandTest()
        {
            PokerHandsChecker pokerHandsChecker = new PokerHandsChecker();

            Hand hand = new Hand(new Card[] {
                new Card(CardFace.Ace, CardSuit.Clubs),            
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Diamonds),
            });

            bool isValidHand = pokerHandsChecker.IsValidHand(hand);
            Assert.IsFalse(isValidHand);
        }

        [TestMethod()]
        public void AllSameCardsInHandTest()
        {
            PokerHandsChecker pokerHandsChecker = new PokerHandsChecker();

            Hand hand = new Hand(new Card[] {
                new Card(CardFace.Ace, CardSuit.Clubs),            
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs),
            });

            bool isValidHand = pokerHandsChecker.IsValidHand(hand);
            Assert.IsFalse(isValidHand);
        }

        [TestMethod()]
        public void TwoSameCardsInHandTest()
        {
            PokerHandsChecker pokerHandsChecker = new PokerHandsChecker();

            Hand hand = new Hand(new Card[] {
                new Card(CardFace.Ace, CardSuit.Clubs),            
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Clubs),
            });

            bool isValidHand = pokerHandsChecker.IsValidHand(hand);
            Assert.IsFalse(isValidHand);
        }

        [TestMethod()]
        public void HandOfFlushOfDifferentFacesTest()
        {
            PokerHandsChecker pokerHandsChecker = new PokerHandsChecker();

            Hand hand = new Hand(new Card[] {
                new Card(CardFace.Ace, CardSuit.Clubs),            
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Clubs),
            });

            bool isFlush = pokerHandsChecker.IsFlush(hand);
            Assert.IsFalse(isFlush);
        }

        [TestMethod()]
        public void HandOfFlushOfAllSameFacesTest()
        {
            PokerHandsChecker pokerHandsChecker = new PokerHandsChecker();

            Hand hand = new Hand(new Card[] {
                new Card(CardFace.Ace, CardSuit.Clubs),            
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
            });

            bool isFlush = pokerHandsChecker.IsFlush(hand);
            Assert.IsTrue(isFlush);
        }

        [TestMethod()]
        public void HandOfFlushOfTwoSameFacesTest()
        {
            PokerHandsChecker pokerHandsChecker = new PokerHandsChecker();

            Hand hand = new Hand(new Card[] {
                new Card(CardFace.Ace, CardSuit.Clubs),            
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Clubs),
            });

            bool isFlush = pokerHandsChecker.IsFlush(hand);
            Assert.IsFalse(isFlush);
        }

        [TestMethod()]
        public void HandOfFourOfKindTest()
        {
            PokerHandsChecker pokerHandsChecker = new PokerHandsChecker();

            Hand hand = new Hand(new Card[] {
                new Card(CardFace.Ace, CardSuit.Spades),            
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Diamonds),
            });

            bool isFourOfAKind = pokerHandsChecker.IsFourOfAKind(hand);
            Assert.IsTrue(isFourOfAKind);
        }

        [TestMethod()]
        public void HandOfFourOfKindAllThreeTheSameTest()
        {
            PokerHandsChecker pokerHandsChecker = new PokerHandsChecker();

            Hand hand = new Hand(new Card[] {
                new Card(CardFace.Ace, CardSuit.Clubs),            
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Clubs),
            });

            bool isFourOfAKind = pokerHandsChecker.IsFourOfAKind(hand);
            Assert.IsFalse(isFourOfAKind);
        }

        [TestMethod()]
        public void HandOfFourOfKindThreeAndTwoTheSameTest()
        {
            PokerHandsChecker pokerHandsChecker = new PokerHandsChecker();

            Hand hand = new Hand(new Card[] {
                new Card(CardFace.Ace, CardSuit.Clubs),            
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Clubs),
            });

            bool isFourOfAKind = pokerHandsChecker.IsFourOfAKind(hand);
            Assert.IsFalse(isFourOfAKind);
        }

        [TestMethod()]
        public void HandOfFourOfKindTwoPairTest()
        {
            PokerHandsChecker pokerHandsChecker = new PokerHandsChecker();

            Hand hand = new Hand(new Card[] {
                new Card(CardFace.Ace, CardSuit.Clubs),            
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Clubs),
            });

            bool isFourOfAKind = pokerHandsChecker.IsFourOfAKind(hand);
            Assert.IsFalse(isFourOfAKind);
        }
    }
}
