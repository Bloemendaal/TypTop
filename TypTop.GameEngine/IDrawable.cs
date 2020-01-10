using System.Windows.Media;

namespace TypTop.GameEngine
{
    /// <summary>Inherited by components that are drawable</summary>
    public interface IDrawable
    {
        public bool Hidden { get; set; }

        /// <summary>Draws the component.</summary>
        /// <param name="context">The context.</param>
        void Draw(DrawingContext context);
    }
}