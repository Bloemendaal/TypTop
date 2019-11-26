using System;
using System.Windows;
using System.Windows.Media.Imaging;
using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;

namespace SpaceInvadersMinigame
***REMOVED***
    public class Crate : Entity
    ***REMOVED***
        private readonly PositionComponent _positionComponent;

        public Crate(string name, Game game) : base(game)
        ***REMOVED***
            _positionComponent = new PositionComponent();
            AddComponent(_positionComponent);
            var collisionComponent = new CollisionComponent(new Size(150, 150));
            AddComponent(collisionComponent);
            AddComponent(new ImageComponent(new BitmapImage(new Uri(@"krat.png", UriKind.Relative))));
            collisionComponent.Collision += CollisionComponentOnCollision;
    ***REMOVED***

        private void CollisionComponentOnCollision(object? sender, CollisionEventArgs e)
        ***REMOVED***
            if (e.Entity is Crate)
            ***REMOVED***
                _positionComponent.Position -= e.PenetrationVector / 2;

        ***REMOVED***
            else
                _positionComponent.Position -= e.PenetrationVector;
    ***REMOVED***
***REMOVED***
***REMOVED***