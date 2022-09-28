namespace tracagamesLib.rummy.models
{
    internal class Turn
    {
        private List<Player> players;
        private int playerIndex;
        private Mallet mallet;

        public Turn(List<Player> players, int playerIndex, Mallet mallet)
        {
            this.players = players;
            this.mallet = mallet;
            this.playerIndex = playerIndex;
        }

        internal void play()
        {
            this.players[this.playerIndex].play();    
        }

        internal void change()
        {
            this.playerIndex = (this.playerIndex + 1) % this.players.Count;
        }

        internal bool hasWinner()
        {
            return this.hasAnyPlayerWithoutCards() || this.noPlayerHasFinishedTurn();           
        }

        private bool hasAnyPlayerWithoutCards()
        {
            foreach (Player player in this.players)
            {
                if (player.hasNotCards())
                {
                    return true;
                }
            }
            return false;
        }

        private bool noPlayerHasFinishedTurn()
        {
            foreach (Player player in this.players)
            {
                if (player.hasFinishedTurn())
                {
                    return false;
                }
            }
            return true;
        }

        internal bool hasPlayerInitialMinimunPoints()
        {
            return this.players[this.playerIndex].hasInitialMinimumPoints();
        }
    }
}