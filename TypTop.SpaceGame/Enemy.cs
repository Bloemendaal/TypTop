***REMOVED***
***REMOVED***
using System.Numerics;
***REMOVED***
using System.Windows.Media.Imaging;
using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;
using TypTop.Logic;

namespace TypTop.SpaceGame
***REMOVED***
    public class Enemy : Entity
    ***REMOVED***
        public Word Word ***REMOVED*** get; private set; ***REMOVED***
        public int Speed ***REMOVED*** get; private set; ***REMOVED***
        private PositionComponent _positionComponent;

        public Enemy(int speed, int amountOfWords, Word word, Game game) : base(game)
        ***REMOVED***
            _positionComponent = new PositionComponent()
            ***REMOVED***
                Position = new Vector2(game.Rnd.Next(150, 1720), (game.Rnd.Next(0, amountOfWords * 150)*-1))
        ***REMOVED***;
            AddComponent(_positionComponent);
            AddComponent(new VelocityComponent()
            ***REMOVED***
                Velocity = new Vector2(0, (float)speed)
        ***REMOVED***);
            AddComponent(new WordComponent(word));
            AddComponent(new ImageComponent(new BitmapImage(new Uri(@"Images/enemy.png", UriKind.Relative)))
            ***REMOVED***
                Width = 150
        ***REMOVED***);
            Word = word;
            Speed = speed;
    ***REMOVED***
***REMOVED***
***REMOVED***
