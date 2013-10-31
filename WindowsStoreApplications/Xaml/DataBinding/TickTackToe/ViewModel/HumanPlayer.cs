namespace TickTackToe.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Windows.Foundation;

    public class HumanPlayer : IPlayer
    {
        private char symbol;

        public HumanPlayer(char symbol)
        {
            this.symbol = symbol;
        }

        public PlayerType PlayerType
        {
            get
            {
                return PlayerType.Human;
            }
        }
        
        public char Symbol
        {
            get
            {
                return this.symbol;
            }
        }

        public IAsyncOperationWithProgress<uint, double> ThinkAsync(IEnumerable<char> gameBoard)
        {
            return null;
        }
    }
}