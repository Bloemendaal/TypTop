using System.Windows;
using System.Windows.Media;
using TypTop.GameEngine;

namespace TypTop.SpaceMinigame.Components
{
    public class LaserComponent : Component, IDrawable
    {
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

        //
        // Props
        // 
        public bool Hidden { get; set; }

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
                new double[] {5, 5}, 0);
            pen.DashStyle = dashStyle;

            context.DrawLine(pen, _point1, _point2);
        }
    }
}