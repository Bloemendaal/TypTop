using System;
using System.Numerics;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;

namespace SpaceInvadersMinigame
***REMOVED***
    public class Player : Entity
    ***REMOVED***
        public Player(Game game) : base(game)
        ***REMOVED***
            PositionComponent = new PositionComponent();
            AddComponent(PositionComponent);
            AddComponent(new VelocityComponent()***REMOVED*** Speed = 100***REMOVED***);
            AddComponent(new KeyboardMoveComponent());
            var collisionComponent = new CollisionComponent(new Size(150,150));
            AddComponent(collisionComponent);
            collisionComponent.Collision += CollisionComponentOnCollision;
            AddComponent(new ImageComponent(new BitmapImage(new Uri(@"player.png", UriKind.Relative))));
    ***REMOVED***

        public PositionComponent PositionComponent ***REMOVED*** get; set; ***REMOVED***

        private void CollisionComponentOnCollision(object sender, CollisionEventArgs e)
        ***REMOVED***
            if (e.Entity.GetType() == typeof(Crate))
            ***REMOVED***
                PositionComponent.Position -= e.PenetrationVector;
        ***REMOVED***

            if (e.Entity == ((SpaceInvadersGame) Game).Floor)
            ***REMOVED***
                PositionComponent.Position -= e.PenetrationVector;
        ***REMOVED***
    ***REMOVED***
***REMOVED***

    public class CollisionRectangle : Entity
    ***REMOVED***
        public CollisionRectangle(Game game, Rect rectangle) : base(game)
        ***REMOVED***
            AddComponent(new PositionComponent() ***REMOVED***Position = rectangle.Location.ToVector2()***REMOVED***);
            AddComponent(new CollisionComponent(rectangle.Size));
    ***REMOVED***
***REMOVED***
***REMOVED***