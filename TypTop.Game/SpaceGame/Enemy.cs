***REMOVED***
***REMOVED***
using System.Linq;
***REMOVED***
using System.Threading.Tasks;

namespace TypTop.Game.SpaceGame
***REMOVED***
    public class Enemy
    ***REMOVED***
        public string Word ***REMOVED*** get; private set; ***REMOVED***    //word the enemy carries along
        public int X ***REMOVED*** get; private set; ***REMOVED***  //horizontal position of enemy in field
        public int Y ***REMOVED*** get; private set; ***REMOVED***  //vertical position of enemy in field
        public int Score ***REMOVED*** get; private set; ***REMOVED***  //amount of points the enemy represents
        public int Speed ***REMOVED*** get; private set; ***REMOVED***  //amount of pixels the enemy moves each step

        public Enemy(int speed)
        ***REMOVED***
            Word = "word";  // set word
            X = 200;    // horizontal starting point
            Y = 0;      // vertical starting point
            Speed = speed;  // set speed
            Score = Word.Length * Speed;    // set base score
    ***REMOVED***

        // lets the enemy move with the designated speed each step
        public void Move() => Y+= Speed;    
***REMOVED***
***REMOVED***
