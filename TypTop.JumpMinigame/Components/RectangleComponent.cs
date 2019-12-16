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


        public void Draw(DrawingContext context)
        {
            _rectangle.X = _positionComponent.X;
            _rectangle.Y = _positionComponent.Y;
            context.DrawRectangle(Fill, Pen, _rectangle);
        }

        public override void AddedToEntity()
        {
            base.AddedToEntity();

            _positionComponent = Entity.GetComponent<PositionComponent>();
        }
    }
}
