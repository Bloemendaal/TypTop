using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Shapes;
using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;
using TypTop.Gui.SpaceGame;
using TypTop.Logic;
using TavernMinigame;

namespace TypTop.GameGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            GameWindow.Start(new TavernGame(4));
        }
    }
}
