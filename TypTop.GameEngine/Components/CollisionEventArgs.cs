using System.Numerics;
using System.Windows;

namespace TypTop.GameEngine.Components
{
    /// <summary>Collision information</summary>
    public class CollisionEventArgs
    {
        /// <summary>  Entity collided with.</summary>
        /// <value>The entity.</value>
        public Entity Entity { get; }

        /// <summary>  Overlap of the collision</summary>
        /// <value>The penetration vector.</value>
        public Vector2 PenetrationVector { get; }

        public CollisionEventArgs(Entity entity, Vector2 penetrationVector)
        {
            Entity = entity;
            PenetrationVector = penetrationVector;
        }
    }
}