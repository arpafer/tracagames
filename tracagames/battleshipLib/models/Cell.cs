namespace battleshipLib.models
{
    internal class Cell
    {
        private int row;
        private int column;
        private bool bussy;
        private bool destroyed;
       
        internal Cell(int r, int c)
        {
            this.bussy = false;
            this.destroyed = false;
            this.row = r;
            this.column = c;
        }

        internal bool isFree()
        {
            return this.bussy == false;
        }

        internal void occupy()
        {
            this.bussy = true;
        }

        internal void destroy()
        {
            this.destroyed = true;
        }

        internal bool isDestroyed()
        {
            return this.destroyed;
        }

        internal bool isBussy()
        {
            return this.bussy;
        }
    }
}