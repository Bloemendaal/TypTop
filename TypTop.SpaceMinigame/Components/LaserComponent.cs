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
        //
        // Props
        // 
        public bool Hidden { get; set; }

        //
        // Props
        //
        private readonly SolidColorBrush _color = new SolidColorBrush(Brushes.LightBlue.Color);
        private readonly Point _point1;
        private readonly Point _point2;

        public LaserComponent(Point point1, Point point2)
        {
            _point1 = point1;
            _point2 = point2;
        }

        /// <summary>
        /// The Draw function originally comes from the IDrawable interface.
        /// This method ensures that the component is drawn.
        /// This will be done every tick of the game.In this case, a dotted line will be drawn between the Player and the relevant Enemy.
        /// </summary>
        /// <param name="context"></param>
        public void Draw(DrawingContext context)
        {
            _color.Opacity -= 0.02;
            if (_color.Opacity <= 0)
            {
                Entity.Game.RemoveEntity(Entity);
                return;
            }

            var pen = new Pen(_color, 5);

            var dashStyle = new DashStyle(
                new double[] { 5, 5 }, 0);
            pen.DashStyle = dashStyle;

            context.DrawLine(pen, _point1, _point2);
        }
    }
}
