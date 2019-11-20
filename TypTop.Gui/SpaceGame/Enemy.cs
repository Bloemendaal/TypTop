using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypTop.Logic;

namespace TypTop.Gui.SpaceGame
{
    public class Enemy
    {
        public Word Word { get; private set; }    //word the enemy carries along
        public int X { get; private set; }  //horizontal position of enemy in field
        public int Y { get; private set; }  //vertical position of enemy in field
        public int Score { get; private set; }  //amount of points the enemy represents
        public int Speed { get; private set; }  //amount of pixels the enemy moves each step
        public static Random Random { get; set; } = new Random(DateTime.Now.Millisecond);   // static random object
        public Enemy(int speed, Word word)
        {
            Word = word;  // set word
            X = (Random.Next(1,16))*50;   // set horizontal position 
            Y = 0;      // set vertical position
            Speed = speed;  // set speed
            Score = Word.Letters.Length * Speed;    // set base score
        }

        // To let the enemy move with the designated speed each tick
        public void Move() => Y+= Speed;    
    }
}
