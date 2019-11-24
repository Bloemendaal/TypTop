using System.Numerics;

namespace BasicGameEngine.GameEngine.Components
{
    public class TransformComponent : Component, IUpdateable, IResizable
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public float Speed { get; set; } = 25f;
        public bool Relative 
        { 
            get => _relative; 
            set {
                if (value != _relative)
                {
                    if (value)
                    {
                        Position = new Vector2(Position.X / (float)Entity.Game.Width, Position.Y / (float)Entity.Game.Height);
                    }
                    else
                    {
                        Position = new Vector2(Position.X / 100 * (float)Entity.Game.Width, Position.Y / 100 * (float)Entity.Game.Height);
                    }
                }

                _relative = value;
            }
        }
        private bool _relative;

        public void Resize()
        {
            Relative = Entity.Game.Relative;
        }

        public void Update(float deltaTime)
        {
            // Update position
            Position += Velocity * deltaTime * Speed;
        }
    }
}