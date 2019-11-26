using System.Numerics;

namespace BasicGameEngine.GameEngine.Components
{
    public class PositionComponent : Component
    {
        public Vector2 Position
        {
            get => _position;
            set
            {
                _position = value;
            }
        }
        private Vector2 _position;

        public float X
        {
            get => Position == null ? 0 : Position.X;
            set
            {
                if (_position == null)
                {
                    _position = new Vector2(value, 0);
                }
                else
                {
                    _position.X = value;
                }
                
            }
        }
        public float Y
        {
            get => Position == null ? 0 : Position.Y;
            set
            {
                if (_position == null)
                {
                    _position = new Vector2(0, value);
                }
                else
                {
                    _position.Y = value;
                }

            }
        }
    }
}