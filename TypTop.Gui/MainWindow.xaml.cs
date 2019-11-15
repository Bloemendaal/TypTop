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
        public MainWindow()
        ***REMOVED***
            InitializeComponent();
    ***REMOVED***

        private void LayoutRadio_OnChecked(object sender, RoutedEventArgs e)
        ***REMOVED***
            if(!IsInitialized)
                return;

            if (sender == QwertRadioButton)
            ***REMOVED***
                VisualKeyboard.Layout = KeyboardLayout.Qwerty;
        ***REMOVED***
            else if (sender == AzertyRadioButton)
            ***REMOVED***
                VisualKeyboard.Layout = KeyboardLayout.Azerty;
        ***REMOVED***
    ***REMOVED***
***REMOVED***
***REMOVED***
