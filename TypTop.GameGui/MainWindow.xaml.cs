***REMOVED***
***REMOVED***
using System.Windows;
using System.Windows.Shapes;
using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;
using TypTop.Gui.SpaceGame;
using TypTop.Logic;
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

            GameWindow.Start(new TavernGame(4));
    ***REMOVED***
***REMOVED***
***REMOVED***
