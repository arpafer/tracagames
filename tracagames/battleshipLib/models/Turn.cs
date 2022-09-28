using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleshipLib.models
{
    internal class Turn
    {
        private const int NUM_PLAYERS = 2;
        private List<Player> players;
        private Board board;
        private int currentPlayerIndex;
        private int initialPlayerIndex;

        internal Turn(Board board)
        {
            this.currentPlayerIndex = this.initialPlayerIndex = 0;
            this.board = board;
            this.players = new List<Player>();
            for (int i = 0; i < NUM_PLAYERS; i++)
            {
                this.players.Add(new Player(this.board));                
            }
        }

        internal void change()
        {
            this.currentPlayerIndex = (this.currentPlayerIndex + 1) % 2;
        }

        internal void setInitialPlayerIndex(int index)
        {
            this.currentPlayerIndex = this.initialPlayerIndex = index;            
        }

        internal void move(int r, int c)
        {
            this.players[this.currentPlayerIndex].move(r, c);
        }

        internal bool isEnemyCellDestroyed(int r, int c)
        {
            return this.players[this.currentPlayerIndex].isEnemyCellDestroyed(r, c);
        }

        internal bool isMarked(int r, int c)
        {
            return this.players[this.currentPlayerIndex].isOwnCellDestroyed(r, c);
        }

        internal bool isWinner()
        {
            return this.players[this.currentPlayerIndex].isWinner();
        }
    }
}
