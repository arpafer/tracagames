namespace Conecta4Lib.models
{
    internal class Cell
    {
        private int row;
        private int column;
        private Card card;

        internal Cell(int r, int c)
        {
            this.row = r;
            this.column = c;
            this.card = null;
        }

        internal bool isBussy()
        {
            return this.card != null;
        }

        internal void occupyWith(Card card)
        {            
            this.card = card;
        }

        internal bool hasCard(Color color)
        {
            return this.card != null && this.card.hasColor(color);
        }

        internal bool isPosition(int row, int column)
        {
            return this.row == row && this.column == column;
        }
    }
}