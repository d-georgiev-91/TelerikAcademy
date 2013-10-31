namespace TickTackToe.ViewModel
{
    using System.Collections.Generic;
    using Windows.Foundation;

    public interface IPlayer
    {
        PlayerType PlayerType { get; }

        char Symbol { get; }

        IAsyncOperationWithProgress<uint, double> ThinkAsync(IEnumerable<char> gameBoard);
    }
}