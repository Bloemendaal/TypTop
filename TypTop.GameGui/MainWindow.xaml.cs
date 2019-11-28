using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;
using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;
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
            PreviewTextInput += OnPreviewTextInput;

            WordProvider wordProvider = new WordProvider()
            {
                MaxWordLength = 8,
                MinWordLength = 3
            };
            wordProvider.LoadTestWords();
            // GameWindow.Start(new TavernGame(3, wordProvider.Serve()));
            GameWindow.Start(new SpaceGame.SpaceGame());
        }

        private void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            GameWindow.OnTextInput(e);
        }
    }
}
