namespace tracagamesLib.rummy.models
{
    internal class Group: Combination
    {        
        internal Group(List<Card> cards): base(cards)
        {
            this.cards = cards;
        }
              
        protected override int getFindPointsForJoker(int i)
        {
            int points = 0;
            int j = 0;
            bool done = false;
            while (j < this.cards.Count && !done)
            {
                if (i != j && !this.cards[j].isJoker())
                {
                    points = (int)(this.cards[j].getPoint());
                    done = true;
                }
                j++;
            }
            return points;
        }
    }
}