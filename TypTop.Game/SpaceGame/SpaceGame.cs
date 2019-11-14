using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypTop.Game.SpaceGame
{
    public class SpaceGame
    {
        public Player Player { get; set; }

        public SpaceGame()
        {
            Player = new Player();
        }
    }
}
