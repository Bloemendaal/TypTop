using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;
using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;

namespace TypTop.SpaceGame.Components
{
    public class GameStatisticsBackgroundComponent : Component, IDrawable
    {
        private PositionComponent _positionComponent;
        public void Draw(DrawingContext context)
        {
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
