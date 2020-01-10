using System.Numerics;

namespace TypTop.GameEngine.Components
{
    /// <summary>Controls the speed of the component in the direction of the given vector.</summary>
    /// <seealso cref="TypTop.GameEngine.Component" />
    /// <seealso cref="TypTop.GameEngine.IUpdateable" />
    public class VelocityComponent : Component, IUpdateable
    {
        private PositionComponent _positionComponent;
        
        /// <summary>  Velocity direction</summary>
        /// <value>The velocity.</value>
        public Vector2 Velocity { get; set; }

        /// <summary>  Velocity speed multiplier</summary>
        /// <value>The speed.</value>
        public float Speed { get; set; } = 25f;

        public override void AddedToEntity()
        {
            _positionComponent = Entity.GetComponent<PositionComponent>();
        }

        public void Update(float deltaTime)
        {
            // Update position
            _positionComponent.AbsolutePosition += Velocity * deltaTime * Speed;
        }
    }
}