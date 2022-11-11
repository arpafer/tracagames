using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tracagamesLib.rummy.models
{
    abstract internal class Combination
    {
        protected List<Card> cards;

        internal Combination(List<Card> cards)
        {
            this.cards = cards;
        }

        internal int getPoints()
        {
            int points = 0;
            for (int i = 0; i < this.cards.Count; i++)
            {
                Card card = this.cards[i];
                if (card.isJoker())
                {
                    points += getFindPointsForJoker(i);
                }
                else
                {
                    points += (int)card.getPoint();
                }
            }
            return points;
        }

        abstract protected int getFindPointsForJoker(int i);
    }
}
