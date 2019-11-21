using System;
using System.Windows;
using System.Windows.Media.Imaging;
using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;

namespace SpaceInvadersMinigame
***REMOVED***
    public class Crate : Entity
    ***REMOVED***
        private readonly TransformComponent _transformComponent;

        public Crate(Game game) : base("crate", game)
        ***REMOVED***
            _transformComponent = new TransformComponent();
            AddComponent(_transformComponent);
            var collisionComponent = new CollisionComponent(new Size(150, 150));
            AddComponent(collisionComponent);
            AddComponent(new ImageComponent(new BitmapImage(new Uri(@"krat.png", UriKind.Relative))));

            collisionComponent.Collision += CollisionComponentOnCollision;
    ***REMOVED***

        private void CollisionComponentOnCollision(object? sender, CollisionEventArgs e)
        ***REMOVED***
            _transformComponent.Position -= e.PenetrationVector;
    ***REMOVED***
***REMOVED***
***REMOVED***