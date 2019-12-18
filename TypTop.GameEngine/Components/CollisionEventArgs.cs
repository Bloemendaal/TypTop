using System.Numerics;
using System.Windows;

namespace TypTop.GameEngine.Components
{
    public class CollisionEventArgs
    {
        public Entity Entity { get; }

        public Vector2 PenetrationVector { get; }

        public CollisionEventArgs(Entity entity, Vector2 penetrationVector)
        {
            Entity = entity;
            PenetrationVector = penetrationVector;
        }
    }
}