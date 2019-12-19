using System.Numerics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using TypTop.GameEngine;

namespace TypTop.VisualKeyboard
{
    public class VisualKeyboard : Entity
    {
        private readonly KeyboardLayout Layout;

        public void SetKeyStyle(Key key, KeyStyle color)
        {
            Layout.SetKeyStyle(key, color);
        }

        public override void Draw(DrawingContext drawingContext)
        {
            base.Draw(drawingContext);
            Layout.Render(drawingContext);
        }

        public VisualKeyboard(Game minigame, Vector2 position) : base(minigame)
        {
            Layout = new QwertyKeyboardLayout(position);
        }
    }
}
