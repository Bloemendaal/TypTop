using System.Numerics;

namespace TypTop.GameEngine.Components
{
    public class CollisionEventArgs
    {
        public CollisionEventArgs(Entity entity, Vector2 penetrationVector)
        {
            Entity = entity;
            PenetrationVector = penetrationVector;
        }

        public Entity Entity { get; }

        public Vector2 PenetrationVector { get; }
    }
}