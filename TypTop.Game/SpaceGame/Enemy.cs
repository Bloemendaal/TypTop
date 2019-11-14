using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypTop.Game.SpaceGame
{
    public class Enemy
    {
        public string Word { get; private set; }    //word the enemy carries along
        public int X { get; private set; }  //horizontal position of enemy in field
        public int Y { get; private set; }  //vertical position of enemy in field
        public int Score { get; private set; }  //amount of points the enemy represents

        public Enemy()
        {

        }
    }
}
