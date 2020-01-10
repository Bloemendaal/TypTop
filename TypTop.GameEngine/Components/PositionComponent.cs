using System.Numerics;

namespace TypTop.GameEngine.Components
{
    /// <summary>Used by other components to determine Entity position</summary>
    /// <seealso cref="TypTop.GameEngine.Component" />
    public class PositionComponent : Component
    {
        private CameraComponent _camera;

        /// <summary>  Render position</summary>
        /// <value>The position.</value>
        public Vector2 Position
        {
            get => AbsolutePosition - (_camera?.Position ?? new Vector2(0, 0));
            set => _position = value;
        }
        private Vector2 _position;

        /// <summary>  Horizontal position where the entity is rendered</summary>
        /// <value>The x.</value>
        public float X
        {
            get => AbsoluteX + (_camera?.X ?? 0);
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
        /// <summary> Vertical Position where the entity is rendered</summary>
        /// <value>The y.</value>
        public float Y
        {
            get => AbsoluteY - (_camera?.Y ?? 0);
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

        /// <summary>Gets or sets the absolute position.</summary>
        /// <value>The absolute position.</value>
        public Vector2 AbsolutePosition
        {
            get => _position;
            set => _position = value;
        }

        public float AbsoluteX
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
        public float AbsoluteY
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