using System.Collections.Generic;
using System.Numerics;

namespace TypTop.GameEngine.Components
{
    public class CameraComponent : Component
    {
        /// <summary>
        /// Position of the camera.
        /// </summary>
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
        private static readonly Dictionary<Game, Vector2> _position = new Dictionary<Game, Vector2>();

        /// <summary>
        /// X coordinate of the camera.
        /// </summary>
        public float X
        {
            get => _position.TryGetValue(Entity.Game, out Vector2 result) ? result.X : 0;
            set
            {
                _position.TryGetValue(Entity.Game, out Vector2 result);
                result.X = value;
            }
        }

        /// <summary>
        /// Y coordinate of the camera.
        /// </summary>
        public float Y
        {
            get => _position.TryGetValue(Entity.Game, out Vector2 result) ? result.Y : 0;
            set
            {
                _position.TryGetValue(Entity.Game, out Vector2 result);
                result.Y = value;
            }
        }

        /// <summary>
        /// Removes a camera from the Dictionary of running games. Do not use while running the game.
        /// </summary>
        /// <param name="game">
        /// TKey of the Dictionary.
        /// </param>
        /// <returns>
        /// If the removal was successfull.
        /// </returns>
        public static bool RemoveCamera(Game game) => _position.Remove(game);

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