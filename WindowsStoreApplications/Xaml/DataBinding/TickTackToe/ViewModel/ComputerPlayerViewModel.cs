namespace TickTackToe.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Windows.Foundation;

    public class ComputerPlayerViewModel : IPlayer
    {
        private char symbol;
        private char oppnenentSymbol;
        
        public ComputerPlayerViewModel(char symbol, char opponentSymbol, char emptySymbol)
        {
            this.symbol = symbol;
            this.oppnenentSymbol = opponentSymbol;
            this.emptySymbol = emptySymbol;
        }

        public PlayerType PlayerType
        {
            get
            {
                return PlayerType.Computer;
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
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public char emptySymbol { get; set; }
    }
}