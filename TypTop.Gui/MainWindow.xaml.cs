using System;
using System.Collections.Generic;
using System.Linq;
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
using TypTop.VisualKeyboard;

namespace TypTop.Gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly KeyStyle _highlightKeyStyle;

        public MainWindow()
        {
            InitializeComponent();


            var imageBrush1 = new ImageBrush(new BitmapImage(
                    new Uri(@"C:\Users\JanFokke\Desktop\stone.png", UriKind.Relative)))
            {
                Viewport = new Rect(0,0,50,50),
                ViewportUnits = BrushMappingMode.Absolute,
                TileMode = TileMode.Tile,
                Stretch = Stretch.None
            };
            
            var imageBrush2 = new ImageBrush(new BitmapImage(
                new Uri(@"C:\Users\JanFokke\Desktop\diamond.png", UriKind.Relative)))
                {
                    Viewport = new Rect(0, 0, 50, 50),
                    ViewportUnits = BrushMappingMode.Absolute,
                    TileMode = TileMode.Tile,
                    Stretch = Stretch.None
            };
            
            KeyStyle.Default.FaceBrush = imageBrush1;
            KeyStyle.Default.SymbolBrush = Brushes.White;
            KeyStyle.Default.BaseBrush = Brushes.Black;

            _highlightKeyStyle = new KeyStyle
            {
                FaceBrush = imageBrush2,
            };


            


            KeyUp += OnKeyUp;
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                VisualKeyboard.SetKeyStyle(e.Key, _highlightKeyStyle);
            }
            catch
            {
                //Ignore
            }
        }


        private void LayoutRadio_OnChecked(object sender, RoutedEventArgs e)
        {
            if(!IsInitialized)
                return;

            VisualKeyboard.InvalidateKeyStyle();

            if (sender == QwertRadioButton)
            {
                VisualKeyboard.Layout = KeyboardLayout.Qwerty;
            }
            else if (sender == ColemakRadioButton)
            {
                VisualKeyboard.Layout = KeyboardLayout.Azerty;
            }
        }

        private void ResetButton_OnClick(object sender, RoutedEventArgs e)
        {
            VisualKeyboard.InvalidateKeyStyle();
        }
    }
}
