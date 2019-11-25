using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;
using System;
***REMOVED***
***REMOVED***
using System.Windows.Media.Imaging;

namespace TavernMinigame
***REMOVED***
    public class Background : Entity
    ***REMOVED***
        public Background(Game game) : base("background", game)
        ***REMOVED***
            AddComponent(new PositionComponent() ***REMOVED*** Position = new System.Numerics.Vector2(0, 0) ***REMOVED***);
            AddComponent(new ImageComponent(new BitmapImage(new Uri($@"Images/background.png", UriKind.Relative)))
            ***REMOVED***
                Width = Game.Width,
                Height = Game.Height
        ***REMOVED***);
    ***REMOVED***
***REMOVED***
***REMOVED***
