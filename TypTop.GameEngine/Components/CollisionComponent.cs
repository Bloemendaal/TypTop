using System;
using System.Drawing;
using System.Numerics;
using System.Windows;
using Microsoft.VisualBasic.FileIO;
using Point = System.Windows.Point;
using Size = System.Windows.Size;

namespace TypTop.GameEngine.Components
{
    public static class RectangleExtension
    {
        public static Vector2 Center(this Rect rect)
        {
            return new Vector2((float) (rect.Left + rect.Width / 2),
                (float) (rect.Top + rect.Height / 2));
        }
    }

    public class CollisionComponent : Component, IUpdateable
    {
        private PositionComponent _positionComponent;

        public CollisionComponent(Size size)
        {
            Bounding = new Rect(size);
        }

        public override void AddedToEntity()
        {
            _positionComponent = Entity.GetComponent<PositionComponent>();
        }

        public Rect Bounding;

        public void Update(float deltaTime)
        {
            //Update bounding box location
            Bounding.Location = new Point(_positionComponent.Position.X, _positionComponent.Position.Y);

            //Check for collisions
            foreach (Entity otherEntity in Entity.Game.GetEntitiesWithComponent<CollisionComponent>())
            {
                //Skip self
                if(otherEntity == Entity)
                    continue;

                var otherCollisionComponent = otherEntity.GetComponent<CollisionComponent>();
                if (otherCollisionComponent.Bounding.IntersectsWith(Bounding))
                {
                    Rect ownBounding = Bounding;
                    Rect otherBounding = otherCollisionComponent.Bounding;

                    Vector2 penetration;


                    Rect intersectingRectangle = ownBounding;
                    intersectingRectangle.Intersect(otherCollisionComponent.Bounding);

                    if (intersectingRectangle.Width < intersectingRectangle.Height)
                    {
                        double d = ownBounding.Center().X < otherBounding.Center().X
                            ? intersectingRectangle.Width
                            : -intersectingRectangle.Width;
                        penetration = new Vector2((float) d, 0);
                    }
                    else
                    {
                        double d = ownBounding.Center().Y < otherBounding.Center().Y
                            ? intersectingRectangle.Height
                            : -intersectingRectangle.Height;
                        penetration = new Vector2(0, (float) d);
                    }

                    OnCollision(new CollisionEventArgs(otherEntity, penetration));
                }
            }
        }

        


        public event EventHandler<CollisionEventArgs> Collision;

        protected virtual void OnCollision(CollisionEventArgs e)
        {
            Collision?.Invoke(this, e);
        }
    }
}