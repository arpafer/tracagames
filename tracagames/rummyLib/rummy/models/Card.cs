
namespace tracagamesLib.rummy.models
{
    internal class Card
    {
        private Color color;
        private State state;
        private Point point;
        private int group;

        internal Card(Color color, State state, Point point, int group)
        {
            this.color = color;
            this.state = state;
            this.point = point;
            this.group = group;
        }

        internal Point getPoint()
        {
            return this.point;
        }

        internal Color getColor()
        {
            return this.color;
        }

        internal bool isFaceDown()
        {
            return this.state == State.FACEDOWN;
        }

        internal void take()
        {
            this.state = State.TAKEN;
        }

        internal string toString()
        {
            return "C: " + this.color + " S: " + this.state + " P: " + this.point + " G: " + this.group;
        }

        internal bool isTaken()
        {
            return this.state == State.TAKEN;
        }

        internal bool hasMoreOrEqualPoints(Card card)
        {
            return this.point >= card.point;
        }

        internal bool hasDiferentColor(Card card)
        {
            return this.color != card.color;
        }

        internal bool hasSameValue(Card card)
        {
            return this.point == card.point;
        }

        internal bool hasSameColor(Card card)
        {
            return this.color == card.color;
        }

        internal bool hasDifferentValue(Card card)
        {
            return this.point != card.point;
        }

        virtual internal bool isJoker()
        {
            return point == Point.JOKER;
        }

        internal bool isMinor(Card card)
        {
            return this.isJoker() || card.isJoker() || this.point < card.point;
        }

        internal int getPointsDistance(Card card)
        {
            return Math.Abs(this.point - card.point);
        }
    }
}