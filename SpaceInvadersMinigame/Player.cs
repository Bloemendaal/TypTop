using System;
using System.Numerics;
using System.Windows;
using System.Windows.Media.Imaging;
using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;

namespace SpaceInvadersMinigame
***REMOVED***
    public class Player : Entity
    ***REMOVED***
        public Player(Game game) : base("player", game)
        ***REMOVED***
            AddComponent(new TransformComponent() ***REMOVED***Speed = 50***REMOVED***);
            AddComponent(new KeyboardMoveComponent());
            AddComponent(new CollisionComponent(new Size(150,150)));
            AddComponent(new ImageComponent(new BitmapImage(new Uri(@"player.png", UriKind.Relative))));
    ***REMOVED***
***REMOVED***
***REMOVED***