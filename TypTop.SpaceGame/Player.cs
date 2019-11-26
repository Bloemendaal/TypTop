***REMOVED***
***REMOVED***
using System.Numerics;
***REMOVED***
using System.Windows;
using System.Windows.Media.Imaging;
using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;

namespace TypTop.SpaceGame
***REMOVED***
    public class Player : Entity
    ***REMOVED***
        public int Lives ***REMOVED*** get; private set; ***REMOVED***  //amount of chances left
        public int Score ***REMOVED*** get; private set; ***REMOVED***  //total amount of earned points

        public Player(Game game) : this(4, game) ***REMOVED*** ***REMOVED***

        public Player(int lives, Game game) : base("Player", game)
        ***REMOVED***
            Lives = lives;  // start amount of lives
            Score = 0;  // start amount of points

            AddComponent(new PositionComponent()
            ***REMOVED***
                Position = new Vector2(885, 885)
        ***REMOVED***);
            AddComponent(new ImageComponent(new BitmapImage(new Uri(@"Images/spaceship.png", UriKind.Relative)))
            ***REMOVED***
                Width = 150
        ***REMOVED***);
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
