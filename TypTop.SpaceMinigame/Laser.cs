using System;
using System.Windows;
using TypTop.GameEngine;
using TypTop.GameEngine.Components;
using TypTop.SpaceMinigame.Components;

namespace TypTop.SpaceMinigame
{
    public class Laser : Entity
    {
        private readonly ImageComponent _imageComponentEnemy;
        private readonly ImageComponent _imageComponentPlayer;

        private readonly PositionComponent _positionComponentEnemy;

        //
        // Vars
        //
        private readonly PositionComponent _positionComponentPlayer;

        public Laser(Enemy e, SpaceGame game) : base(game)
        {
            ZIndex = 3;

            _positionComponentEnemy = e.GetComponent<PositionComponent>();
            _imageComponentEnemy = e.GetComponent<ImageComponent>();

            _positionComponentPlayer = game.Player.GetComponent<PositionComponent>();
            _imageComponentPlayer = game.Player.GetComponent<ImageComponent>();


            if (_imageComponentEnemy.Width == null || _imageComponentEnemy.Height == null ||
                _imageComponentPlayer.Width == null)
            {
                _imageComponentPlayer.Rotation = 0;
                return;
            }

            var pointE = new Point(
                _positionComponentEnemy.X + _imageComponentEnemy.Width.Value / 2,
                _positionComponentEnemy.Y + _imageComponentEnemy.Height.Value / 2);
            var pointP = new Point(
                _positionComponentPlayer.X + _imageComponentPlayer.Width.Value / 2,
                _positionComponentPlayer.Y);

            AddComponent(new LaserComponent(pointE, pointP));

            var r = -Math.Atan((pointE.X - pointP.X) / (pointE.Y - pointP.Y));
            _imageComponentPlayer.Rotation = r * 180 / Math.PI;
        }
    }
}