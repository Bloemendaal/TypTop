***REMOVED***
***REMOVED***
using System.Linq;
***REMOVED***
using System.Threading.Tasks;

namespace TypTop.Game.SpaceGame
***REMOVED***
    public class Player
    ***REMOVED***
        public int Lives ***REMOVED*** get; private set; ***REMOVED***  //amount of chances left
        public int Score ***REMOVED*** get; private set; ***REMOVED***  //total amount of earned points

        public Player()
        ***REMOVED***
            Lives = 4;  // start amount of lives
            Score = 0;  // start amount of points
    ***REMOVED***

        // gain points, add to score
        public void GainScore(int score) => Score += score; 

        // lose points, substract from score
        public void LoseScore(int score) => Score -= score; 
        
        // gain one life
        public void GainLife() => Lives++;  

        // lose on life
        public void LoseLife() => Lives--;  
        
***REMOVED***
***REMOVED***
