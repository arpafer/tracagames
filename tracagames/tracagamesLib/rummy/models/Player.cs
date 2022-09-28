using System.Collections;

namespace tracagamesLib.rummy.models
{
    internal class Player
    {
        private const int INITIAL_MINIMUM_POINTS = 30;
        private List<Card> cards;
        private int initialPoints;

        internal Player()
        {
            this.initialPoints = 0;
            this.cards = new List<Card>();
        }

        internal void setInitialsCards(List<Card> cards)
        {
            this.cards = cards;
        }

        internal void play()
        {
            
        }

        internal bool hasLessPoints(Player playerWithLessPoints)
        {
            PointsManagerGroups groups = new PointsManagerGroups(this.cards);
            PointsManagerStairs stairs = new PointsManagerStairs(this.cards);
            int myPoints = groups.getPoints() + stairs.getPoints();
            PointsManagerGroups groups1 = new PointsManagerGroups(playerWithLessPoints.cards);
            PointsManagerStairs stairs1 = new PointsManagerStairs(playerWithLessPoints.cards);
            int pointsPlayerExtern = groups1.getPoints() + stairs.getPoints();
            return myPoints < pointsPlayerExtern;
        }

        internal bool hasNotCards()
        {
            foreach (Card card in cards)
            {
                if (card.isTaken())
                    return false;
            }
            return true;
        }

        internal bool hasFinishedTurn()
        {
            throw new NotImplementedException();
        }

        internal bool hasInitialMinimumPoints()
        {
            int numPoints = this.getGroupsPoints() + this.getStairsPoints();
            return numPoints >= INITIAL_MINIMUM_POINTS;
        }

        private int getGroupsPoints()
        {            
            PointsManagerGroups groups = new PointsManagerGroups(this.cards);
            return groups.getPoints();
        }       

        private int getStairsPoints()
        {
            PointsManagerStairs groups = new PointsManagerStairs(this.cards);
            return groups.getPoints();
        }               
    }
}