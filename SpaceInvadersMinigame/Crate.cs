using System;
using System.Windows;
using System.Windows.Media.Imaging;
using TypTop.GameEngine;
using TypTop.GameEngine.Components;

namespace SpaceInvadersMinigame
{
    public class Crate : Entity
    {
        private readonly PositionComponent _positionComponent;

        public Crate(string name, Game game) : base(game)
        {
            _positionComponent = new PositionComponent();
            AddComponent(_positionComponent);
            var collisionComponent = new CollisionComponent(new Size(150, 150));
            AddComponent(collisionComponent);
            AddComponent(new ImageComponent(new BitmapImage(new Uri(@"krat.png", UriKind.Relative))));
            collisionComponent.Collision += CollisionComponentOnCollision;
        }

        private void CollisionComponentOnCollision(object? sender, CollisionEventArgs e)
        {
            if (e.Entity is Crate)
            {
                _positionComponent.Position -= e.PenetrationVector / 2;

            }
            else
                _positionComponent.Position -= e.PenetrationVector;
        }
    }
}