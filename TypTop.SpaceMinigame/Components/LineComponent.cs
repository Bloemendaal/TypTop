using System;
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
        //
        // Props
        //
        public bool Hidden { get; set; }

        //
        // Vars
        //
        private PositionComponent _positionComponent;

        public LineComponent()
        {
            Hidden = false;
        }

        public void Draw(DrawingContext context)
        {
            var pen = new Pen(Brushes.YellowGreen, 5);
            
            var dashStyle = new DashStyle(
                new double[] { 5, 5 }, 0);
            pen.DashStyle = dashStyle;
            
            var point1 = new Point(0, _positionComponent.Y);
            var point2 = new Point(1920, _positionComponent.Y);
            context.DrawLine(pen, point1, point2);
            
        }
        public override void AddedToEntity()
        {
            _positionComponent = Entity.GetComponent<PositionComponent>();
        }
    }
}
