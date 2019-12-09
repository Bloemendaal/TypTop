using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using TypTop.GameEngine;
using TypTop.GameEngine.Components;

namespace TypTop.SpaceMinigame.Components
{
    public class LaserComponent : Component, IDrawable
    {
        private readonly SolidColorBrush _color = new SolidColorBrush(Brushes.LightBlue.Color);
        private readonly Point _point1;
        private readonly Point _point2;

        public bool Hidden { get; set; }

        public LaserComponent(Point point1, Point point2)
        {
            _point1 = point1;
            _point2 = point2;
        }

        public void Draw(DrawingContext context)
        {
            _color.Opacity -= 0.02;
            if (_color.Opacity <= 0)
            {
                Entity.Game.RemoveEntity(Entity);
                return;
            }

            Pen pen = new Pen(_color, 5);

            DashStyle dash_style1 = new DashStyle(
                new double[] { 5, 5 }, 0);
            pen.DashStyle = dash_style1;

            context.DrawLine(pen, _point1, _point2);
        }
    }
}
