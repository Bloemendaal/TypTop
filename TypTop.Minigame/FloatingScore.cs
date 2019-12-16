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

        /// <summary>
        /// Het aantal dat moet toegevoegd worden aan de x van de label. Standaardwaarde is de TransformX van de LabelComponent.
        /// </summary>
        public float LabelTransformX
        {
            get => _labelComponent.TransformX;
            set => _labelComponent.TransformX = value;
        }

        /// <summary>
        /// Het aantal dat moet toegevoegd worden aan de y van de label. Standaardwaarde is de TransformY van de LabelComponent.
        /// </summary>
        public float LabelTransformY
        {
            get => _labelComponent.TransformY;
            set => _labelComponent.TransformY = value;
        }

        /// <summary>
        /// Geeft aan of de FloatingScore de + / - voor het verschil moet weergeven. Standaardwaarde is true.
        /// </summary>
        public bool ShowOperator = true;

        private readonly LabelComponent _labelComponent;

        public FloatingScore(int diff, Score score) : base(score.Game)
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
                $"{o}{Math.Abs(diff).ToString()}",
                CultureInfo.GetCultureInfo("en-us"),
                FlowDirection.LeftToRight,
                score.Typeface,
                score.FontSize,
                _color
            ));
            AddComponent(_labelComponent);
        }

        /// <summary>
        /// Voegt een vermindering van de Opacity toe per update en verwijdert zichzelf wanneer de Opacity 0 is.
        /// </summary>
        /// <param name="deltaTime"></param>
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
