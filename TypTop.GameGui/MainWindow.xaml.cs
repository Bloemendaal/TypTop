using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using TypTop.Logic;
using TypTop.MinigameEngine;

namespace TypTop.GameGui
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //AllocConsole();
            PreviewTextInput += OnPreviewTextInput;
            MouseDown += OnMouseDown;

            var wordProvider = new WordProvider
            {
                MaxWordLength = 8,
                MinWordLength = 3
            };
            wordProvider.LoadTestWords();

            //tGame.OnFinished += OnFinishedGame;
            //sGame.OnFinished += OnFinishedGame;

            var gameLoader = new GameLoader(GameWindow, new List<World>
            {
                new World("tavernButton.png", "tavernLevelBackground.png", new List<Level>
                {
                    new Level
                    {
                        WinCondition = WinConditionType.LifeCondition,

                        ThresholdOneStar = 1,
                        ThresholdTwoStars = 2,
                        ThresholdThreeStars = 3,

                        Properties = new Dictionary<string, object>
                        {
                            {"Words", wordProvider.Serve()},
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
                                    {5, 4000}
                                }
                            }
                        }
                    }
                }, WorldId.Tavern),
                new World("spaceButton.png", "levelBackground.jpeg", new List<Level>
                {
                    new Level
                    {
                        WinCondition = WinConditionType.ScoreCondition,
                        ThresholdOneStar = 100,
                        ThresholdTwoStars = 200,
                        ThresholdThreeStars = 300,

                        Properties = new Dictionary<string, object>
                        {
                            {"Words", wordProvider.Serve()},
                            {"Lives", 6},
                            {"EnemyVelocityOffset", 1f},
                            {"LineHeight", 800f}
                        }
                    }
                }, WorldId.Space)
            });
            gameLoader.LoadWorldMap();

            //GameWindow.Start(sGame, new Transition(1d));
            //GameWindow.Start(new WorldScreenGame());
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AllocConsole();

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