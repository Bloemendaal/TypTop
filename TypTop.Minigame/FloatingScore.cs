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
    public class FloatingScore : Entity
    {
        private readonly SolidColorBrush _color;
        private readonly Score _score;

        public float LabelTransformX
        {
            get => _labelComponent.TransformX;
            set => _labelComponent.TransformX = value;
        }
        public float LabelTransformY
        {
            get => _labelComponent.TransformY;
            set => _labelComponent.TransformY = value;
        }

        private LabelComponent _labelComponent;

        public FloatingScore(int diff, Score score) : base(score.Game)
        {
            _score = score;
            _color = new SolidColorBrush((diff < 0 ? _score.Negative : _score.Positive).Color)
            {
                Opacity = 1
            };

            AddComponent(new PositionComponent(_score.LabelX, _score.LabelY));
            AddComponent(new VelocityComponent()
            {
                Velocity = new Vector2(0, _score.Direction == Score.FloatDirection.Down ? 1 : -1)
            });

            _labelComponent = new LabelComponent(new FormattedText(
                diff.ToString(),
                CultureInfo.GetCultureInfo("en-us"),
                FlowDirection.LeftToRight,
                _score.Typeface,
                _score.FontSize,
                _color
            ));
            AddComponent(_labelComponent);
        }

        public override void Update(float deltaTime)
        {
            _color.Opacity -= 0.01;
            if (_color.Opacity <= 0)
            {
                Game.RemoveEntity(this);
                return;
            }

            base.Update(deltaTime);
        }
    }
}
