﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Text;
using System.Windows.Media;
using TypTop.GameEngine;
using TypTop.GameEngine.Components;

namespace TypTop.SpaceMinigame.Components
{
    public class LineComponent : Component, IDrawable
    {
        public bool Hidden { get; set; }

        private PositionComponent _positionComponent;

        public LineComponent()
        {
            Hidden = false;
        }

        public void Draw(DrawingContext context)
        {
            Pen pen = new Pen(Brushes.YellowGreen, 5);
            
            DashStyle dash_style1 = new DashStyle(
                new double[] { 5, 5 }, 0);
            pen.DashStyle = dash_style1;
            
            Point point1 = new Point(0, _positionComponent.Y);
            Point point2 = new Point(1920, _positionComponent.Y);
            context.DrawLine(pen, point1, point2);
            
        }
        public override void AddedToEntity()
        {
            _positionComponent = Entity.GetComponent<PositionComponent>();
        }
    }
}