using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Mime;
using System.Text;
using System.Windows;
using System.Windows.Media;
using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;
using TypTop.Logic;

namespace BasicGameEngine.GameEngine.Components
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
                    30,
                    Color
                );
            } 
        }
        private Word _word;
        private FormattedText _formattedText;

        public WordComponent(Word word, SolidColorBrush color = null, SolidColorBrush typedColor = null)
        {
            if (color != null) Color = color;
            if (typedColor != null) TypedColor = typedColor;
            Word = word;
        }

        public void Draw(DrawingContext context)
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

            context.DrawText(_formattedText, new Point(X, Y));
        }

        public override void AddedToEntity()
        {
            _positionComponent = Entity.GetComponent<PositionComponent>();
            if (_positionComponent == null) throw new Exception("PositionComponent is required to draw a label.");
        }
    }
}
