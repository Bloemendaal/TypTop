using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Windows.Media.Imaging;
using TypTop.GameEngine;
using TypTop.GameEngine.Components;
using System.Windows.Media;
using System.Globalization;
using System.Windows;

namespace TypTop.MinigameEngine
{
    public class Score : Entity
    {

        public int Amount
        {
            get => _amount;
            set
            {
                int diff = value - _amount;
                _amount = value;
                DisplayDifference(diff);
            }
        }
        private int _amount = 0;

        public float LabelTransformX {
            get => _labelComponent.TransformX;
            set => _labelComponent.TransformX = value;
        }
        public float LabelTransformY {
            get => _labelComponent.TransformY;
            set => _labelComponent.TransformY = value;
        }

        public float LabelX => _labelComponent.X;
        public float LabelY => _labelComponent.Y;

        public enum FloatDirection { None, Up, Down }
        public FloatDirection Direction = FloatDirection.None;

        public Typeface Typeface = new Typeface("Myriad");
        public SolidColorBrush Color = Brushes.Black;
        public SolidColorBrush Negative = Brushes.DarkRed;
        public SolidColorBrush Positive = Brushes.DarkGreen;
        public int FontSize = 30;

        private readonly LabelComponent _labelComponent = new LabelComponent();

        public string Prefix = null;
        public string Suffix = null;

        public Score(Vector2 position, Game game, string background = null, float? width = null) : base(game)
        {
            AddComponent(new PositionComponent(position));

            if (background != null)
            {
                AddComponent(new ImageComponent(new BitmapImage(new Uri($@"Images/{background}.png", UriKind.Relative)))
                {
                    Width = width
                });
            }

            AddComponent(_labelComponent);
        }
        public Score(float x, float y, Game game, string background = null, float? width = null) : this(new Vector2(x, y), game, background, width) { }

        public void UpdateText()
        {
            _labelComponent.Text = new FormattedText(
                $"{Prefix ?? ""}{Amount}{Suffix ?? ""}",
                CultureInfo.GetCultureInfo("en-us"),
                FlowDirection.LeftToRight,
                Typeface,
                FontSize,
                Color
            );
        }

        private void DisplayDifference(int diff)
        {
            UpdateText();

            if (diff != 0 && Direction != FloatDirection.None)
            {
                FloatingScore fScore = new FloatingScore(diff, this)
                {
                    ZIndex = ZIndex + 1,
                    LabelTransformX = 118
                };

                Game.AddEntity(fScore);
            }
        }
    }
}
