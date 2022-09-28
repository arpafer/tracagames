namespace tracagamesLib.rummy.models
{
    internal class Joker: Card
    {
        internal Joker(): base(Color.BLACK, State.FACEDOWN, Point.JOKER, 0)
        {

        }

        internal override bool isJoker()
        {
            return true;
        }
    }
}