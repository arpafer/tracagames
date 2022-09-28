using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tracagamesLib.rummy.models
{
    internal class PointsManagerGroups: PointsManager
    {                
        internal PointsManagerGroups(List<Card> cards): base(cards)
        {            
        }       
        
        override protected List<Card> getCards(int i)
        {
            List<Card> _cards = new List<Card>();
            _cards.Add(this.cards[i]);
            for (int j = i + 1; j < this.cards.Count; j++)
            {
                if (this.cards[j].isJoker() || (this.cards[i].hasDiferentColor(this.cards[j]) && this.cards[i].hasSameValue(this.cards[j])))
                {                   
                    _cards.Add(this.cards[j]);
                }
            }
            return _cards;
        }

        override protected void addGroup(List<Card> _cards, int i)
        {
            if (_cards.Count >= 3 && !this.hashGroups.ContainsKey(this.cards[i].getPoint()))
            {
                this.hashGroups.Add(this.cards[i].getPoint(), new Group(_cards));
            }
        }
    }
}
