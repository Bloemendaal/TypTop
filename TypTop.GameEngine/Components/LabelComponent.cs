using System;
using System.Windows;
using System.Windows.Media;

namespace TypTop.GameEngine.Components
{
    public class LabelComponent : Component, IDrawable
    {
        private PositionComponent _positionComponent;

        public bool Center = false;
        public bool Middle = false;

        public FormattedText Text;

        public float TransformX = 0;
        public float TransformY = 0;

        public LabelComponent(FormattedText text = null)
        {
            Text = text;
        }

        public float X => _positionComponent.X + TransformX -
                          (Center ? (float) Text.WidthIncludingTrailingWhitespace / 2 : 0);

        public float Y => _positionComponent.Y + TransformY - (Middle ? (float) Text.Height / 2 : 0);

        public double Width => Text?.WidthIncludingTrailingWhitespace ?? 0;
        public double Height => Text?.Height ?? 0;

        public bool Hidden { get; set; }

        public void Draw(DrawingContext context)
        {
            if (Text != null) context.DrawText(Text, new Point(X, Y));
        }

        public override void AddedToEntity()
        {
            _positionComponent = Entity.GetComponent<PositionComponent>();
            if (_positionComponent == null) throw new Exception("PositionComponent is required to draw a label.");
        }
    }
}