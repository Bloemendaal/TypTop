using System;
using System.Collections.Generic;
using System.Windows;
using System.Text;
using System.Windows.Media;
using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;

namespace TypTop.SpaceGame
{
    public class LineComponent : Component, IDrawable
    {
        private PositionComponent pc;
        public void Draw(DrawingContext context)
        {
            Pen pen = new Pen(Brushes.YellowGreen, 5);
            
            DashStyle dash_style1 = new DashStyle(
                new double[] { 5, 5 }, 0);
            pen.DashStyle = dash_style1;
            
            Point point1 = new Point(0, 950);
            Point point2 = new Point(1920, 950);
            context.DrawLine(pen, point1, point2);
            
        }
        public override void AddedToEntity()
        {
            pc = Entity.GetComponent<PositionComponent>();
        }
    }
}
