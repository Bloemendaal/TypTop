using System.Numerics;

namespace TypTop.GameEngine.Components
{
    public class AccelerationComponent : Component, IUpdateable
    {
        private VelocityComponent _velocityComponent;
        public Vector2 Acceleration { get; set; }
        public float Speed { get; set; } = 25f;

        public override void AddedToEntity()
        {
            _velocityComponent = Entity.GetComponent<VelocityComponent>();
        }

        public void Update(float deltaTime)
        {
            // Update velocity
            _velocityComponent.Velocity += Acceleration * deltaTime * Speed;
        }
    }
}