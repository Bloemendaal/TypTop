***REMOVED***
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TypTop.Game.MonoGameControls;

namespace TypTop.Game
***REMOVED***
    public class MainWindowViewModel : MonoGameViewModel
    ***REMOVED***
        private SpriteBatch _spriteBatch;
        private Texture2D _texture;
        private Vector2 _position;
        private float _rotation;
        private Vector2 _origin;
        private Vector2 _scale;

        public override void LoadContent()
        ***REMOVED***
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _texture = Content.Load<Texture2D>("monogame-logo");
    ***REMOVED***

        public override void Update(GameTime gameTime)
        ***REMOVED***
            _position = GraphicsDevice.Viewport.Bounds.Center.ToVector2();
            _rotation = (float)Math.Sin(gameTime.TotalGameTime.TotalSeconds) / 4f;
            _origin = _texture.Bounds.Center.ToVector2();
            _scale = Vector2.One;
    ***REMOVED***

        public override void Draw(GameTime gameTime)
        ***REMOVED***
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(_texture, _position, null, Color.White, _rotation, _origin, _scale, SpriteEffects.None, 0f);
            _spriteBatch.End();
    ***REMOVED***
***REMOVED***
***REMOVED***