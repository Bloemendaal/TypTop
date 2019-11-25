using System.Numerics;

namespace BasicGameEngine.GameEngine.Components
{
    public class VelocityComponent : Component, IUpdateable
    {
        private PositionComponent _positionComponent;
        public Vector2 Velocity { get; set; }
        public float Speed { get; set; } = 25f;

        public override void AddedToEntity()
        {
            _positionComponent = Entity.GetComponent<PositionComponent>();
        }

        public void Update(float deltaTime)
        {
            // Update position
            _positionComponent.Position += Velocity * deltaTime * Speed;
        }
    }
}