using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleshipLib.models
{
    internal class Rules
    {
        private int numAircraftCarriers;
        private int numVessels;
        private int numSubmarines;
        private int numCruises;
        private int numBoats;

        internal Rules()
        {
            this.numAircraftCarriers = 1;
            this.numVessels = 1;
            this.numSubmarines = 1;
            this.numCruises = 1;
            this.numBoats = 1;
        }

        internal bool validateWinner(List<Cell> enemyCells)
        {
            bool[] destroyedTable = this.getDestroyedTable(enemyCells);
            return this.hasNumAircraftCarriers(destroyedTable) && this.hasNumVessels() && this.hasNumSubmarines() && this.hasNumCruises() && this.hasNumBoats();
        }

        private bool[] getDestroyedTable(List<Cell> enemyCells)
        {
            bool[] table = new bool[Board.NUM_ROWS_PANEL * Board.NUM_COLS_PANEL];
            int i = 0;
            foreach (Cell cell in enemyCells)
            {
                table[i] = cell.isDestroyed();
            }
            return table;
        }

        private bool hasNumAircraftCarriers(bool[] cells)
        {
            for (int i = 0; i < Board.NUM_ROWS_PANEL; i++)
            {
                
            }
            return false;
        }

        private bool hasNumVessels()
        {
            throw new NotImplementedException();
        }

        private bool hasNumBoats()
        {
            throw new NotImplementedException();
        }

        private bool hasNumCruises()
        {
            throw new NotImplementedException();
        }

        private bool hasNumSubmarines()
        {
            throw new NotImplementedException();
        }       
        
    }
}
