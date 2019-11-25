***REMOVED***
using System.Drawing;
using System.Numerics;
using System.Windows;
using Microsoft.VisualBasic.FileIO;
using Point = System.Windows.Point;
using Size = System.Windows.Size;

namespace BasicGameEngine.GameEngine.Components
***REMOVED***
    public static class RectangleExtension
    ***REMOVED***
        public static Vector2 Center(this Rect rect)
        ***REMOVED***
            return new Vector2((float) (rect.Left + rect.Width / 2),
                (float) (rect.Top + rect.Height / 2));
    ***REMOVED***
***REMOVED***
    

    public class CollisionComponent : Component, IUpdateable
    ***REMOVED***
        private PositionComponent _positionComponent;

        public CollisionComponent(Size size)
        ***REMOVED***
            Bounding = new Rect(size);
    ***REMOVED***

        public override void AddedToEntity()
        ***REMOVED***
            _positionComponent = Entity.GetComponent<PositionComponent>();
    ***REMOVED***

        public Rect Bounding;

        public void Update(float deltaTime)
        ***REMOVED***
            //Update bounding box location
            Bounding.Location = new Point(_positionComponent.Position.X, _positionComponent.Position.Y);

            //Check for collisions
            foreach (Entity otherEntity in Entity.Game.GetEntitiesWithComponent<CollisionComponent>())
            ***REMOVED***
                //Skip self
                if(otherEntity == Entity)
                    continue;

                var otherCollisionComponent = otherEntity.GetComponent<CollisionComponent>();
                if (otherCollisionComponent.Bounding.IntersectsWith(Bounding))
                ***REMOVED***
                    Rect ownBounding = Bounding;
                    Rect otherBounding = otherCollisionComponent.Bounding;

                    Vector2 penetration;


                    Rect intersectingRectangle = ownBounding;
                    intersectingRectangle.Intersect(otherCollisionComponent.Bounding);

                    if (intersectingRectangle.Width < intersectingRectangle.Height)
                    ***REMOVED***
                        double d = ownBounding.Center().X < otherBounding.Center().X
                            ? intersectingRectangle.Width
                            : -intersectingRectangle.Width;
                        penetration = new Vector2((float) d, 0);
                ***REMOVED***
                    else
                    ***REMOVED***
                        double d = ownBounding.Center().Y < otherBounding.Center().Y
                            ? intersectingRectangle.Height
                            : -intersectingRectangle.Height;
                        penetration = new Vector2(0, (float) d);
                ***REMOVED***

                    OnCollision(new CollisionEventArgs(otherEntity, penetration));
            ***REMOVED***
        ***REMOVED***
    ***REMOVED***

        


        public event EventHandler<CollisionEventArgs> Collision;

        protected virtual void OnCollision(CollisionEventArgs e)
        ***REMOVED***
            Collision?.Invoke(this, e);
    ***REMOVED***
***REMOVED***
***REMOVED***