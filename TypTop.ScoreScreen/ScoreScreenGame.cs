using System;
using System.Globalization;
using System.Numerics;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TypTop.GameEngine;
using TypTop.GameEngine.Components;
using TypTop.MinigameEngine;

namespace TypTop.ScoreScreen
{
    public class ScorePanel : Entity
    {
        public ScorePanel(Game minigame) : base(minigame)
        {
            var r = Utils.GetRectangle(0, 1, 1, 0f, 1100f, 900f);
            var positionComponent = new PositionComponent
            {
                Position = new Vector2((float)r.X, (float)r.Y)
            };
            var imageComponent = new ImageComponent(new BitmapImage(new Uri($@"Images/gehaald.png", UriKind.Relative)))
            {
                Width = r.Width,
                Height = r.Height
            };

            AddComponent(positionComponent);
            AddComponent(imageComponent);
        }

        public override void Draw(DrawingContext drawingContext)
        {
            base.Draw(drawingContext);
        }
    }

    public class ScoreScreenGame : Game
    {
        public event EventHandler Closed;

        public ScoreScreenGame()
        {
            AddEntity(new Background("score_background.jpg", this));
            var backButton = new Button("backButton.png", new Rect(new Point(50, 900), new Size(100, 100)), this);
            backButton.Clicked += BackButtonOnClicked;
            AddEntity(backButton);

            AddEntity(new ScorePanel(this));
        }

        private void BackButtonOnClicked(object sender, EventArgs e)
        {
            OnClosed();
        }

        protected virtual void OnClosed()
        {
            Closed?.Invoke(this, EventArgs.Empty);
        }
    }
}
