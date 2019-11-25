using System;
using System.Windows;
using System.Windows.Media.Imaging;
using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;

namespace SpaceInvadersMinigame
{


    public class Crate : Entity
    {
        private readonly TransformComponent _transformComponent;

        public Crate(string name, Game game) : base(name, game)
        {
            _transformComponent = new TransformComponent();
            AddComponent(_transformComponent);
            var collisionComponent = new CollisionComponent(new Size(150, 150));
            AddComponent(collisionComponent);
            AddComponent(new ImageComponent(new BitmapImage(new Uri(@"krat.png", UriKind.Relative))));
            collisionComponent.Collision += CollisionComponentOnCollision;
        }

        private void CollisionComponentOnCollision(object? sender, CollisionEventArgs e)
        {
            if (e.Entity is Crate)
            {
                _transformComponent.Position -= e.PenetrationVector / 2;

            }
            else
                _transformComponent.Position -= e.PenetrationVector;
        }
    }
}