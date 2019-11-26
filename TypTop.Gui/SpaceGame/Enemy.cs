***REMOVED***
***REMOVED***
using System.Linq;
***REMOVED***
using System.Threading.Tasks;
using TypTop.Logic;

namespace TypTop.Gui.SpaceGame
***REMOVED***
    public class Enemy
    ***REMOVED***
        public Word Word ***REMOVED*** get; private set; ***REMOVED***    //word the enemy carries along
        public int X ***REMOVED*** get; private set; ***REMOVED***  //horizontal position of enemy in field
        public int Y ***REMOVED*** get; private set; ***REMOVED***  //vertical position of enemy in field
        public int Score ***REMOVED*** get; private set; ***REMOVED***  //amount of points the enemy represents
        public int Speed ***REMOVED*** get; private set; ***REMOVED***  //amount of pixels the enemy moves each step
        public static Random Random ***REMOVED*** get; set; ***REMOVED*** = new Random(DateTime.Now.Millisecond);
        public Enemy(int speed, Word word)
        ***REMOVED***
            Word = word;  
            X = Random.Next(400);    
            Y = 0;      
            Speed = speed;  // set speed
            Score = Word.Letters.Length * Speed;    // set base score
    ***REMOVED***

        // To let the enemy move with the designated speed each tick
        public void Move() => Y+= Speed;    
***REMOVED***
***REMOVED***
