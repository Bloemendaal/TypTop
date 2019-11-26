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
using BasicGameEngine;
using SpaceInvadersMinigame;
using TavernMinigame;


namespace TypTop.GameGui
***REMOVED***
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    ***REMOVED***
        public MainWindow()
        ***REMOVED***
            InitializeComponent();

            GameWindow.Start(new TavernGame(3));
    ***REMOVED***
***REMOVED***
***REMOVED***
