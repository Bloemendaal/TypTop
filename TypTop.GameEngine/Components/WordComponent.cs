using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Mime;
using System.Text;
using System.Windows;
using System.Windows.Media;
using TypTop.Logic;

namespace TypTop.GameEngine.Components
{
    public class WordComponent : Component, IDrawable
    {
        private PositionComponent _positionComponent;

        public float X => _positionComponent.X + TransformX - (Center ? (float)_formattedText.WidthIncludingTrailingWhitespace / 2 : 0);
        public float Y => _positionComponent.Y + TransformY - (Middle ? (float)_formattedText.Height / 2 : 0);

        public float TransformX = 0;
        public float TransformY = 0;

        public bool Center = false;
        public bool Middle = false;

        public SolidColorBrush Color = Brushes.Black;
        public SolidColorBrush TypedColor = Brushes.Gray;
        public Typeface Typeface = new Typeface("Myriad");
        public int FontSize = 30;

        public double Width => _formattedText?.WidthIncludingTrailingWhitespace ?? 0;
        public double Height => _formattedText?.Height ?? 0;

        public bool Hidden { get; set; }

        public Word Word { 
            get => _word; 
            set
            {
                _word = value ?? throw new Exception("Word cannot be NULL.");
                _formattedText = new FormattedText(
                    _word.Letters,
                    CultureInfo.GetCultureInfo("en-us"),
                    FlowDirection.LeftToRight,
                    Typeface,
                    FontSize,
                    Color
                );
            } 
        }
        private Word _word;
        private FormattedText _formattedText;

        public WordComponent(Word word = null, SolidColorBrush color = null, SolidColorBrush typedColor = null)
        {
            if (color != null) Color = color;
            if (typedColor != null) TypedColor = typedColor;
            if (word != null) Word = word;
        }

        public void Draw(DrawingContext context)
        {
            if (Word != null)
            {
                if (Color != null)
                {
                    _formattedText.SetForegroundBrush(Color);
                    if (Word.Index > 0 && TypedColor != null)
                    {
                        _formattedText.SetForegroundBrush(TypedColor, 0, Word.Index);
                    }
                }
                if (Typeface != null)
                {
                    _formattedText.SetFontTypeface(Typeface);
                }
                _formattedText.SetFontSize(FontSize);

                if (Y + _formattedText.Height < 0 ||
                    Y > 1080 ||
                    X + _formattedText.WidthIncludingTrailingWhitespace < 0 ||
                    X > 1920
                )
                    return;

                context.DrawText(_formattedText, new Point(X, Y));
            }
        }

        public override void AddedToEntity()
        {
            _positionComponent = Entity.GetComponent<PositionComponent>();
            if (_positionComponent == null) throw new Exception("PositionComponent is required to draw a label.");
        }
    }
}
