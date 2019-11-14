***REMOVED***
***REMOVED***
using System.Linq;
using System.Security.Cryptography.X509Certificates;
***REMOVED***
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
***REMOVED***
    public class VisualKeyboard : Control
    ***REMOVED***
        private KeyboardLayout _layout = KeyboardLayout.Qwerty;

        public KeyboardLayout Layout
        ***REMOVED***
            get => _layout;
            set
            ***REMOVED***
                _layout = value;
                InvalidateVisual();
        ***REMOVED***
    ***REMOVED***

        public void SetKeyStyle(Key key, Color color)
        ***REMOVED***
            
    ***REMOVED***

        static VisualKeyboard()
        ***REMOVED***
            DefaultStyleKeyProperty.OverrideMetadata(typeof(VisualKeyboard), new FrameworkPropertyMetadata(typeof(VisualKeyboard)));
    ***REMOVED***

        public VisualKeyboard()
        ***REMOVED***
            KeyStyle keyStyle = new KeyStyle()
            ***REMOVED***
                BaseBrush = new SolidColorBrush(Colors.Gray),
                FaceBrush = new SolidColorBrush(Colors.WhiteSmoke),
                SymbolBrush = new SolidColorBrush(Colors.Black)
        ***REMOVED***;
    ***REMOVED***

        protected override void OnRender(DrawingContext drawingContext)
        ***REMOVED***
            Layout.Render(drawingContext);
            base.OnRender(drawingContext);
    ***REMOVED***
***REMOVED***
***REMOVED***
