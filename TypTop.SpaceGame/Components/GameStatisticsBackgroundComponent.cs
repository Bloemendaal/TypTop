using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;
using TypTop.GameEngine;
using TypTop.GameEngine.Components;
using Point = System.Windows.Point;

namespace TypTop.SpaceGame.Components
{
    public class GameStatisticsBackgroundComponent : Component, IDrawable
    {
        private PositionComponent _positionComponent;

        public bool Hidden { get; set; }

        public void Draw(DrawingContext context)
        {
            Pen pen = new Pen(Brushes.YellowGreen, 5);

            Rect rect = new Rect
            {
                Height = 100, 
                Width = 500, 
                X = _positionComponent.X, 
                Y = _positionComponent.Y
            };

            context.DrawRectangle(Brushes.DimGray, null, rect);
        }

        public override void AddedToEntity()
        {
            _positionComponent = Entity.GetComponent<PositionComponent>();
        }
    }
}
