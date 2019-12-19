using System;
using System.Globalization;
using System.Numerics;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TypTop.GameEngine;
using TypTop.GameEngine.Components;

namespace TypTop.LevelScreen
{
    public class InfoPanel : Entity
    {
        private PositionComponent _positionComponent;
        private ImageComponent _imageComponent;
        private FormattedText _formattedText;
        private string _text;

        public bool Visible { get; set; }

        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                _formattedText = new FormattedText(
#pragma warning restore 618
                    value,
                    CultureInfo.GetCultureInfo("en-us"),
                    FlowDirection.LeftToRight,
                    new Typeface("Veranda"),
                    25,
                    Brushes.Black);
                _formattedText.MaxTextWidth = 700;
            }
        }

        public InfoPanel(Game minigame) : base(minigame)
        {
            var r = Utils.GetRectangle(0, 1, 1, 0f, 900f, 600f);
            _positionComponent = new PositionComponent
            {
                Position = new Vector2((float) r.X, (float) r.Y)
            };
            _imageComponent = new ImageComponent(new BitmapImage(new Uri($@"Images/info.png", UriKind.Relative)))
            {
                Width = r.Width,
                Height = r.Height
            };

            AddComponent(_positionComponent);
            AddComponent(_imageComponent);
        }

        public override void Draw(DrawingContext drawingContext)
        {
            if(Visible == false)
                return;
            
            base.Draw(drawingContext);
            drawingContext.DrawText(_formattedText, new Point(605,400));
        }
    }
}