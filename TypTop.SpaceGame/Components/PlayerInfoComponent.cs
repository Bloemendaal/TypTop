using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Media;
using TypTop.GameEngine;
using TypTop.GameEngine.Components;
using TypTop.Logic;

namespace TypTop.SpaceGame
{
    public class PlayerInfoComponent : Component, IDrawable
    {
        public bool Hidden { get; set; }

        private PositionComponent _positionComponent;
        private readonly Player _player;
        public PlayerInfoComponent(SpaceGame game)
        {
            _player = game.Player;
            Hidden = false;
        }

        public void Draw(DrawingContext context)
        {
                #pragma warning disable 618
            var formattedText = new FormattedText(
                #pragma warning restore 618
                $"{_player.Score}",
                CultureInfo.GetCultureInfo("en-us"),
                FlowDirection.LeftToRight,
                new Typeface("Myriad"),
                50,
                Brushes.WhiteSmoke);

            context.DrawText(formattedText, new Point(_positionComponent.X+10, _positionComponent.Y+10));
        }
        public override void AddedToEntity()
        {
            _positionComponent = Entity.GetComponent<PositionComponent>();
        }
    }
}
