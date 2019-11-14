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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LayoutRadio_OnChecked(object sender, RoutedEventArgs e)
        {
            if(!IsInitialized)
                return;
            
            if (sender == QwertRadioButton)
            {
                VisualKeyboard.Layout = KeyboardLayout.Qwerty;
            }
            else if (sender == AzertyRadioButton)
            {
                VisualKeyboard.Layout = KeyboardLayout.Azerty;
            }
        }
    }
}
