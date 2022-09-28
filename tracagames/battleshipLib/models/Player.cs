using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleshipLib.models
{
    internal class Player
    {
        private int NUM_CELLS_BY_PANEL = 100;        
        private List<Cell> ownCells;
        private List<Cell> enemyCells;

        public Player(Board board)
        {            
            this.ownCells = board.getCells();
            this.enemyCells = board.getCells();
        }

        public void occupyCell(int r, int c)
        {
            this.ownCells[r * c].occupy();            
        }

        public void markEnemyCell(int r, int c)
        {
            this.enemyCells[r * c].destroy();
        }

        public void markOwnCellAsDestroyed(int r, int c)
        {
            this.ownCells[r * c].destroy();
        }

        public bool isOwnCellDestroyed(int r, int c)
        {
            return this.ownCells[r * c].isDestroyed();
        }

        public bool isEnemyCellDestroyed(int r, int c)
        {
            return this.enemyCells[r * c].isDestroyed();
        }

        internal void move(int r, int c)
        {
            if (this.enemyCells[r * c].isBussy())
            {
                this.enemyCells[r * c].destroy();
            }
        }

        internal bool isWinner()
        {
            throw new NotImplementedException();
        }
    }
}
