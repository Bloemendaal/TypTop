
using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;
using System;
***REMOVED***
using System.Numerics;
***REMOVED***
using System.Windows.Media.Imaging;

namespace Typop.SpaceGame
***REMOVED***
    public class Background : Entity
    ***REMOVED***
        public Background(Game game) : base(game)
        ***REMOVED***
            AddComponent(new PositionComponent()
            ***REMOVED***
                Position = new Vector2(0, 0)
        ***REMOVED***);
            AddComponent(new ImageComponent(new BitmapImage(new Uri(@"Images/space.jpg", UriKind.Relative)))
            ***REMOVED***
                Width = Game.Width,
                Height = Game.Height
        ***REMOVED***);
    ***REMOVED***
***REMOVED***
***REMOVED***