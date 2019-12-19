using System.Globalization;
using System.Windows;
using System.Windows.Media;
using TypTop.GameEngine;
using TypTop.GameEngine.Components;

namespace TypTop.MinigameEngine
{
    public class TextButton : Button
    {
        private readonly Rect _bounds;
        private FormattedText _formattedText;
        public string Text { get;}

        public TextButton(string text, Rect bounds, Game game, string background, string hoverBackground = null) : base(bounds, game, background, hoverBackground)
        {
            _bounds = bounds;
            Text = text;
            _formattedText = new FormattedText(
#pragma warning restore 618
                Text,
                CultureInfo.GetCultureInfo("en-us"),
                FlowDirection.LeftToRight,
                new Typeface("Arial Rounded MT Bold"),
                30,
                Brushes.DarkGreen);
        }

        public override void Draw(DrawingContext drawingContext)
        {
            base.Draw(drawingContext);
            var origin = _bounds.Center().ToPoint();
            origin.Y -= _formattedText.Height / 2;
            origin.X -= _formattedText.WidthIncludingTrailingWhitespace / 2;
            drawingContext.DrawText(_formattedText, origin);
        }
    }
}