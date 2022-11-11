using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tracagamesLib.rummy.models
{
    internal class PointsManagerStairs: PointsManager
    {        
        internal PointsManagerStairs(List<Card> cards): base(cards)
        {     
        }       

        override protected List<Card> getCards(int i)
        {
            List<Card> _cardsSameColor = new List<Card>();
            _cardsSameColor.Add(this.cards[i]);
            for (int j = i + 1; j < this.cards.Count; j++)
            {
                if (this.cards[j].isJoker() || (this.cards[i].hasSameColor(this.cards[j]) && this.cards[i].hasDifferentValue(this.cards[j])))
                {
                    _cardsSameColor.Add(this.cards[j]);
                }
            }
            this.orderSequence(_cardsSameColor);
            int distanceTotalCards = 0;
            for (int c = 0; c < _cardsSameColor.Count - 1; c++)
            {
                distanceTotalCards += _cardsSameColor[c].getPointsDistance(_cardsSameColor[c + 1]);
            }
            if (distanceTotalCards == _cardsSameColor.Count - 1)
                return _cardsSameColor;
            else
            {
                _cardsSameColor.Clear();
                return _cardsSameColor;
            }
        }

        private void orderSequence(List<Card> cardsToOrder)
        {
            for (int i = 0; i < cardsToOrder.Count - 1; i++)
            {
                for (int j = i + 1; j < cardsToOrder.Count; j++)
                {
                    if (cardsToOrder[j].isMinor(cardsToOrder[i]))
                    {
                        Card aux = cardsToOrder[i];
                        cardsToOrder[i] = cardsToOrder[j];
                        cardsToOrder[j] = aux;
                    }
                }
            }
        }

        override protected void addGroup(List<Card> _cards, int i)
        {
            if (_cards.Count >= 3 && !this.hashGroups.ContainsKey(this.cards[i].getColor()))
            {
                this.hashGroups.Add(this.cards[i].getColor(), new Stair(_cards));
            }
        }
    }
}
