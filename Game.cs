using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_GUI_temp1
{
    internal class Game
    {
        public Game()
        {
            gamedeck = new Deck();
            playerhand = new Hand();
            dealerhand = new Hand();

            playerhand.DrawFrom(gamedeck);
            playerhand.DrawFrom(gamedeck);
            dealerhand.DrawFrom(gamedeck);
            dealerhand.DrawFrom(gamedeck);
        }

        public Deck gamedeck;
        public Hand dealerhand;
        public Hand playerhand;
    }


}
