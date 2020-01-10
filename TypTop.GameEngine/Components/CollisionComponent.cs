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
        /// <summary>  Gets the center of a rectangle</summary>
        /// <param name="rect">The rect.</param>
        /// <returns></returns>
        public static Vector2 Center(this Rect rect)
        {
            return new Vector2((float) (rect.Left + rect.Width / 2),
                (float) (rect.Top + rect.Height / 2));
        }
    }

    /// <summary>Used for making entities collectable</summary>
    /// <seealso cref="TypTop.GameEngine.Component" />
    /// <seealso cref="TypTop.GameEngine.IUpdateable" />
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

        /// <summary>The collision bounding</summary>
        public Rect Bounding;

        /// <summary>Updates the component with the specified delta time.</summary>
        /// <param name="deltaTime">The delta time.</param>
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

        /// <summary>Occurs on collision.</summary>
        public event EventHandler<CollisionEventArgs> Collision;

        protected virtual void OnCollision(CollisionEventArgs e)
        {
            Collision?.Invoke(this, e);
        }
    }
}