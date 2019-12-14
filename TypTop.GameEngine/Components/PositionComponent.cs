using System.Numerics;

namespace TypTop.GameEngine.Components
{
    public class PositionComponent : Component
    {
        private CameraComponent _camera;

        public Vector2 Position
        {
            get => _position - (_camera?.Position ?? new Vector2(0, 0));
            set => _position = value;
        }
        private Vector2 _position;

        public float X
        {
            get => (Position == null ? 0 : Position.X) - (_camera?.X ?? 0);
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
            get => (Position == null ? 0 : Position.Y) - (_camera?.Y ?? 0);
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

        public PositionComponent() : this(new Vector2(0, 0)) { }
        public PositionComponent(float x, float y) : this(new Vector2(x, y)) { }
        public PositionComponent(Vector2 position)
        {
            Position = position;
        }

        public override void AddedToEntity()
        {
            if (Entity.HasComponent<CameraComponent>())
            {
                _camera = Entity.GetComponent<CameraComponent>();
            }

            base.AddedToEntity();
        }
    }
}