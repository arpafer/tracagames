using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleshipLib.models
{
    internal class Board
    {
        internal const int NUM_PLAYERS = 2;              
        internal const int NUM_CELLS_BY_PANEL = 100;
        internal const int NUM_PANELS_BY_PLAYER = 2;
        internal const int NUM_ROWS_PANEL = 10;
        internal const int NUM_COLS_PANEL = 10;
        
        internal List<Cell> cells;
        internal int indexLastDistributedCell = 0;

        internal Board()
        {
            this.cells = new List<Cell>();
            this.createCells();
        }
       
        internal List<Cell> getCells()
        {
            List<Cell> cellsReturns = new List<Cell>();            
            for (int i = indexLastDistributedCell; i < NUM_CELLS_BY_PANEL + indexLastDistributedCell; i++)
            {                
                cellsReturns.Add(this.cells[i]);               
            }
            indexLastDistributedCell += NUM_CELLS_BY_PANEL;
            return cellsReturns;
        }
     
        private void createCells()
        {
            for (int p = 0; p < NUM_PLAYERS; p++)
            {
                for (int nP = 0; nP < NUM_PANELS_BY_PLAYER; nP++)
                {
                    for (int i = 0; i < NUM_ROWS_PANEL; i++)
                    {
                        for (int j = 0; j < NUM_COLS_PANEL; j++)
                        {
                            this.cells.Add(new Cell(i, j));
                        }
                    }
                }
            }
        }       
    }
}
