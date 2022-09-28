namespace tracagamesLib.rummy.models
{
    internal class Mallet
    {
        private const int NUM_GROUPS = 2;
        private const int NUM_CARDS = 52;        
        private const int NUM_COLORS = 4;
        private const int NUM_CARDS_BY_COLOR = 13;
        private const int NUM_JOKERS = 2;
        private List<Card> cards;
        private Joker[] jokers;

        internal Mallet()
        {
            this.cards = new List<Card>(NUM_CARDS);
            this.jokers = new Joker[NUM_JOKERS];
            this.createCards();
            this.shuffle();
        }
      
        private void createCards()
        {
            for (int g = 1; g <= NUM_GROUPS; g++)
            {
                for (int i = 0; i < NUM_COLORS; i++)
                {
                    for (int j = 1; j <= NUM_CARDS_BY_COLOR; j++)
                    {
                        this.cards.Add(new Card((Color)i, State.FACEDOWN, (Point)j, g));
                    }
                }
            }
        }

        private void shuffle()
        {
            List<int> shuffledIndexs = new List<int>();
            int i = 0;
            int maxExchanges = (int)((this.cards.Count + NUM_JOKERS) / 2);
            while (i < maxExchanges)
            {
                int firstIndex = new Random().Next(0, maxExchanges);
                int secondIndex = new Random().Next(0, maxExchanges);
                if (firstIndex != secondIndex && !shuffledIndexs.Contains(firstIndex) && !shuffledIndexs.Contains(secondIndex))
                {
                    Card firstCard = this.cards[firstIndex];
                    this.cards[firstIndex] = this.cards[secondIndex];
                    this.cards[secondIndex] = firstCard;
                    shuffledIndexs.Add(firstIndex);
                    shuffledIndexs.Add(secondIndex);
                    i++;
                }
            }
        }     

        internal Card extractAnyRandom()
        {
            int maxCardIndex = NUM_CARDS * NUM_GROUPS + NUM_JOKERS;
            while (true)
            {
                int cardIndex = new Random().Next(maxCardIndex);
                if (cardIndex >= NUM_CARDS * NUM_GROUPS && this.jokers[cardIndex - NUM_CARDS * NUM_GROUPS].isFaceDown())
                {
                    this.jokers[cardIndex - NUM_CARDS * NUM_GROUPS].take();
                    return this.jokers[cardIndex - NUM_CARDS * NUM_GROUPS];
                }
                else
                {
                    if (this.cards[cardIndex].isFaceDown())
                    {
                        this.cards[cardIndex].take();
                        return this.cards[cardIndex];
                    }
                }
            }
        }

        internal List<Card> distributeInitialsCards()
        {
            List<Card> distributedCards = new List<Card>();
            for (int i = 0; i < NUM_CARDS_BY_COLOR + 1; i++)
            {
                distributedCards.Add(this.extractAnyRandom());
            }
            return distributedCards;
        }

        internal bool hasCardsForTake()
        {
            foreach (Card card in this.cards)
            {
                if (card.isFaceDown())
                    return true;
            }
            return false;
        }
    }
}