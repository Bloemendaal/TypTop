using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;
using System.Windows;
using System.Windows.Media;
using TypTop.GameEngine;
using TypTop.GameEngine.Components;

namespace TypTop.MinigameEngine
{
    public class Count : Entity
    {

        private readonly DateTime _dateTime;
        private readonly bool _countDown;

        private readonly LabelComponent _labelComponent = new LabelComponent();
        private readonly PositionComponent _positionComponent;

        public bool ShowHours = false;

        public bool Finished { get; private set; }

        public float X
        {
            get => _positionComponent.X;
            set => _positionComponent.X = value;
        }
        public float Y
        {
            get => _positionComponent.Y;
            set => _positionComponent.Y = value;
        }

        public Typeface Typeface = new Typeface("Myriad");
        public SolidColorBrush Color = Brushes.Black;
        public SolidColorBrush FinishedColor = Brushes.DarkRed;
        public int FontSize = 30;

        public string Prefix = null;
        public string Suffix = null;

        public Count(int seconds, Vector2 position, Game game) : base(game)
        {
            _dateTime = DateTime.Now;
            if (seconds == 0)
            {
                _countDown = false;
            }
            else
            {
                _countDown = true;
                _dateTime = _dateTime.AddSeconds(seconds);
            }

            _positionComponent = new PositionComponent(position);

            AddComponent(_positionComponent);
            AddComponent(_labelComponent);
        }
        public Count(int seconds, float x, float y, Game game) : this(seconds, new Vector2(x, y), game) { }

        public override void Update(float deltaTime)
        {
            TimeSpan timeSpan = _countDown ^ Finished ? _dateTime.Subtract(DateTime.Now) : (DateTime.Now).Subtract(_dateTime);

            StringBuilder sb = new StringBuilder();

            if (Prefix != null)
            {
                sb.Append(Prefix);
            }
            if (Finished)
            {
                sb.Append("-");
            }
            if (ShowHours)
            {
                sb.Append($"{("0" + (int)timeSpan.Hours).Substring((int)timeSpan.Hours < 10 ? 0 : 1, 2)}:");
            }
            sb.Append($"{("0" + (int)timeSpan.Minutes).Substring((int)timeSpan.Minutes < 10 ? 0 : 1, 2)}:{("0" + (int)timeSpan.Seconds).Substring((int)timeSpan.Seconds < 10 ? 0 : 1, 2)}");
            if (Suffix != null)
            {
                sb.Append(Suffix);
            }

            _labelComponent.Text = new FormattedText(
                sb.ToString(),
                CultureInfo.GetCultureInfo("en-us"),
                FlowDirection.LeftToRight,
                Typeface,
                FontSize,
                Finished ? FinishedColor : Color
            );

            if (_countDown && timeSpan.TotalSeconds <= 0)
            {
                Finished = true;
            }

            base.Update(deltaTime);
        }
    }
}
