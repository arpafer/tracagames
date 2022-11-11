using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tracagamesLib.rummy.models
{
    internal class Game
    {
        private const int NUM_CARDS = 108;        
        private List<Player> players;
        private Turn turn;        
        private Mallet mallet;
        
        internal Game(int numPlayers)
        {
            this.players = new List<Player>(numPlayers);
            this.mallet = new Mallet();
            GameInitializer gameInitializer = new GameInitializer(this.players, this.mallet);
            this.turn = new Turn(this.players, gameInitializer.getStartingPlayer(), this.mallet);
        } 

        internal void play()
        {            
            do
            {
                this.turn.play();
                this.turn.change();
            } while (!this.turn.hasWinner());
        }

        internal void playTurn()
        {
            this.turn.play();            
        }
        
        internal bool hasPlayerInitialMinimunPoints()
        {
            return this.turn.hasPlayerInitialMinimunPoints();
        }

        internal void changeTurn()
        {
            this.turn.change();
        }

        internal bool hasWinner()
        {
            return this.turn.hasWinner();
        }
    }
}
