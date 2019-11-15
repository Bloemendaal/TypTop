using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypTop.Gui.SpaceGame
{
    public class Player
    {
        public int Lives { get; private set; }  //amount of chances left
        public int Score { get; private set; }  //total amount of earned points

        public Player()
        {
            Lives = 4;  // start amount of lives
            Score = 0;  // start amount of points
        }

        // gain points, add to score
        public void GainScore(int score) => Score += score; 

        // lose points, substract from score
        public void LoseScore(int score) => Score -= score; 
        
        // gain one life
        public void GainLife() => Lives++;  

        // lose on life
        public void LoseLife() => Lives--;  
        
    }
}
