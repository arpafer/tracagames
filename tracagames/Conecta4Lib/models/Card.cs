using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Conecta4LibTest")]

namespace Conecta4Lib.models
{            
    internal class Card
    {
        private Color color;
        private State state;

        public Card(Color color)
        {
            this.color = color;
            this.state = State.IN_BOARD;
        }

        public Card(Color color, State state)
        {
            this.color = color;
            this.state = state;
        }

        internal void set(Color color, State state)
        {
            this.color = color;
            this.state = state;
        }

        internal void goToBoard()
        {
            this.state = State.IN_BOARD;
        }

        internal bool hasColor(Color color)
        {
            return this.color == color;
        }

        internal bool isInPlayer()
        {
            return this.state == State.IN_PLAYER;
        }
    }
}