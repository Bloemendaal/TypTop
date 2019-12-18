using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using TypTop.GameEngine;
using TypTop.GameEngine.Components;

namespace TypTop.JumpMinigame.Components
{
    public class RectangleComponent : Component, IDrawable
    {
        public bool Hidden { get; set; }

        private Rect _rectangle = new Rect();
        private PositionComponent _positionComponent;

        public Pen Pen;
        public Brush Fill;
        public double Height
        {
            get => _rectangle.Height;
            set => _rectangle.Height = value;
        }
        public double Width
        {
            get => _rectangle.Width;
            set => _rectangle.Width = value;
        }

        public double RadiusX;
        public double RadiusY;


        public void Draw(DrawingContext context)
        {
            if (_positionComponent.Y + Height < 0 ||
            _positionComponent.Y > Game.Height ||
            _positionComponent.X + Width < 0 ||
            _positionComponent.X > Game.Width
            ) return;

            _rectangle.X = _positionComponent.X;
            _rectangle.Y = _positionComponent.Y;
            context.DrawRoundedRectangle(Fill, Pen, _rectangle, RadiusX, RadiusY);
        }

        public override void AddedToEntity()
        {
            base.AddedToEntity();

            _positionComponent = Entity.GetComponent<PositionComponent>();
        }
    }
}
