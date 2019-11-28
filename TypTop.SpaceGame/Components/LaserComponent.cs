﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;

namespace TypTop.SpaceGame
{
    public class LaserComponent : Component, IDrawable
    {
        private readonly PositionComponent _positionComponentPlayer;
        private readonly PositionComponent _positionComponentEnemy;
        private readonly ImageComponent _imageComponentPlayer;
        private readonly ImageComponent _imageComponentEnemy;

        public LaserComponent(SpaceGame game)
        {
            _positionComponentEnemy = game.EnemyQueue.First().GetComponent<PositionComponent>();
            _imageComponentEnemy = game.EnemyQueue.First().GetComponent<ImageComponent>();

            _positionComponentPlayer = game.Player.GetComponent<PositionComponent>();
            _imageComponentPlayer = game.Player.GetComponent<ImageComponent>();
        }

        public void Draw(DrawingContext context)
        {
            Pen pen = new Pen(Brushes.LightBlue, 5);

            DashStyle dash_style1 = new DashStyle(
                new double[] { 5, 5 }, 0);
            pen.DashStyle = dash_style1;

            if (_imageComponentEnemy.Width == null) return;
            if (_imageComponentEnemy.Height == null) return;
            if (_imageComponentPlayer.Width == null) return;
            Point point1 = new Point(_positionComponentEnemy.X + (_imageComponentEnemy.Width.Value / 2), _positionComponentEnemy.Y + (_imageComponentEnemy.Height.Value / 2));
            Point point2 = new Point(_positionComponentPlayer.X + (_imageComponentPlayer.Width.Value /2), _positionComponentPlayer.Y);
            context.DrawLine(pen, point1, point2);
        }
    }
}