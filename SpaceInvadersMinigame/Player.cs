using System;
using System.Numerics;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TypTop.GameEngine;
using TypTop.GameEngine.Components;


namespace SpaceInvadersMinigame
{
    public class Player : Entity
    {
        public Player(Game game) : base(game)
        {
            PositionComponent = new PositionComponent();
            AddComponent(PositionComponent);
            AddComponent(new VelocityComponent(){ Speed = 100});
            AddComponent(new KeyboardMoveComponent());
            var collisionComponent = new CollisionComponent(new Size(150,150));
            AddComponent(collisionComponent);
            collisionComponent.Collision += CollisionComponentOnCollision;
            AddComponent(new ImageComponent(new BitmapImage(new Uri(@"player.png", UriKind.Relative))));
        }

        public PositionComponent PositionComponent { get; set; }

        private void CollisionComponentOnCollision(object sender, CollisionEventArgs e)
        {
            if (e.Entity.GetType() == typeof(Crate))
            {
                PositionComponent.Position -= e.PenetrationVector;
            }

            if (e.Entity == ((SpaceInvadersGame) Game).Floor)
            {
                PositionComponent.Position -= e.PenetrationVector;
            }
        }
    }

    public class CollisionRectangle : Entity
    {
        public CollisionRectangle(Game game, Rect rectangle) : base(game)
        {
            AddComponent(new PositionComponent() {Position = rectangle.Location.ToVector2()});
            AddComponent(new CollisionComponent(rectangle.Size));
        }
    }
}