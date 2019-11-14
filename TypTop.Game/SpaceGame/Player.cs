using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypTop.Game.SpaceGame
{
    public class Player
    {
        public int Lives { get; private set; }  //amount of chances left
        public int Score { get; private set; }  //total amount of earned points
    }
}
