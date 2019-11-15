using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypTop.Gui.SpaceGame
{
    public class Enemy
    {
        public string Word { get; private set; }    //word the enemy carries along
        public int X { get; private set; }  //horizontal position of enemy in field
        public int Y { get; private set; }  //vertical position of enemy in field
        public int Score { get; private set; }  //amount of points the enemy represents
        public int Speed { get; private set; }  //amount of pixels the enemy moves each step

        public Enemy(int speed)
        {
            Word = "word";  // set word
            X = 200;    // horizontal starting point
            Y = 0;      // vertical starting point
            Speed = speed;  // set speed
            Score = Word.Length * Speed;    // set base score
        }

        // lets the enemy move with the designated speed each step
        public void Move() => Y+= Speed;    
    }
}
