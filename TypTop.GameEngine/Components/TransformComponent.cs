using System.Numerics;

namespace BasicGameEngine.GameEngine.Components
{
    public class TransformComponent : Component, IUpdateable
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public float Speed { get; set; } = 25f;
        public void Update(float deltaTime)
        {
            // Update position
            Position = Position + Velocity * deltaTime * Speed;
        }
    }
}