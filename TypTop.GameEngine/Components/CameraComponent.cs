using System.Collections.Generic;
using System.Numerics;

namespace TypTop.GameEngine.Components
{
    public class CameraComponent : Component
    {
        public Vector2 Position
        {
            get => _position.TryGetValue(Entity.Game, out Vector2 result) ? result : new Vector2(0,0);
            set
            {
                if (_position.ContainsKey(Entity.Game))
                {
                    _position[Entity.Game] = value;
                }
            }
        }
        private readonly static Dictionary<Game, Vector2> _position = new Dictionary<Game, Vector2>();

        public float X
        {
            get => _position.TryGetValue(Entity.Game, out Vector2 result) ? result.X : 0;
            set
            {
                _position.TryGetValue(Entity.Game, out Vector2 result);
                result.X = value;
            }
        }
        public float Y
        {
            get => _position.TryGetValue(Entity.Game, out Vector2 result) ? result.Y : 0;
            set
            {
                _position.TryGetValue(Entity.Game, out Vector2 result);
                result.Y = value;
            }
        }

        public override void AddedToEntity()
        {
            if (!_position.ContainsKey(Entity.Game))
            {
                _position.Add(Entity.Game, new Vector2(0, 0));
            }

            base.AddedToEntity();
        }
    }
}