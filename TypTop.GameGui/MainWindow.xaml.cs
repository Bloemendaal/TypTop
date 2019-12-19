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

            var gameLoader = new GameLoader(GameWindow, new List<World>()
            {
                new World("tavernButton.png", "tavernLevelBackground.png" ,new List<Level>()
                {
                    new Level()
                    {
                        WinCondition = WinConditionType.ScoreCondition,

                        ThresholdOneStar = 250,
                        ThresholdTwoStars = 500,
                        ThresholdThreeStars = 750,

                        WordProvider = wordProvider,

                        Properties = new Dictionary<string, object>()
                        {
                            {"Seconds", 120}
                        }
                    },
                    new Level()
                    {
                        WinCondition = WinConditionType.TimeCondition,

                        ThresholdOneStar = 300,
                        ThresholdTwoStars = 180,
                        ThresholdThreeStars = 120,

                        WordProvider = wordProvider,

                        Properties = new Dictionary<string, object>()
                        {
                            {"Queue", 30}
                        }
                    },
                    new Level()
                    {
                        WinCondition = WinConditionType.LifeCondition,

                        ThresholdOneStar = 1,
                        ThresholdTwoStars = 2,
                        ThresholdThreeStars = 3,

                        WordProvider = wordProvider,

                        Properties = new Dictionary<string, object>()
                        {
                            {"Lives", 6},
                            {"Seconds", 120},
                            {"ShowSatisfaction", true},
                            {
                                "SatisfactionTiming", new Dictionary<int, int>
                                {
                                    {1, 4000},
                                    {2, 4000},
                                    {3, 4000},
                                    {4, 4000},
                                    {5, 4000},
                                }
                            }
                        }
                    }
                }, WorldId.Tavern,"tavernButton_hover.png"),
                
                new World("spaceButton.png", "spaceLevelBackground.jpeg", new List<Level>()
                {
                    new Level()
                    {
                        WinCondition = WinConditionType.ScoreCondition,
                        ThresholdOneStar = 100,
                        ThresholdTwoStars = 200,
                        ThresholdThreeStars = 300,

                        WordProvider = wordProvider,

                        Properties = new Dictionary<string, object>()
                        {
                            {"Lives", 6},
                            {"EnemyVelocityOffset", 3f},
                            {"LineHeight", 800f}
                        }
                    }
                }, WorldId.Space,"spaceButton_hover.png"),
                
                new World("jumpButton.png", "jumpLevelBackground.png", new List<Level>()
                {
                    new Level()
                    {
                        WinCondition = WinConditionType.ScoreCondition,
                        ThresholdOneStar = 100,
                        ThresholdTwoStars = 200,
                        ThresholdThreeStars = 300,

                        WordProvider = wordProvider,

                        Properties = new Dictionary<string, object>()
                        {
                            { "Lives", 6 },
                            { "PlatformBreakAmount", 3 },
                            { "PlatformBreakOffset", 1 },
                            { "PlatformSolidRatio", 0.5 }
                        }
                    }
                }, WorldId.Jump, "jumpButton_hover.png")
            });
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
