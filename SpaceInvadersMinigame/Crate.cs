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

        public Crate(Game game) : base("crate", game)
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
            _transformComponent.Position -= e.PenetrationVector;
        }
    }
}