using System.Windows;
using System.Windows.Input;

namespace TypTop.Game
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(this);
        }

        private void MainWindow_OnTextInput(object sender, TextCompositionEventArgs e)
        {
            
        }
    }
}
