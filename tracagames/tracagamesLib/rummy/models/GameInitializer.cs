namespace tracagamesLib.rummy.models
{
    internal class GameInitializer
    {
        private List<Player> players;
        private Mallet mallet;

        public GameInitializer(List<Player> players, Mallet mallet)
        {
            this.players = players;
            this.mallet = mallet;
            this.distributeCards();
        }

        private void distributeCards()
        {
            foreach (Player player in this.players)
            {
                player.setInitialsCards(this.mallet.distributeInitialsCards());
            }
        }

        internal int getStartingPlayer()
        {            
            List<Card> extractedCards = new List<Card>();
            for (int i = 0; i < this.players.Count; i++)
            {
                extractedCards.Add(this.mallet.extractAnyRandom());
            }
            int startingPlayer = 0;
            for (int i = 1; i < this.players.Count; i++)
            {
                if (extractedCards[i].hasMoreOrEqualPoints(extractedCards[i - 1]))
                {
                    startingPlayer = i;
                }
            }
            return startingPlayer;
        }      
    }
}