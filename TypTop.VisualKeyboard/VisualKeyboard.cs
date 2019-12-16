using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace TypTop.VisualKeyboard
{
    public class VisualKeyboard : Control
    {
        private KeyboardLayout _layout = KeyboardLayout.Qwerty;

        static VisualKeyboard()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(VisualKeyboard),
                new FrameworkPropertyMetadata(typeof(VisualKeyboard)));
        }

        public KeyboardLayout Layout
        {
            get => _layout;
            set
            {
                _layout = value;
                InvalidateVisual();
            }
        }

        public void SetKeyStyle(Key key, KeyStyle color)
        {
            _layout.SetKeyStyle(key, color);
            InvalidateVisual();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            Layout.Render(drawingContext);
            base.OnRender(drawingContext);
        }

        public void InvalidateKeyStyle()
        {
            _layout.InvalidateKeyStyle();
            InvalidateVisual();
        }
    }
}