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
            KeyStyle.Default = new KeyStyle()
            ***REMOVED***
                BaseBrush = Brushes.Purple,
                SymbolBrush = Brushes.White,
                FaceBrush = Brushes.Violet
        ***REMOVED***;

            _highlightKeyStyle = new KeyStyle()
            ***REMOVED***
                BaseBrush = KeyStyle.Default.BaseBrush,
                SymbolBrush = Brushes.White,
                FaceBrush = Brushes.LightGreen
        ***REMOVED***;

            InitializeComponent();
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
            else if (sender == AzertyRadioButton)
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
