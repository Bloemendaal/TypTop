using System;
using System.Globalization;
using System.Net.Mime;
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
        private readonly FinishEventArgs _finishEventArgs;
        private FormattedText _scoreText;
        private BitmapImage _startImage;


        public ScorePanel(Game minigame, FinishEventArgs finishEventArgs) : base(minigame)
        {
            _finishEventArgs = finishEventArgs;
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

            _startImage = new BitmapImage(new Uri($@"Images/star.png", UriKind.Relative));

            _scoreText = new FormattedText(
#pragma warning restore 618
                finishEventArgs.Score.ToString(),
                CultureInfo.GetCultureInfo("en-us"),
                FlowDirection.LeftToRight,
                new Typeface("Kristen ITC"),
                40,
                Brushes.Black);

            AddComponent(positionComponent);
            AddComponent(imageComponent);
        }

        public override void Draw(DrawingContext drawingContext)
        {
            base.Draw(drawingContext);
            drawingContext.DrawText(_scoreText, new Point(870,690));
            if(_finishEventArgs.Stars >= 1) 
                drawingContext.DrawImage(_startImage, new Rect(620,510, 190,120));
            if (_finishEventArgs.Stars >= 2)
                drawingContext.DrawImage(_startImage, new Rect(845,450, 230,150));
            if (_finishEventArgs.Stars >= 3)
                drawingContext.DrawImage(_startImage, new Rect(1105,510, 190, 120));
        }
    }

    public class ScoreScreenGame : Game
    {
     
        public event EventHandler Closed;

        public ScoreScreenGame(FinishEventArgs finishEventArgs)
        {
            AddEntity(new Background("score_background.jpg", this));
            var backButton = new Button(new Rect(new Point(50, 900), new Size(100, 100)), this, "backButton.png", "backButton_hover.png");
            backButton.Clicked += BackButtonOnClicked;
            AddEntity(backButton);
            AddEntity(new ScorePanel(this, finishEventArgs));
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
