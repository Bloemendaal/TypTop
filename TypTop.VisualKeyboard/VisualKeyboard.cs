using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TypTop.VisualKeyboard
{
    public class VisualKeyboard : Control
    {
        private KeyboardLayout _layout = KeyboardLayout.Qwerty;

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

        static VisualKeyboard()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(VisualKeyboard), new FrameworkPropertyMetadata(typeof(VisualKeyboard)));
        }

        public VisualKeyboard()
        {
          
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
