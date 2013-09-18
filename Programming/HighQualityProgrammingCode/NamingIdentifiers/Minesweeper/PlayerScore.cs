using System;

namespace Minesweeper
{
    public class PlayerScore
    {
        string playerName;
        int playerScores;

        public string PlayerName
        {
            get { return playerName; }
            set { playerName = value; }
        }

        public int PlayerScores
        {
            get { return playerScores; }
            set { playerScores = value; }
        }

        public PlayerScore(string playerName, int scores)
        {
            this.playerName = playerName;
            this.playerScores = scores;
        }
    }
}
