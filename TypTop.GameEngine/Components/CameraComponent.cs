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

        /// <summary>
        /// Get X by key.
        /// </summary>
        /// <param name="game">
        /// TKey of the Dictionary.
        /// </param>
        /// <returns>
        /// X coordinate.
        /// </returns>
        public static float GetX(Game game)
        {
            _position.TryGetValue(game, out Vector2 vector2);
            return vector2.X;
        }

        /// <summary>
        /// Get Y by key.
        /// </summary>
        /// <param name="game">
        /// TKey of the Dictionary.
        /// </param>
        /// <returns>
        /// Y coordinate.
        /// </returns>
        public static float GetY(Game game)
        {
            _position.TryGetValue(game, out Vector2 vector2);
            return vector2.Y;
        }

        /// <summary>
        /// Get Position by key.
        /// </summary>
        /// <param name="game">
        /// TKey of the Dictionary.
        /// </param>
        /// <returns>
        /// Vector2 coordinates.
        /// </returns>
        public static Vector2 GetPosition(Game game)
        {
            _position.TryGetValue(game, out Vector2 vector2);
            return vector2;
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