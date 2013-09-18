using System;
using System.Collections.Generic;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        private const int HandCardsCount = 5;

        public bool IsValidHand(IHand hand)
        {
            if (!AreExactlyFiveCardsInHand(hand))
            {
                return false;
            }

            if (!AreAllCardsDifferentInHand(hand))
            {
                return false;
            }

            return true;
        }

        private bool AreAllCardsDifferentInHand(IHand hand)
        {
            IList<ICard> cards = hand.Cards;

            // Loops for same cards in hand
            for (int i = 0; i < 4; i++)
            {
                for (int j = i + 1; j < HandCardsCount; j++)
                {
                    if (cards[i].Face == cards[j].Face && cards[i].Suit == cards[j].Suit)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool AreExactlyFiveCardsInHand(IHand hand)
        {
            bool areFiveCards = hand.Cards.Count == HandCardsCount && hand.Cards != null;
            return areFiveCards;
        }

        public bool IsStraightFlush(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                throw new ArgumentException("This is invalid poker hand!");
            }

            IList<ICard> cards = hand.Cards;
            for (int i = 0; i < HandCardsCount - 2; i++)
            {
                int sameKindCount = 1;
                for (int j = i + 1; j < HandCardsCount; j++)
                {
                    if (cards[i].Face == cards[j].Face)
                    {
                        sameKindCount++;
                    }

                }

                if (sameKindCount == 4)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsFullHouse(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFlush(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                throw new ArgumentException("This is invalid poker hand!");
            }

            CardSuit suitCandidateForFlush = hand.Cards[0].Suit;
            for (int i = 1; i < HandCardsCount; i++)
            {
                if (hand.Cards[i].Suit != suitCandidateForFlush)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsTwoPair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsOnePair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }
    }
}