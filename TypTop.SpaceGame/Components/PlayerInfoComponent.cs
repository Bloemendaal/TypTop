﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Media;
using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;
using TypTop.Logic;

namespace TypTop.SpaceGame
{
    public class PlayerInfoComponent : Component, IDrawable
    {
        private PositionComponent _positionComponent;
        private int score;
        public PlayerInfoComponent(SpaceGame game)
        {
            score = game.Player.Score;
        }
        public void Draw(DrawingContext context)
        {
                #pragma warning disable 618
            var formattedText = new FormattedText(
                #pragma warning restore 618
                $"Score: {score}",
                CultureInfo.GetCultureInfo("en-us"),
                FlowDirection.LeftToRight,
                new Typeface("Myriad"),
                30,
                Brushes.WhiteSmoke);

            context.DrawText(formattedText, new Point(_positionComponent.X+10, _positionComponent.Y+10));
        }
        public override void AddedToEntity()
        {
            _positionComponent = Entity.GetComponent<PositionComponent>();
        }
    }
}
