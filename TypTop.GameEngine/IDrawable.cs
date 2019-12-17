using System.Windows.Media;

namespace TypTop.GameEngine
{
    public interface IDrawable
    {
        public bool Hidden { get; set; }
        void Draw(DrawingContext context);
    }
}