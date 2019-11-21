***REMOVED***
***REMOVED***
using System.Linq;
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
using TypTop.VisualKeyboard;

namespace TypTop.Gui
***REMOVED***
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    ***REMOVED***
        private readonly KeyStyle _highlightKeyStyle;

        public MainWindow()
        ***REMOVED***
            InitializeComponent();


            var imageBrush1 = new ImageBrush(new BitmapImage(
                    new Uri(@"C:\Users\JanFokke\Desktop\stone.png", UriKind.Relative)))
            ***REMOVED***
                Viewport = new Rect(0,0,50,50),
                ViewportUnits = BrushMappingMode.Absolute,
                TileMode = TileMode.Tile,
                Stretch = Stretch.None
        ***REMOVED***;
            
            var imageBrush2 = new ImageBrush(new BitmapImage(
                new Uri(@"C:\Users\JanFokke\Desktop\diamond.png", UriKind.Relative)))
                ***REMOVED***
                    Viewport = new Rect(0, 0, 50, 50),
                    ViewportUnits = BrushMappingMode.Absolute,
                    TileMode = TileMode.Tile,
                    Stretch = Stretch.None
        ***REMOVED***;
            
            KeyStyle.Default.FaceBrush = imageBrush1;
            KeyStyle.Default.SymbolBrush = Brushes.White;
            KeyStyle.Default.BaseBrush = Brushes.Black;

            _highlightKeyStyle = new KeyStyle
            ***REMOVED***
                FaceBrush = imageBrush2,
        ***REMOVED***;


            


            KeyUp += OnKeyUp;
    ***REMOVED***

        private void OnKeyUp(object sender, KeyEventArgs e)
        ***REMOVED***
            try
            ***REMOVED***
                VisualKeyboard.SetKeyStyle(e.Key, _highlightKeyStyle);
        ***REMOVED***
            catch
            ***REMOVED***
                //Ignore
        ***REMOVED***
    ***REMOVED***


        private void LayoutRadio_OnChecked(object sender, RoutedEventArgs e)
        ***REMOVED***
            if(!IsInitialized)
                return;

            VisualKeyboard.InvalidateKeyStyle();

            if (sender == QwertRadioButton)
            ***REMOVED***
                VisualKeyboard.Layout = KeyboardLayout.Qwerty;
        ***REMOVED***
            else if (sender == ColemakRadioButton)
            ***REMOVED***
                VisualKeyboard.Layout = KeyboardLayout.Azerty;
        ***REMOVED***
    ***REMOVED***

        private void ResetButton_OnClick(object sender, RoutedEventArgs e)
        ***REMOVED***
            VisualKeyboard.InvalidateKeyStyle();
    ***REMOVED***
***REMOVED***
***REMOVED***
