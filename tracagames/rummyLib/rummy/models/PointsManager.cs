using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tracagamesLib.rummy.models
{
    abstract internal class PointsManager
    {
        protected List<Card> cards;
        protected Hashtable hashGroups;

        internal PointsManager(List<Card> cards)
        {
            this.cards = cards;
            this.hashGroups = new Hashtable();
        }

        internal int getPoints()
        {
            int points = 0;            
            for (int i = 0; i < this.cards.Count; i++)
            {
                List<Card> _cards = this.getCards(i);               
                this.addGroup(_cards, i);
            }
            foreach (Combination combination in hashGroups.Values)
            {
                points += combination.getPoints();
            }
            return points;
        }

        abstract protected List<Card> getCards(int i);
        abstract protected void addGroup(List<Card> _cards, int i);
    }
}
