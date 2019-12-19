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
        
        /// <summary>
        /// /// This method ensures that the Spring is drawn at the correct height.
        /// The elevation is taken from _positionComponent. The line is then drawn on the screen.
        /// </summary>
        /// <param name="context"></param>
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

        /// <summary>
        /// Originally from Component.
        /// This method ensures that the PositionComponent is retrieved from the parent entity.
        /// </summary>
        public override void AddedToEntity()
        {
            _positionComponent = Entity.GetComponent<PositionComponent>();
        }
    }
}
