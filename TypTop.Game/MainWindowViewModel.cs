***REMOVED***
using System.Windows;
using System.Windows.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TypTop.Game.MonoGameControls;

namespace TypTop.Game
***REMOVED***
    public class MainWindowViewModel : MonoGameViewModel
    ***REMOVED***
        private readonly MainWindow _mainWindow;
        private SpriteBatch _spriteBatch;

        public MainWindowViewModel(MainWindow mainWindow)
        ***REMOVED***
            _mainWindow = mainWindow;
    ***REMOVED***

        public override void LoadContent()
        ***REMOVED***
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _font = Content.Load<SpriteFont>("DefaultFont");
    ***REMOVED***

        public override void Initialize()
        ***REMOVED***
            _mainWindow.TextInput += MainWindowOnTextInput;
            base.Initialize();
    ***REMOVED***

        private string _total;
        private SpriteFont _font;

        private void MainWindowOnTextInput(object sender, TextCompositionEventArgs e)
        ***REMOVED***
            _total += e.Text;
    ***REMOVED***

        public override void Update(GameTime gameTime)
        ***REMOVED***
            
    ***REMOVED***

        public override void Draw(GameTime gameTime)
        ***REMOVED***
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.DrawString(_font, _total??"Typ om te beginnen", new Vector2(30,30), Color.Black);
            _spriteBatch.End();
    ***REMOVED***
***REMOVED***
***REMOVED***