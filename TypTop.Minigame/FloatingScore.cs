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

        public bool ShowOperator = true;

        private readonly LabelComponent _labelComponent;

        public FloatingScore(int diff, Score score) : base(score.Minigame)
        {
            _color = new SolidColorBrush((diff < 0 ? score.Negative : score.Positive).Color)
            {
                Opacity = 1
            };

            AddComponent(new PositionComponent(score.LabelX, score.LabelY));
            AddComponent(new VelocityComponent()
            {
                Velocity = new Vector2(0, score.Direction == Score.FloatDirection.Down ? 1 : -1)
            });

            string o = ShowOperator ? (diff < 0 ? "- " : "+ ") : "";

            _labelComponent = new LabelComponent(new FormattedText(
                $"{o}{diff.ToString()}",
                CultureInfo.GetCultureInfo("en-us"),
                FlowDirection.LeftToRight,
                score.Typeface,
                score.FontSize,
                _color
            ));
            AddComponent(_labelComponent);
        }

        public override void Update(float deltaTime)
        {
            _color.Opacity -= 0.01;
            if (_color.Opacity <= 0)
            {
                Minigame.RemoveEntity(this);
                return;
            }

            base.Update(deltaTime);
        }
    }
}
