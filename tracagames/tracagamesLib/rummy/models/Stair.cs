using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tracagamesLib.rummy.models
{
    internal class Stair: Combination
    {
        internal Stair(List<Card> cards): base(cards) { }
       
        override protected int getFindPointsForJoker(int i)
        {            
            int points = 0;
            int j = 0;
            bool done = false;
            while (j < this.cards.Count && !done)
            {
                if (!this.cards[j].isJoker())
                {
                    if (i == j - 1)
                    {
                        points = (int)this.cards[j].getPoint() - 1;
                        done = true;
                    } else if (i == j + 1)
                    {
                        points = (int)this.cards[j].getPoint() + 1;
                        done = true;
                    }
                }
                j++;
            }
            return points;
        }
    }
}
