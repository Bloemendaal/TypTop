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
            _highlightKeyStyle = new KeyStyle
            ***REMOVED***
                BaseBrush = KeyStyle.Default.BaseBrush,
                SymbolBrush = Brushes.White,
                FaceBrush = Brushes.LightGreen
        ***REMOVED***;

            InitializeComponent();
            KeyUp += OnKeyUp;


            VisualKeyboard.SetKeyStyle(Key.D1, MakeFaceStyle(Brushes.Tomato));
            VisualKeyboard.SetKeyStyle(Key.D2, MakeFaceStyle(Brushes.Tomato));
            VisualKeyboard.SetKeyStyle(Key.Q, MakeFaceStyle(Brushes.Tomato));
            VisualKeyboard.SetKeyStyle(Key.A, MakeFaceStyle(Brushes.Tomato));
            VisualKeyboard.SetKeyStyle(Key.Z, MakeFaceStyle(Brushes.Tomato));
            VisualKeyboard.SetKeyStyle(Key.LeftShift, MakeFaceStyle(Brushes.Tomato));
            VisualKeyboard.SetKeyStyle(Key.Tab, MakeFaceStyle(Brushes.Tomato));
            VisualKeyboard.SetKeyStyle(Key.CapsLock, MakeFaceStyle(Brushes.Tomato));
            VisualKeyboard.SetKeyStyle(Key.OemTilde, MakeFaceStyle(Brushes.Tomato));

            VisualKeyboard.SetKeyStyle(Key.D3, MakeFaceStyle(Brushes.SkyBlue));
            VisualKeyboard.SetKeyStyle(Key.W, MakeFaceStyle(Brushes.SkyBlue));
            VisualKeyboard.SetKeyStyle(Key.S, MakeFaceStyle(Brushes.SkyBlue));
            VisualKeyboard.SetKeyStyle(Key.X, MakeFaceStyle(Brushes.SkyBlue));

            VisualKeyboard.SetKeyStyle(Key.D4, MakeFaceStyle(Brushes.Gold));
            VisualKeyboard.SetKeyStyle(Key.E, MakeFaceStyle(Brushes.Gold));
            VisualKeyboard.SetKeyStyle(Key.D, MakeFaceStyle(Brushes.Gold));
            VisualKeyboard.SetKeyStyle(Key.C, MakeFaceStyle(Brushes.Gold));

            VisualKeyboard.SetKeyStyle(Key.D5, MakeFaceStyle(Brushes.LightGreen));
            VisualKeyboard.SetKeyStyle(Key.R, MakeFaceStyle(Brushes.LightGreen));
            VisualKeyboard.SetKeyStyle(Key.F, MakeFaceStyle(Brushes.LightGreen));
            VisualKeyboard.SetKeyStyle(Key.V, MakeFaceStyle(Brushes.LightGreen));
            VisualKeyboard.SetKeyStyle(Key.D6, MakeFaceStyle(Brushes.LightGreen));
            VisualKeyboard.SetKeyStyle(Key.T, MakeFaceStyle(Brushes.LightGreen));
            VisualKeyboard.SetKeyStyle(Key.G, MakeFaceStyle(Brushes.LightGreen));
            VisualKeyboard.SetKeyStyle(Key.B, MakeFaceStyle(Brushes.LightGreen));


            VisualKeyboard.SetKeyStyle(Key.D8, MakeFaceStyle(Brushes.LightGreen));
            VisualKeyboard.SetKeyStyle(Key.U, MakeFaceStyle(Brushes.LightGreen));
            VisualKeyboard.SetKeyStyle(Key.J, MakeFaceStyle(Brushes.LightGreen));
            VisualKeyboard.SetKeyStyle(Key.M, MakeFaceStyle(Brushes.LightGreen));
            VisualKeyboard.SetKeyStyle(Key.D7, MakeFaceStyle(Brushes.LightGreen));
            VisualKeyboard.SetKeyStyle(Key.Y, MakeFaceStyle(Brushes.LightGreen));
            VisualKeyboard.SetKeyStyle(Key.H, MakeFaceStyle(Brushes.LightGreen));
            VisualKeyboard.SetKeyStyle(Key.N, MakeFaceStyle(Brushes.LightGreen));

            VisualKeyboard.SetKeyStyle(Key.D9, MakeFaceStyle(Brushes.Gold));
            VisualKeyboard.SetKeyStyle(Key.I, MakeFaceStyle(Brushes.Gold));
            VisualKeyboard.SetKeyStyle(Key.K, MakeFaceStyle(Brushes.Gold));
            VisualKeyboard.SetKeyStyle(Key.OemComma, MakeFaceStyle(Brushes.Gold));

            VisualKeyboard.SetKeyStyle(Key.D0, MakeFaceStyle(Brushes.SkyBlue));
            VisualKeyboard.SetKeyStyle(Key.O, MakeFaceStyle(Brushes.SkyBlue));
            VisualKeyboard.SetKeyStyle(Key.L, MakeFaceStyle(Brushes.SkyBlue));
            VisualKeyboard.SetKeyStyle(Key.OemPeriod, MakeFaceStyle(Brushes.SkyBlue));

            VisualKeyboard.SetKeyStyle(Key.P, MakeFaceStyle(Brushes.Tomato));
            VisualKeyboard.SetKeyStyle(Key.OemSemicolon, MakeFaceStyle(Brushes.Tomato));
            VisualKeyboard.SetKeyStyle(Key.OemQuestion, MakeFaceStyle(Brushes.Tomato));
            VisualKeyboard.SetKeyStyle(Key.RightShift, MakeFaceStyle(Brushes.Tomato));
            VisualKeyboard.SetKeyStyle(Key.Enter, MakeFaceStyle(Brushes.Tomato));
            VisualKeyboard.SetKeyStyle(Key.OemPipe, MakeFaceStyle(Brushes.Tomato));
            VisualKeyboard.SetKeyStyle(Key.OemPlus, MakeFaceStyle(Brushes.Tomato));
            VisualKeyboard.SetKeyStyle(Key.OemMinus, MakeFaceStyle(Brushes.Tomato));
            VisualKeyboard.SetKeyStyle(Key.Back, MakeFaceStyle(Brushes.Tomato));
            VisualKeyboard.SetKeyStyle(Key.OemCloseBrackets, MakeFaceStyle(Brushes.Tomato));
            VisualKeyboard.SetKeyStyle(Key.OemOpenBrackets, MakeFaceStyle(Brushes.Tomato));
            VisualKeyboard.SetKeyStyle(Key.OemQuotes, MakeFaceStyle(Brushes.Tomato));
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

        KeyStyle MakeFaceStyle(Brush faceBrush)
        ***REMOVED***
            return new KeyStyle()
            ***REMOVED***
                FaceBrush = faceBrush,
                SymbolBrush = Brushes.Black
        ***REMOVED***;
    ***REMOVED***

***REMOVED***
***REMOVED***
