using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;
using TypTop.GameEngine;
using TypTop.GameEngine.Components;
using Microsoft.EntityFrameworkCore;
using TypTop.GameWindow;
using TypTop.Logic;
using TypTop.TavernMinigame;
using TypTop.MinigameEngine.WinConditions;
using TypTop.MinigameEngine;
using TypTop.SpaceMinigame;
using TypTop.WorldScreen;
using TypTop.JumpMinigame;
using TypTop.Shared;
using TypTop.Repository;
using Newtonsoft.Json;
using System.Linq;


namespace TypTop.GameGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public MainWindow()
        {
            InitializeComponent();
            //AllocConsole();
            PreviewTextInput += OnPreviewTextInput;
            MouseDown += OnMouseDown;
            MouseMove += OnMouseMove;

            WordProvider wordProvider = new WordProvider()
            {
                MaxWordLength = 8,
                MinWordLength = 3
            };

            wordProvider.LoadTestWords();

            var gameLoader = new LevelStore(GameWindow, wordProvider).GameLoader;

            gameLoader.LoadWorldMap();
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            GameWindow.OnMouseHover(e.GetPosition(GameWindow));
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            GameWindow.OnMouseDown(e.GetPosition(GameWindow));
        }

        private void OnFinishedGame(object sender, FinishEventArgs e)
        {
            GameWindow.Stop();
        }

        private void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            GameWindow.OnTextInput(e);
        }
    }
}
