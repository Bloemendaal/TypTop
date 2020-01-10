using System.Numerics;

namespace TypTop.GameEngine.Components
{
    /// <summary>Adds acceleration behaviour to target entity</summary>
    /// <seealso cref="TypTop.GameEngine.Component" />
    /// <seealso cref="TypTop.GameEngine.IUpdateable" />
    public class AccelerationComponent : Component, IUpdateable
    {
        private VelocityComponent _velocityComponent;

        /// <summary>  Acceleration direction</summary>
        /// <value>The acceleration.</value>
        public Vector2 Acceleration { get; set; }
        
        /// <summary>  Acceleration speed</summary>
        /// <value>The speed.</value>
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