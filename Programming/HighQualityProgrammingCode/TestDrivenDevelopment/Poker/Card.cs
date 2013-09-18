using System;

namespace Poker
{
    public class Card : ICard
    {
        public CardFace Face { get; private set; }
        public CardSuit Suit { get; private set; }

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public override string ToString()
        {
            string cardAsString = FaceAsString(this.Face) + SuitAsString(this.Suit);
            return cardAsString;
        }
  
        private string FaceAsString(CardFace face)
        {
            if ((int)face <= 10)
            {
                return ((int)face).ToString();
            }
            else
            {
                switch (face)
                {
                    case CardFace.Jack:
                        return "J";
                    case CardFace.Queen:
                        return "Q";
                    case CardFace.King:
                        return "K";
                    case CardFace.Ace:
                        return "A";
                    default:
                        throw new InvalidOperationException("No such face " + face.ToString());
                }
            }
        }

        private string SuitAsString(CardSuit suit)
        {
            switch (suit)
            {
                case CardSuit.Clubs:
                    return "♣";
                case CardSuit.Diamonds:
                    return "♦";
                case CardSuit.Hearts:
                    return "♥";
                case CardSuit.Spades:
                    return "♠";
                default:
                    throw new InvalidOperationException("No such suit: " + this.Suit.ToString());
            }
        }
    }
}
