using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using TypTop.GameEngine;
using TypTop.GameEngine.Components;
using TypTop.SpaceMinigame.Components;

namespace TypTop.SpaceMinigame
{
    public class Laser : Entity
    {
        private readonly PositionComponent _positionComponentPlayer;
        private readonly PositionComponent _positionComponentEnemy;
        private readonly ImageComponent _imageComponentPlayer;
        private readonly ImageComponent _imageComponentEnemy;

        public Laser(Enemy e, SpaceMinigame game) : base(game)
        {
            ZIndex = 3;

            _positionComponentEnemy = e.GetComponent<PositionComponent>();
            _imageComponentEnemy = e.GetComponent<ImageComponent>();

            _positionComponentPlayer = game.Player.GetComponent<PositionComponent>();
            _imageComponentPlayer = game.Player.GetComponent<ImageComponent>();


            if (_imageComponentEnemy.Width == null || _imageComponentEnemy.Height == null || _imageComponentPlayer.Width == null)
            {
                _imageComponentPlayer.Rotation = 0;
                return;
            }

            Point pointE = new Point(_positionComponentEnemy.X + (_imageComponentEnemy.Width.Value / 2), _positionComponentEnemy.Y + (_imageComponentEnemy.Height.Value / 2));
            Point pointP = new Point(_positionComponentPlayer.X + (_imageComponentPlayer.Width.Value / 2), _positionComponentPlayer.Y);

            AddComponent(new LaserComponent(pointE, pointP));

            var r = -Math.Atan((pointE.X - pointP.X) / (pointE.Y - pointP.Y));
            _imageComponentPlayer.Rotation = r * 180 / Math.PI;
        }
    }
}
